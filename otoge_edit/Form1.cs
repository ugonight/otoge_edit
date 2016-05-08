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
        //変数の宣言
        string DataFileName = "";   //譜面データファイル
        string DataDirectry = "";   //譜面データがあるディレクトリ
        File file = new File();
        int SHandleMusic = 0, SHandleDemo = 0,SHandlePlay = 0;
        int SHSE;
        File.DATA data = new File.DATA();
        int totalTime = 0;
        int scorePos = 0; //譜面の位置(ミリ秒)。スクロールバーの逆。
        public struct NOTE  //ノート情報構造体
        {
            public int mTime;                          // 降ってくるタイミング
            public int mSide;                          // サイド
            public int mType;                          // タイプ
            public int mPosX;                          // X座標
        };
        public const int note_num = 1919;
        NOTE[] notes = new NOTE[note_num];    //記録されているノート

        public Form1()
        {
            InitializeComponent();
            //this.ClientSize = new Size(800, 600);
            DX.SetUseDirectInputFlag(0);
            DX.SetUserWindow(pictureBox1.Handle); //DxLibの親ウインドウをこのフォームウインドウにセット
            DX.DxLib_Init();
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            SetEnable();

            //ダブルバッファ
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            for (int i = 0; i < note_num; i++) notes[i].mTime = -1;

            //効果音
            SHSE = DX.LoadSoundMem("se.ogg");
            DX.ChangeVolumeSoundMem(150, SHSE);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DX.DxLib_End();
        }
        public void MainLoop()
        {
            //if (DX.ScreenFlip() == 0 && DX.ProcessMessage() == 0 && DX.ClearDrawScreen() == 0)
            //{
                //ループする関数
                //描画、FPS管理等ここで
                update();
                //draw();
                pictureBox1.Invalidate();
            //}

            //System.Threading.Thread.Sleep(10);
        }

        private void 開くOToolStripButton_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "data.txt";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            //ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter =
                "譜面データファイル(data.txt)|data.txt|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 1;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                Console.WriteLine(ofd.FileName);
                DataFileName = ofd.FileName;
                DataDirectry = System.IO.Path.GetDirectoryName(ofd.FileName);


                file.GetData(DataFileName, ref data);

                bpm.Value = (int)data.fBpm;
                title.Text = data.mTitle;
                genre.Text = data.mGenre;
                artist.Text = data.mArtist;
                jaketName.Text = System.IO.Path.GetFileName(data.mJaket);
                jaket.ImageLocation = data.mJaket;
                musicName.Text = System.IO.Path.GetFileName(data.mMusic);
                SHandleMusic = DX.LoadSoundMem(data.mMusic);
                SHandlePlay = DX.LoadSoundMem(data.mMusic);
                demoName.Text = System.IO.Path.GetFileName(data.mDemo);
                SHandleDemo = DX.LoadSoundMem(data.mDemo);
                levelName.Text = data.mLevel[(int)level.Value - 1];
                totalTime = DX.GetSoundTotalTime(SHandleMusic);
                vScrollBar1.Maximum = totalTime;
                vScrollBar1.Value = totalTime;

                SetEnable();
            }
        }

        private void musicPlay_Click(object sender, EventArgs e)
        {
            if (DX.CheckSoundMem(SHandleMusic) == 1)
            {
                DX.StopSoundMem(SHandleMusic);
                musicPlay.Text = "再生";
            }
            else {
                DX.StopSoundMem(SHandleDemo);
                demoPlay.Text = "再生";
                DX.PlaySoundMem(SHandleMusic, DX.DX_PLAYTYPE_LOOP);
                musicPlay.Text = "停止";
            }
        }

        private void demoPlay_Click(object sender, EventArgs e)
        {
            if (DX.CheckSoundMem(SHandleDemo) == 1)
            {
                DX.StopSoundMem(SHandleDemo);
                demoPlay.Text = "再生";
            }
            else
            {
                DX.StopSoundMem(SHandleMusic);
                musicPlay.Text = "再生";
                DX.PlaySoundMem(SHandleDemo, DX.DX_PLAYTYPE_LOOP);
                demoPlay.Text = "停止";
            }
        }

        private void level_ValueChanged(object sender, EventArgs e)
        {
            levelName.Text = data.mLevel[(int)level.Value - 1];
            SetEnable();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            draw(e.Graphics);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            scorePos = totalTime - vScrollBar1.Value;
            pictureBox1.Invalidate();
        }

        private void Cursor_Click(object sender, EventArgs e)
        {
            Cursor.Checked = true;
            pencil.Checked = false;
            eraser.Checked = false;
        }

        private void pencil_Click(object sender, EventArgs e)
        {
            Cursor.Checked = false;
            pencil.Checked = true;
            eraser.Checked = false;
        }

        private void eraser_Click(object sender, EventArgs e)
        {
            Cursor.Checked = false;
            pencil.Checked = false;
            eraser.Checked = true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //ロード
            file.GetNotes(DataDirectry + "/humen" + ((int)level.Value - 1).ToString() + ".hmn", ref notes);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pencil.Checked == true)
            {
                SetNote();
            }else if (eraser.Checked == true)
            {
                DeleteNote();
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            DX.StopSoundMem(SHandlePlay);
        }

        private void play_Click(object sender, EventArgs e)
        {
            DX.SetCurrentPositionSoundMem((int)(44.100 * scorePos),SHandlePlay);
            DX.PlaySoundMem(SHandlePlay, DX.DX_PLAYTYPE_BACK,0);
        }

        private void saveScore_Click(object sender, EventArgs e)
        {
            //セーブ
            file.saveNotes(DataDirectry + "/humen" + ((int)level.Value - 1).ToString() + ".hmn", ref notes);
        }

        private void initialPlay_Click(object sender, EventArgs e)
        {
            DX.PlaySoundMem(SHandlePlay, DX.DX_PLAYTYPE_BACK);
        }

        private void SetEnable()
        {
            if (DataFileName == "")
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }

            if (SHandleMusic == 0)
            {
                musicPlay.Enabled = false;
            }  else  {
                musicPlay.Enabled = true;
            }

            if (SHandleDemo == 0)
            {
                demoPlay.Enabled = false;
            }
            else
            {
                demoPlay.Enabled = true;
            }

            loadScore.Enabled = System.IO.File.Exists(DataDirectry + "/humen" + ((int)level.Value - 1).ToString() + ".hmn");
        }
    }
}
