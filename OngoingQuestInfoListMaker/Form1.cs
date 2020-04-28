using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OngoingQuestInfoListMaker
{
    public partial class Form1 : Form
    {
        private const string version = "0.1";
        public Form1()
        {
            InitializeComponent();
            this.Text += " v"+ version;
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            // デフォルトのフォルダを指定する
            ofDialog.InitialDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

            //ダイアログのタイトルを指定する
            ofDialog.Title = "questid2display.txtを選択して下さい";
            ofDialog.FileName = "questid2display.txt";
            ofDialog.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";

            //ダイアログを表示する
            if (ofDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Reader[] db = {
                new questid2displayReader(ofDialog.FileName)
            };
            Dictionary<int, Item> dic = new Dictionary<int, Item>();
            foreach (Reader reader in db)
            {
                reader.AddInfo(dic);
            }
            Writer wr = new Writer(Directory.GetParent(ofDialog.FileName).FullName + "\\OngoingQuestInfoList_Sakray.lub");
            wr.Write(dic, true);
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}
