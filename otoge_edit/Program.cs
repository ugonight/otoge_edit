using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

namespace otoge_edit
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            form.Show();
            while (form.Created ) //Application.Runしないで自分でループを作る
            {
                form.MainLoop();
                Application.DoEvents(); //←必要
            }
        }
    }
}
