using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

namespace otoge_edit
{
    public partial class Form1 : Form
    {
        const int bar = 400;    //小節線の間隔
        const int startBar = 50;    //カーソル位置のy座標

        public void update()
        {
            updateTNote();

            if (DX.CheckSoundMem(SHandlePlay) == 1)
            {
                scorePos = DX.GetSoundCurrentTime(SHandlePlay);
                vScrollBar1.Value = vScrollBar1.Maximum - scorePos;

                //効果音
                for (int num = 0; notes[num].mTime != -1; num++)
                {
                    int ds = notes[num].mTime - scorePos;
                    if (ds < 25 && ds > -25)
                    {
                        DX.PlaySoundMem(SHSE, DX.DX_PLAYTYPE_BACK);
                        break;
                    }
                }
            }
        }

        //フォントオブジェクトの作成
        Font fnt1 = new Font("MS UI Gothic", 20);
        public void draw(Graphics g)
        {
            g.Clear(Color.Black);

            if (DataFileName == "")
            {

                //文字列を位置(0,0)、青色で表示
                g.DrawString("NO DATA", fnt1, Brushes.White, pictureBox1.Width / 2 - 70, pictureBox1.Height / 2 - 10);
            }
            else
            {
                drawLine(g);
                drawTNote(g);
                drawNote(g);

                for (int i = 0; i < 100; i++)
                {
                    string s = notes[i].mTime.ToString();
                    g.DrawString(s, fnt, Brushes.White, 0, 10 * i);
                }
            }
        }

        //Penオブジェクトの作成(幅3黒色)
        Pen p = new Pen(Color.White, 1);
        Pen b = new Pen(Color.Blue, 1);
        Pen r = new Pen(Color.Red, 1);
        Pen gray = new Pen(Color.Gray, 1);

        Font fnt = new Font("MS UI Gothic", 10);

        //罫線を引く
        private void drawLine(Graphics g)
        {

            //左右分割
            g.DrawLine(p, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            //縦クオンタイズ
            for (int i = pictureBox1.Width; i > 0; i--)
            {
                if (i % (pictureBox1.Width / 4) == 0)
                {
                    g.DrawLine(p, i, 0, i, pictureBox1.Height);
                }
                else
                if ((double)i % ((double)pictureBox1.Width / (double.Parse(quantize.Text) * 2)) <= 1)
                {
                    g.DrawLine(gray, i, 0, i, pictureBox1.Height);
                }
            }

            for (int i = pictureBox1.Height; i > 0; i--)
            {
                double beat = 60000.0 / (double)bpm.Value;
                double pixelPerTime = (double)bar / (double)(4 * beat);
                int y = pictureBox1.Height - startBar - i;
                int pos = y + (int)((double)scorePos * pixelPerTime);
                double q = (double)pos % (((4 * beat) / int.Parse(quantize.Text)) * pixelPerTime);


                //小節線
                if (pos % (4 * beat * pixelPerTime) <= 1 && pos % (4 * beat * pixelPerTime) >= 0)
                {
                    g.DrawLine(p, 0, i, pictureBox1.Width, i);
                    g.DrawString(((int)(pos / (4 * beat * pixelPerTime))).ToString(), fnt, Brushes.White, 0, i);
                }
                else

                //横クオンタイズ
                if (q <= 1 && q >= 0)
                {
                    g.DrawLine(gray, 0, i, pictureBox1.Width, i);
                    //string s = (pos / (((4 * beat) / int.Parse(quantize.Text)) * pixelPerTime)).ToString();
                    //g.DrawString(s, fnt, Brushes.Gray, 0, i);
                }
            }

            //カーソル線
            g.DrawLine(b, 0, pictureBox1.Height - startBar, pictureBox1.Width / 2, pictureBox1.Height - startBar);
            g.DrawLine(r, pictureBox1.Width / 2, pictureBox1.Height - startBar, pictureBox1.Width, pictureBox1.Height - startBar);
        }

        //記録されているノート
        private void drawNote(Graphics g)
        {
            int noteX = 0, noteY = 0;
            for (int i = 0; notes[i].mTime >= 0; i++)
            {
                double beat = 60000.0 / (double)bpm.Value;
                double pixelPerTime = (double)bar / (double)(4 * beat);
                int dt = (int)(notes[i].mTime * pixelPerTime) - (int)(scorePos * pixelPerTime);
                if (dt > -startBar * 2 && dt < pictureBox1.Height - startBar * 2)   //ノートが画面内にある時
                {
                    noteY = pictureBox1.Height - startBar - dt;
                    if (notes[i].mSide == 0)
                    {
                        noteX = pictureBox1.Width / 4 + notes[i].mPosX;

                        switch (notes[i].mType)
                        {
                            case 0: //ノーマル
                                g.FillRectangle(Brushes.Blue, noteX - 6, noteY - 6, 12, 12);
                                break;
                            case 1: //ホールドon
                                g.FillRectangle(Brushes.Blue, noteX - 6, noteY - 6, 12, 12);
                                g.FillRectangle(Brushes.LightBlue, noteX - 4, noteY - 4, 8, 8);
                                break;
                            case 2: //ホールドoff
                                g.FillRectangle(Brushes.Blue, noteX - 6, noteY - 6, 12, 12);
                                g.FillRectangle(Brushes.LightBlue, noteX - 4, noteY - 4, 8, 8);
                                g.FillRectangle(Brushes.Blue, noteX - 2, noteY - 2, 4, 4);
                                break;
                            case 3: //スライドL
                                Point[] psL = { new Point(noteX - 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.Blue, psL);
                                break;
                            case 4: //スライドR
                                Point[] psR = { new Point(noteX + 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.Blue, psR);
                                break;
                            case 5: //タッチ
                                noteX = notes[i].mPosX;
                                g.FillRectangle(Brushes.Blue, noteX - 4, noteY - 4, 8, 8);
                                break;
                            case 6: //ホールドoffL
                                Point[] psEL = { new Point(noteX - 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.LightBlue, psEL);
                                break;
                            case 7: //ホールドoffR
                                Point[] psER = { new Point(noteX + 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.LightBlue, psER);
                                break;
                            default: break;
                        }

                    }
                    else
                    {
                        noteX = pictureBox1.Width * 3 / 4 + notes[i].mPosX;

                        switch (notes[i].mType)
                        {
                            case 0: //ノーマル
                                g.FillRectangle(Brushes.Red, noteX - 6, noteY - 6, 12, 12);
                                break;
                            case 1: //ホールドon
                                g.FillRectangle(Brushes.Red, noteX - 6, noteY - 6, 12, 12);
                                g.FillRectangle(Brushes.HotPink, noteX - 4, noteY - 4, 8, 8);
                                break;
                            case 2: //ホールドoff
                                g.FillRectangle(Brushes.Red, noteX - 6, noteY - 6, 12, 12);
                                g.FillRectangle(Brushes.HotPink, noteX - 4, noteY - 4, 8, 8);
                                g.FillRectangle(Brushes.Red, noteX - 2, noteY - 2, 4, 4);
                                break;
                            case 3: //スライドL
                                Point[] psL = { new Point(noteX - 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.Red, psL);
                                break;
                            case 4: //スライドR
                                Point[] psR = { new Point(noteX + 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.Red, psR);
                                break;
                            case 5: //タッチ
                                noteX = notes[i].mPosX;
                                g.FillRectangle(Brushes.Red, noteX - 4, noteY - 4, 8, 8);
                                break;
                            case 6: //ホールドoffL
                                Point[] psEL = { new Point(noteX - 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.HotPink, psEL);
                                break;
                            case 7: //ホールドoffR
                                Point[] psER = { new Point(noteX + 6, noteY), new Point(noteX, noteY - 6), new Point(noteX, noteY + 6) };
                                g.FillPolygon(Brushes.HotPink, psER);
                                break;
                            default: break;
                        }

                    }

                }
            }
        }

        //仮ノート
        int noteX = 0, noteY = 0;
        private void drawTNote(Graphics g)
        {
            if (noteX > pictureBox1.Width / 2)
            {
                 g.FillRectangle(Brushes.DarkRed, noteX - 6, noteY - 6, 12, 12);
            }
            else if (noteX < pictureBox1.Width / 2)
            {
                g.FillRectangle(Brushes.DarkBlue, noteX - 6, noteY - 6, 12, 12);
            }
        }

        private void updateTNote()
        {
            int MouseX, MouseY;
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            MouseX = cp.X - pictureBox1.Location.X;
            MouseY = cp.Y - pictureBox1.Location.Y;


                for (int i = pictureBox1.Width; i > 0; i--)
                {
                    double wx = ((double)pictureBox1.Width / (double.Parse(quantize.Text) * 2));
                    //縦クオンタイズ
                    if ((double)i % ((double)pictureBox1.Width / (double.Parse(quantize.Text) * 2)) <= 1)
                    {
                        if (MouseX >= i - wx / 2 && MouseX < i + wx / 2)
                        {
                            noteX = i;
                            break;
                        }
                    }
                }
            
            for (int i = pictureBox1.Height; i > 0; i--)
            {
                double beat = 60000.0 / (double)bpm.Value;
                double pixelPerTime = (double)bar / (double)(4 * beat);
                int y = pictureBox1.Height - startBar - i;
                int pos = y + (int)(scorePos * pixelPerTime);
                double q = (double)pos % (((4 * beat) / int.Parse(quantize.Text)) * pixelPerTime);
                double wq = (((4 * beat) / int.Parse(quantize.Text)) * pixelPerTime);

                //横クオンタイズ
                if (q <= 1 && q >= 0)
                {
                    if (MouseY >= i - wq / 2 && MouseY < i + wq / 2)
                    {
                        noteY = i;
                        break;
                    }
                }
            }
        }

        private void SetNote()
        {
            int num;
            double beat = 60000.0 / (double)bpm.Value;
            double timePerPixcel =  (double)(4 * beat) / (double)bar;
            double time  = scorePos + ((pictureBox1.Height - startBar - noteY) * timePerPixcel);
            int side = (noteX > pictureBox1.Width / 2) ? 1 : 0;

            //使われていないノートを探す
            for (num = 0; notes[num].mTime != -1; num++) {
                //かぶってたら無視
                if (notes[num].mTime >= (int)time - 10 && notes[num].mTime <= (int)time + 10 && notes[num].mSide == side)
                {
                    return;
                }
            };

            notes[num].mTime = (int)time;
            notes[num].mSide = side;
            notes[num].mPosX = 0;

            switch (notetype.Text)
            {
                case "nomal" :
                    notes[num].mType = 0;
                    break;
                case "holdS" :
                    notes[num].mType = 1;
                    break;
                case "holdE":
                    notes[num].mType = 2;
                    break;
                case "slideL":
                    notes[num].mType = 3;
                    break;
                case "slideR":
                    notes[num].mType = 4;
                    break;
                case "touch":
                    notes[num].mType = 5;
                    //if (notes[num].mSide == 0)
                        notes[num].mPosX = noteX /*- pictureBox1.Width / 4*/;
                    //else
                    //  notes[num].mPosX = noteX - pictureBox1.Width * 3 / 4;
                    break;
                case "holdE_L":
                    notes[num].mType = 6;
                    break;
                case "holdE_R":
                    notes[num].mType = 7;
                    break;
                default:
                    break;
            }
        }

        private void DeleteNote()
        {
            int num;
            double beat = 60000.0 / (double)bpm.Value;
            double timePerPixcel = (double)(4 * beat) / (double)bar;
            for (num = 0; notes[num].mTime != -1; num++)
            {
                double time = scorePos + ((pictureBox1.Height - startBar - noteY) * timePerPixcel);
                int side = (noteX > pictureBox1.Width / 2) ? 1 : 0;
                //クリックした位置にノートがあるか
                if (notes[num].mTime > (int)time - 10 && notes[num].mTime < (int)time + 10 && notes[num].mSide == side)
                {
                    notes[num].mTime = -1;
                    //ノートを詰める
                    int i;
                    for (i = num + 1; notes[i].mTime != -1; i++)
                    { 
                        notes[i - 1].mTime = notes[i].mTime;
                        notes[i - 1].mSide = notes[i].mSide;
                        notes[i - 1].mType = notes[i].mType;
                        notes[i - 1].mPosX = notes[i].mPosX;
                    }
                    notes[i-1].mTime = -1;
                    break;
                }
            }
        }


    }
}
