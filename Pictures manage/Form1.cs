using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictures_manage
{
    public partial class Form1 : Form
    {
        string[] groups = { "Тишо", "Бойко", "Ради", "Мими", "Георги", "Вики", "BB8"}; // имена на папките, трябва да се параметризира
        public long lCurrID;
        public string[] gFiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button bb;
            Button[] b = new Button[20];
            
            for (int i = 0; i < groups.Length; i++)
            {
                bb= new Button();
                b[i] = bb;
                bb.Name  =  groups[i];
                bb.Text = bb.Name;

                bb.Left = 880;
                bb.Top = i * 24 + 130;
                bb.Width = 130;

                Controls.Add(b[i]);

                b[i].Click += new System.EventHandler(this.But_Click);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            fbd.ShowDialog();
            lPath.Text = fbd.SelectedPath;

            string[] fileEntries = Directory.GetFiles(lPath.Text, "*.jpg");

            gFiles = fileEntries;
            LoadPicture(0);
        }

        private void LoadPicture(long ID)
        {   // зарежда поредната снимка
            lCurrID = ID;
            lCurrFile.Text = gFiles[ID];
            pic.Load(lCurrFile.Text);
            lProgress.Text = (lCurrID+1) + "/" + gFiles.Length;
        }

        private void But_Click(object sender, EventArgs e)
        {   // копира показаната картинка в избраната папка
            string sFullPath;
            string sCurName;

            Button clickedButton = (Button)sender;
            sFullPath = Path.Combine(lPath.Text, clickedButton.Name);
            if (!Directory.Exists(sFullPath))
            {
                Directory.CreateDirectory(sFullPath);
            }

            sCurName=Path.GetFileName(lCurrFile.Text);
            File.Copy(Path.Combine(lPath.Text, sCurName), Path.Combine(sFullPath, sCurName));
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            if (lCurrID < gFiles.Length-1)
                LoadPicture(++lCurrID);
        }

        private void bLeft_Click(object sender, EventArgs e)
        {
            if (lCurrID > 0)
                LoadPicture(--lCurrID);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                bLeft.PerformClick();
            }
            if (e.KeyCode == Keys.X)
            {
                bRight.PerformClick();
            }
            if (e.KeyCode == Keys.C)
            { 
                //тук трябва да се трие снимката
            }

        }

        private void lPath_Click(object sender, EventArgs e)
        {

        }
    }
}
