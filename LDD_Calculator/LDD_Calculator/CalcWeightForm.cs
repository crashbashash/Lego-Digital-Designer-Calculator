using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace LDD_Calculator
{
    public partial class CalcWeightForm : Form
    {
        MainForm mainForm;

        Control[] interactables = new Control[5];

        Thread CalcThread;

        public string ogTitle;

        public CalcWeightForm(MainForm _mainForm)
        {
            mainForm = _mainForm;
            InitializeComponent();
            ogTitle = this.Text;

            interactables[0] = btn_close;
            interactables[1] = btn_open_block_info;
            interactables[2] = btn_save_weights;
            interactables[3] = txt_block_info_path;
            interactables[4] = txt_weight_info_path;

            TurnOnInteractables();

            tTip_assumed_weight.SetToolTip(txt_assumed_weight, "Assumed Weight of block\n\n" +
                "Used if the weight of a block cannot be found\n\nDefault value = 0.5g\n\n" +
                "Value must be greater than 0g");
        }

        private void RequestOpenBlockInfo()
        {
            openFileDialog.Title = "Open Block Information Text File";
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.FileName = "BlockInfo";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_block_info_path.Text = openFileDialog.FileName;
            }
        }

        private void RequestSaveWeightInfo()
        {
            saveFileDialog.Title = "Save Weight Information File";
            saveFileDialog.Filter = "Block Weight File|*.wfile";
            saveFileDialog.FileName = "BlocksWeight";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_weight_info_path.Text = saveFileDialog.FileName;
            }
        }

        private void TurnOffInteractables()
        {
            foreach (Control ctrl in interactables)
            {
                ChangeCtrlEnabled(ctrl, false);
            }
            ChangeCtrlText(btn_gen_weights, "STOP");
        }

        private void TurnOnInteractables()
        {
            foreach (Control ctrl in interactables)
            {
                ChangeCtrlEnabled(ctrl, true);
            }
            ChangeCtrlText(btn_gen_weights, "Generate Projects Weight");
            ChangeCtrlText(this, ogTitle);
        }

        private float GetPercentageComplete (float curAmount, float totalAmount)
        {
            try
            {
                return 100-(((totalAmount - curAmount) / totalAmount) *100);
            }
            catch
            {
                return 0;
            }
        }

        //Weight calculation thread
        private void CalcWeightThread(string _blockInfoPath, string _saveInfoPath, float _assumedWeight=0.5f, float _percentSim=50f)
        {
            Dictionary<string, string> blockInfo = new Dictionary<string, string>();
            string line;
            int blockTypeCount = 0;
            int blockCount = 0;

            ChangeCtrlText(this, string.Format("{0} - Getting project information - Block Types: {1} - Blocks: {2}", ogTitle, blockTypeCount, blockCount));

            StreamReader blockInfoFile = new StreamReader(_blockInfoPath);
            while((line = blockInfoFile.ReadLine()) != null)
            {
                string[] info = line.Split('|');
                blockInfo.Add(info[0].Trim(), info[1].Trim());
                blockCount += int.Parse(info[1].Trim());
                blockTypeCount++;
                ChangeCtrlText(this, string.Format("{0} - Getting project information - Block Types: {1} - Blocks: {2}", ogTitle, blockTypeCount, blockCount));
            }

            ChangeCtrlText(this, string.Format("{0} - Navigating to \'www.bricklinks.com\'", ogTitle));
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://www.bricklink.com");

            ChangeCtrlText(this, string.Format("{0} - Gathering weight information for project", ogTitle));

            int curBlockTypeCount = 0;
            int curBlockCount = 0;
            float currentWeight = 0f;
            Dictionary<string, string> weightInfo = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> block in blockInfo)
            {
                try
                {
                    IWebElement cookiesElem = chromeDriver.FindElement(By.CssSelector("[class='bl-btn primaryBlue text--bold l-margin-right']"));
                    cookiesElem.Click();
                }catch { }
                float blockWeight = 0;
                ChangeCtrlText(this, string.Format("{0} - Gathering weight information for project - Block Types: {1}/{2} - Blocks: {3}/{4} - Project Weight: {5}g", ogTitle, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentWeight));

                chromeDriver.Navigate().GoToUrl(string.Format("https://www.bricklink.com/v2/search.page?q={0}", block.Key));

                bool loop = true;
                while (loop)
                {
                    IWebElement elem = chromeDriver.FindElement(By.Id("_idSelSortType"));
                    if (elem != null && elem.Displayed && elem.Enabled)
                    {
                        loop = false;
                    }
                    else
                    {
                        IList<IWebElement> elemList = chromeDriver.FindElements(By.ClassName("links"));
                        foreach (IWebElement temp in elemList)
                        {
                            if (temp.Text == "How to Find Items")
                            {
                                if(temp.Displayed && temp.Enabled)
                                {
                                    loop = false;
                                }
                            }
                        }
                    }
                }
                
                try
                {
                    IList<IWebElement> itemListElem = chromeDriver.FindElements(By.ClassName("pspItemNameLink"));
                    int count = 0;
                    bool loopItemList = true;
                    string newBlockName = block.Key.ToLower().Replace(" ", "");
                    int newBlockNameLen = newBlockName.Length;
                    while (loopItemList)
                    {
                        string newElemText = itemListElem[count].Text.ToLower().Replace(" ", "");
                        int newElemTextLen = newElemText.Length;
                        if (itemListElem[count].Text != "" && newElemText.Contains(newBlockName) && GetPercentageComplete(newBlockNameLen, newElemTextLen) > _percentSim)
                        {
                            itemListElem[count].Click();
                            loopItemList = false;
                        }
                        count++;
                    }

                    string tempWeightInfo = chromeDriver.FindElement(By.Id("item-weight-info")).Text;

                    if (!tempWeightInfo.Contains("?"))
                        blockWeight = float.Parse(tempWeightInfo.Replace("g", ""));
                    else
                        blockWeight = _assumedWeight;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    blockWeight = _assumedWeight;
                }

                currentWeight += blockWeight * float.Parse(block.Value);
                weightInfo.Add(block.Key, blockWeight.ToString()+"g");
                curBlockTypeCount++;
                curBlockCount += int.Parse(block.Value);
            }

            ChangeCtrlText(this, string.Format("{0} - Finished calculating weight of project - Block Types: {1}/{2} - Blocks: {3}/{4} - Project Weight: {5}g", ogTitle, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentWeight));

            string fileText = "";

            foreach (KeyValuePair<string, string> block in weightInfo)
            {
                string blockQuantity;
                blockInfo.TryGetValue(block.Key, out blockQuantity);
                fileText += string.Format("Block: {0} | Quantity: {1} | Weight(ea): {2} | Weight(total): {3}g\n\n", block.Key, blockQuantity, block.Value, float.Parse(block.Value.Replace("g", "")) * float.Parse(blockQuantity));
            }

            ChangeCtrlText(this, string.Format("{0} - Writing information to \'{1}\' - Block Types: {2}/{3} - Blocks: {4}/{5} - Project Weight: {6}g", ogTitle, _saveInfoPath, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentWeight));

            using (StreamWriter writer = new StreamWriter(_saveInfoPath)){
                writer.Write(fileText + string.Format("Total Weight: {0}g", currentWeight));
            }

            ChangeCtrlText(this, string.Format("{0} - Finished writing information to \'{1}\' - Block Types: {2}/{3} - Blocks: {4}/{5} - Project Weight: {6}g", ogTitle, _saveInfoPath, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentWeight));
            MessageBox.Show(string.Format("Block Types: {0}/{1}\n\nBlocks: {2}/{3}\n\nProject Weight: {4}g", curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentWeight), "Finished calculating weight of project");

            //Cleanup boi
            chromeDriver.Close();
            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
            {
                proc.CloseMainWindow();
            }
            TurnOnInteractables();
        }

        public delegate void ChangeCtrlEnabledDelegate(Control _ctrl, bool _enabled);
        public delegate void ChangeCtrlTextDelegate(Control _ctrl, string _text);

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

        private void txt_block_info_path_DoubleClick(object sender, EventArgs e)
        {
            RequestOpenBlockInfo();
        }

        private void btn_open_block_info_Click(object sender, EventArgs e)
        {
            RequestOpenBlockInfo();
        }

        private void txt_weight_info_path_DoubleClick(object sender, EventArgs e)
        {
            RequestSaveWeightInfo();
        }

        private void btn_save_weights_Click(object sender, EventArgs e)
        {
            RequestSaveWeightInfo();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.TurnOnInteractables();
        }

        private void btn_gen_weights_Click(object sender, EventArgs e)
        {
            if (btn_gen_weights.Text.ToLower() == "stop") //Stop running weight calculation
            {
                TurnOnInteractables();
                CalcThread.Abort();
                foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                {
                    proc.CloseMainWindow();
                }
            }
            else //Start running weight calculation
            {
                if (txt_weight_info_path.Text != "" && txt_block_info_path.Text != "")
                {
                    TurnOffInteractables();
                    float assumedWeight = 0f;
                    float.TryParse(txt_assumed_weight.Text, out assumedWeight);
                    if (assumedWeight == 0)
                        CalcThread = new Thread(() => CalcWeightThread(txt_block_info_path.Text, txt_weight_info_path.Text));
                    else
                        CalcThread = new Thread(() => CalcWeightThread(txt_block_info_path.Text, txt_weight_info_path.Text, assumedWeight));
                    CalcThread.Start();
                }
            }
        }
    }
}
