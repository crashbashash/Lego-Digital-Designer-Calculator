using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;

namespace LDD_Calculator
{
    public partial class GenForm : Form
    {
        Button[] btns = new Button[3];
        TextBox[] txts = new TextBox[2];

        MainForm mainForm;

        Thread genThread;

        public string ogTitle;

        public GenForm(MainForm _mainForm)
        {
            mainForm = _mainForm;
            InitializeComponent();
            ogTitle = this.Text;

            btns[0] = btn_close;
            btns[1] = btn_open_ldd_proj;
            btns[2] = btn_save;
            txts[0] = txt_ldd_proj_path;
            txts[1] = txt_save_guide;

            TurnOnInteractables();
        }

        private void RequestBuildGuide()
        {
            openFileDialogue.Title = "Open LDD HTML Build Guide";
            openFileDialogue.Filter = "HTML Files|*.html|HTM Files|*.htm";
            openFileDialogue.FileName = "LDD HTML Build Guide File.html";
            if (openFileDialogue.ShowDialog() == DialogResult.OK)
            {
                txt_ldd_proj_path.Text = openFileDialogue.FileName;
            }
        }

        private void RequestSaveLocation()
        {
            saveFileDialogue.Title = "Save Formatted LDD HTML Build Guide";
            saveFileDialogue.Filter = "TXT Files|*.txt";
            saveFileDialogue.FileName = "Formatted LDD HTML Build Guide.txt";
            if (saveFileDialogue.ShowDialog() == DialogResult.OK)
            {
                txt_save_guide.Text = saveFileDialogue.FileName;
            }
        }

        private void TurnOnInteractables()
        {
            foreach (Button btn in btns)
            {
                ChangeCtrlEnabled(btn, true);
            }

            foreach (TextBox txt in txts)
            {
                ChangeCtrlEnabled(txt, true);
            }
            ChangeCtrlText(btn_gen_weights, "Generate Block Weights");
            ChangeCtrlText(this, ogTitle);
        }

        private void TurnOffInteractables()
        {
            foreach (Button btn in btns)
            {
                ChangeCtrlEnabled(btn, false);
            }

            foreach (TextBox txt in txts)
            {
                ChangeCtrlEnabled(txt, false);
            }
            ChangeCtrlText(btn_gen_weights, "STOP");
        }

        public delegate void ChangeCtrlTextDelegate(Control _ctrl, string _text);
        public delegate void ChangeCtrlEnabledDelegate(Control _ctrl, bool _enabled);

        public static void ChangeCtrlText(Control _ctrl, string _text)
        {
            if (_ctrl.InvokeRequired)
            {
                ChangeCtrlTextDelegate del = new ChangeCtrlTextDelegate(ChangeCtrlText);
                _ctrl.Invoke(del, _ctrl, _text);
            }
            else
            {
                _ctrl.Text = _text;
            }
        }
        public static void ChangeCtrlEnabled(Control _ctrl, bool _enabled)
        {
            if (_ctrl.InvokeRequired)
            {
                ChangeCtrlEnabledDelegate del = new ChangeCtrlEnabledDelegate(ChangeCtrlEnabled);
                _ctrl.Invoke(del, _ctrl, _enabled);
            }
            else
            {
                _ctrl.Enabled = _enabled;
            }
        }

        //Gen Block Weights Info
        public void Gen_info_thread(string _buildLoc, string _saveLoc)
        {
            ChromeDriver _chromeDriver = new ChromeDriver();

            ChangeCtrlText(this , string.Format("{0} - Started...", ogTitle));

            _chromeDriver.Url = _buildLoc;

            IWebElement stepNumber = _chromeDriver.FindElementById("stepNumber");

            stepNumber.SendKeys("999999999" + OpenQA.Selenium.Keys.Return);

            Dictionary<string, string> blockInfo = new Dictionary<string, string>();

            ChangeCtrlText(this , string.Format("{0} - Generating block info", ogTitle));

            IWebElement stepElementsDiv = _chromeDriver.FindElement(By.XPath("//div[@class='stepelements']"));
            IList<IWebElement> allBiElements = stepElementsDiv.FindElements(By.XPath("div"));

            for (int i = 0; i < allBiElements.Count - 1; i++)
            {
                ChangeCtrlText(this , string.Format("{0} - Processing block {1}/{2} - From build guide \"{3}\"", ogTitle, i, allBiElements.Count, _buildLoc));
                IWebElement biElem = allBiElements[i];

                IList<IWebElement> allTds = biElem.FindElements(By.XPath("table/tbody/tr/td"));

                string[] seperator = { " - " };
                string name = allTds[3].Text.Split(seperator, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                string amount = allTds[0].Text.Replace("x", "");

                try
                {
                    blockInfo.Add(name, amount);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    string value = "";
                    blockInfo.TryGetValue(name, out value);
                    string newValue = (int.Parse(amount) + int.Parse(value)).ToString();

                    blockInfo.Remove(name);
                    blockInfo.Add(name, newValue);
                }
            }

            ChangeCtrlText(this , string.Format("{0} - Storing information to \"{1}\"", ogTitle, _saveLoc));

            string allBlockInfo = "";

            foreach (KeyValuePair<string, string> block in blockInfo)
            {
                allBlockInfo += string.Format("{0} | {1}\n", block.Key, block.Value);
            }

            try
            {
                StreamWriter sw = new StreamWriter(_saveLoc);

                sw.Write(allBlockInfo);
                sw.Close();
                ChangeCtrlText(this , string.Format("{0} - Finished writing information to \"{1}\"", ogTitle, _saveLoc));
                MessageBox.Show("Successfully written all block information to " + _saveLoc, "Saved successfully!!!");
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error: {0}", e.Message), "Failed to write to file!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChangeCtrlText(this, ogTitle);

            //Cleanup
            _chromeDriver.Close();
            TurnOnInteractables();
            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
            {
                proc.CloseMainWindow();
            }
            TurnOnInteractables();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            mainForm.TurnOnInteractables();
            this.Close();
        }

        private void Btn_open_ldd_proj_Click(object sender, EventArgs e)
        {
            RequestBuildGuide();
        }

        private void Txt_ldd_proj_path_DoubleClick(object sender, EventArgs e)
        {
            RequestBuildGuide();
        }

        private void Txt_save_guide_DoubleClick(object sender, EventArgs e)
        {
            RequestSaveLocation();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            RequestSaveLocation();
        }

        private void Btn_gen_weights_Click(object sender, EventArgs e)
        {
            if (btn_gen_weights.Text.ToLower() == "stop") //Stop generating weights
            {
                genThread.Abort();
                TurnOnInteractables();

                foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                {
                    proc.CloseMainWindow();
                }
            }
            else //Start generating weights
            {
                if (txt_ldd_proj_path.Text != "" && txt_save_guide.Text != "")
                {
                    TurnOffInteractables();
                    genThread = new Thread(() => Gen_info_thread(txt_ldd_proj_path.Text, txt_save_guide.Text));
                    genThread.Start();
                }
            }
        }
    }
}
