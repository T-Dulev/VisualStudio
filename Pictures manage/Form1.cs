using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace PicturesManage
{
    public partial class Form1 : Form
    {
        //string[] groups = { "Тишо", "Бойко", "Ради", "Мими", "Георги", "Вики", "BB8" }; // имена на папките, трябва да се параметризира
        string[] groupButtons = new string[20];
        string groupsList = "";
        public long lCurrID;
        public string[] gFiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            labelVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // зареждане на групите
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count != 0)
            {
                foreach (var key in appSettings.AllKeys)
                {
                    //Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    listBoxProfiles.Items.Add(key);
                }

                if (listBoxProfiles.Items.Count == 0)
                {
                    listBoxProfiles.Items.Add("-- няма групи --");
                }
                else
                {
                    listBoxProfiles.SetSelected(0, true);
                    btnLoadList.PerformClick();
                }
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
            lProgress.Text = (lCurrID + 1) + "/" + gFiles.Length;
        }

        private void But_Click(object sender, EventArgs e)
        {   // копира показаната картинка в избраната папка
            if (lPath.Text != "")
            {
                string sFullPath;
                string sCurName;

                Button clickedButton = (Button)sender;
                sFullPath = Path.Combine(lPath.Text, clickedButton.Name);
                if (!Directory.Exists(sFullPath))
                {
                    Directory.CreateDirectory(sFullPath);
                }

                sCurName = Path.GetFileName(lCurrFile.Text);
                if (sCurName != "")
                    File.Copy(Path.Combine(lPath.Text, sCurName), Path.Combine(sFullPath, sCurName));
            }
        }

        private void bRight_Click(object sender, EventArgs e)
        {
            if (lCurrID < gFiles.Length - 1)
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

        private void btnNewList_Click(object sender, EventArgs e)
        {
            string newList = "";
            Class1.InputBox("Папки", "Въведи име на нова група от папки", ref newList);
            listBoxProfiles.Items.Add(newList);

            //string sAttr;
            //sAttr = ConfigurationManager.AppSettings.Get("Key0");

            Class1.AddUpdateAppSettings(newList, "");

        }


        private void buttonDeleteList_Click(object sender, EventArgs e)
        {
            string selectedItem = (string)listBoxProfiles.SelectedItem;
            listBoxProfiles.Items.Remove(selectedItem);

            var appSettings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appSettings.AppSettings.Settings.Remove(selectedItem);
            appSettings.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            // изтриване на бутоните от предишно избраната група
            for (int i = 0; i < groupButtons.Length; i++)
            {
                if (groupButtons[i] != null && groupButtons[i] != "")
                {
                    Control[] findButton = Controls.Find(groupButtons[i], false);
                    Controls.Remove(findButton[0]);
                }
            }

            // зареждане на бутоните от избраната група
            var appSettings = ConfigurationManager.AppSettings;
            string selectedItem = (string)listBoxProfiles.SelectedItem;
            string buttonsList = appSettings[selectedItem];

            panelSelectedGroup.Text = selectedItem;
            groupsList = buttonsList;
            groupButtons = buttonsList.Split(',');

            if (groupButtons.Length != 0 && groupButtons[0] != "")
            {
                for (int i = 0; i < groupButtons.Length; i++)
                {
                    var bb = new Button();
                    bb.Name = groupButtons[i];
                    bb.Text = bb.Name;

                    bb.Left = 880;
                    bb.Top = i * 24 + 145;
                    bb.Width = 130;

                    Controls.Add(bb);

                    bb.Click += new System.EventHandler(this.But_Click);
                }
            }

        }

        private void buttonNewFolder_Click(object sender, EventArgs e)
        {
            string newFolder = "";
            Class1.InputBox("Папки", "Въведи име на нова папка в групата", ref newFolder);

            if (newFolder != "")
            {
                if (groupsList == "")
                {
                    groupsList = newFolder;
                }
                else
                {
                    groupsList += "," + newFolder;
                }

                // запазване на списъка с папки
                Class1.AddUpdateAppSettings(panelSelectedGroup.Text, groupsList);

                groupButtons = groupsList.Split(',');

                // зареждане на нов бутон
                var bb = new Button();
                bb.Name = newFolder;
                bb.Text = bb.Name;

                bb.Left = 880;
                bb.Top = (groupButtons.Length - 1) * 24 + 145;
                bb.Width = 130;

                Controls.Add(bb);

                bb.Click += new System.EventHandler(this.But_Click);
            }
        }
    }
}
