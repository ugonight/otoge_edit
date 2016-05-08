using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace otoge_edit
{

    

    class File
    {
        public const int DATA_N = 9;

        public const double GAME_W = 854;
        public const double PICTUREBOX_W = 480;

        public struct DATA
        {
            public string mGenre;                // データのジャンル
            public string mTitle;                // データのタイトル
            public string mArtist;               // データの製作者
            public float fBpm;                       // データのテンポ（初期値は130）
            public string mDemo;                    // デモ音源
            public string mMusic;               // 音源
            public string mJaket;               // ジャケット画像
            public string[] mLevel;             // レベル毎の名称
            public string[] mScore;				// 譜面ファイル
	    }

        public bool GetData(string fileName,ref DATA data)
        {
            //int FileHandle = DX.FileRead_open(fileName);
            System.IO.StreamReader sr = new System.IO.StreamReader(
    fileName,
    System.Text.Encoding.GetEncoding("shift_jis"));

            string s, d;
            s = fileName;
            d = System.IO.Path.GetDirectoryName(fileName);

            InitData(ref data);

            string buf;

            while (true)
            {
                //DX.FileRead_gets(buf, 1024, FileHandle);
                buf = sr.ReadLine();
                if (sr.Peek() == -1)
                    break;
                if (buf == "" ||  buf[0] != '#')
                    continue;

                int com = GetCommand(buf);
                string str = "";
                if (!GetCommandString(buf, ref str))
                {      // 文字列の取得が失敗なら
                    //DX.FileRead_close(FileHandle);
                    sr.Close();
                    return false;
                }

                int level = 0;
                string name = "";
                string[] values;
                switch (com)
                {
                    //case 0: // PLAYER
                    //	data. = atoi(str);
                    //	break;
                    case 0: // GENRE
                        data.mGenre = str;
                        break;
                    case 1: // TITLE
                        data.mTitle= str;
                        break;
                    case 2: // ARTIST
                        data.mArtist= str;
                        break;
                    case 3: // BPM
                        data.fBpm = float.Parse(str);
                        break;
                    case 4: // DEMO  
                        data.mDemo = d + "/" + str; //ディレクトリ/ファイル名
                        break;
                    case 5: // MUSIC
                        data.mMusic= d + "/" + str;
                        break;
                    case 6: // JAKET
                        data.mJaket= d + "/" + str;
                        break;
                    case 7: // LEVEL
                        values = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        level = int.Parse(values[0]);
                        name = values[1];
                        data.mLevel[level] = name;
                        break;
                    case 8: // SCORE
                        values = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        level = int.Parse(values[0]);
                        name = values[1];
                        data.mScore[level] = d + name;
                        break;
                }
            }
            sr.Close();
            return true;
        }

        private int GetCommand(string s)
        {
            string[] command = new string[DATA_N]{
              "GENRE",
              "TITLE",
              "ARTIST",
              "BPM",
              "DEMO",
              "MUSIC",
              "JAKET",
              "LEVEL",
              "SCORE"
           };

            //s++;  //'#'の次へ
            //string str = s.ToString();

            // 検索ルーチン
            int i;
            for (i = 0; i < DATA_N; i++)
            {
                string str = s.Substring(1, command[i].Length);
                if (str == command[i])
                    return i;       // コマンドならその番号を返す
            }

            // オブジェ配置なら -1
            return -1;
        }

        private bool GetCommandString(string src, ref String dst)
        {
            int i;
            i = 0;
            // まずソースデータからデータ部分までのポインタを算出
            while (true)
            {
                if (src[i] == ' ' || src[i] == 0x09 || src[i] == ':')
                {
                    i++;
                    break;
                }
                if (src[i] == '\n' || src[i] == '\0' || i > src.Length)
                {
                    return false;
                }
                i++;
            }

            // 終端までをコピー
            //while (true)
            //{
            //    if (src[i] == '\n' || src[i] == null)
            //        break;
            //    dst[j] = src[i];
            //    i++;
            //    j++;
            //}
            //dst[j] = NULL;
            string str = src.ToString();
            dst = str.Substring(i);
            return true;
        }


        public void InitData(ref DATA data)
        {
            data.mGenre = "";
            data.mTitle = "";
            data.mArtist = "";
            data.fBpm = 120;
            data.mDemo = "";
            data.mMusic = "";
            data.mJaket = "";
            data.mLevel = new string[4];
            data.mLevel[0] = "レベル1";
            data.mLevel[1] = "レベル2";
            data.mLevel[2] = "レベル3";
            data.mLevel[3] = "レベル4";
            data.mScore = new string[4];
            data.mScore[0] = "";
            data.mScore[1] = "";
            data.mScore[2] = "";
            data.mScore[3] = "";
        }

        //ファイルからノートをロードする
        public bool GetNotes(string fileName, ref Form1.NOTE[] note) {
            System.IO.StreamReader sr = new System.IO.StreamReader(
   fileName,
   System.Text.Encoding.GetEncoding("shift_jis"));

            string buf;
            string[] values;
            int num=0;

            while (true)
            {
                buf = sr.ReadLine();
                if (sr.Peek() == -1)
                    break;
                if (buf == "\n")    //空行は飛ばす
                    continue;
                
                values = buf.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                note[num].mTime = int.Parse(values[0]) / 1000;  //マイクロ秒をミリ秒に直す
                note[num].mSide = int.Parse(values[1]);
                note[num].mType = int.Parse(values[2]);
                if (note[num].mType == 5)
                {
                    note[num].mPosX = (int)((double.Parse(values[3]) / GAME_W) * PICTUREBOX_W);
                }
                else
                {
                    note[num].mPosX = 0;
                }

                num++;
            }
            sr.Close();
            
            //使われていない要素を無効にする
            for (int i = num; i < Form1.note_num; i++)
            {
                note[i].mTime = -1;
            }

            return true;
        }

        //ノートをファイルに保存する
        public bool saveNotes(string fileName, ref Form1.NOTE[] note)
        {
   

            System.IO.StreamWriter sw = new System.IO.StreamWriter(
     fileName,
     false,
     System.Text.Encoding.GetEncoding("shift_jis"));
            int num,posX;
            for (num = 0; note[num].mTime != -1; num++)
            {
                //x座標をゲーム座標に変換
                 posX = (note[num].mType == 5) ? (int)((note[num].mPosX / PICTUREBOX_W) * GAME_W) : 0;

                sw.WriteLine(note[num].mTime * 1000 + "," + note[num].mSide + "," + note[num].mType + "," + posX);
            }
            posX = (note[num].mType == 5) ? (int)((note[num].mPosX / PICTUREBOX_W) * GAME_W) : 0;
            sw.WriteLine(note[num].mTime * 1000 + "," + note[num].mSide + "," + note[num].mType + "," + posX);

            sw.Close();

            return true;
        }

        }
}
