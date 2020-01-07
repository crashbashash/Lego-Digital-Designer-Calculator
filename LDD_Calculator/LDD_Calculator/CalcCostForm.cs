using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace LDD_Calculator
{
    public partial class CalcCostForm : Form
    {
        MainForm mainForm;

        Control[] interactables = new Control[5];

        Thread CalcThread;

        public string ogTitle;

        public CalcCostForm(MainForm _mainForm)
        {
            mainForm = _mainForm;
            InitializeComponent();
            ogTitle = this.Text;

            interactables[0] = btn_close;
            interactables[1] = btn_open_block_info;
            interactables[2] = btn_save_costs;
            interactables[3] = txt_block_info_path;
            interactables[4] = txt_cost_info_path;

            TurnOnInteractables();

            tTip_assumed_cost.SetToolTip(txt_assumed_cost, "Assumed Cost of block\n\n" +
                "Used if the Cost of a block cannot be found\n\nDefault value = £0.05\n\n" +
                "Value must be greater than £0");
        }

        private void CalcCostThread(string _blockInfoPath, string _saveInfoPath, float _assumedCost = 0.05f, float _percentSim = 50f)
        {
            Dictionary<string, string> blockInfo = new Dictionary<string, string>();
            string line;
            int blockTypeCount = 0;
            int blockCount = 0;

            ChangeCtrlText(this, string.Format("{0} - Getting project information - Block Types: {1} - Blocks: {2}", ogTitle, blockTypeCount, blockCount));

            StreamReader blockInfoFile = new StreamReader(_blockInfoPath);
            while ((line = blockInfoFile.ReadLine()) != null)
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

            ChangeCtrlText(this, string.Format("{0} - Gathering cost information for project", ogTitle));

            int curBlockTypeCount = 0;
            int curBlockCount = 0;
            float currentCost = 0f;
            Dictionary<string, string> costInfo = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> block in blockInfo)
            {
                string blockName = block.Key;
                string blockQuantity = block.Value;

                try
                {
                    IWebElement cookiesElem = chromeDriver.FindElement(By.CssSelector("[class='bl-btn primaryBlue text--bold l-margin-right']"));
                    cookiesElem.Click();
                }
                catch { }
                float blockCost = 0;
                ChangeCtrlText(this, string.Format("{0} - Gathering cost information for project - Block Types: {1}/{2} - Blocks: {3}/{4} - Project cost: £{5}", ogTitle, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentCost));

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
                                if (temp.Displayed && temp.Enabled)
                                {
                                    loop = false;
                                }
                            }
                        }
                    }
                }
                bool fail = true;
                try
                {
                    IList<IWebElement> itemInfoContainers1 = chromeDriver.FindElements(By.CssSelector("[class='pspItemTypeContentsNew pspItemRowEven']"));
                    IList<IWebElement> itemInfoContainers2 = chromeDriver.FindElements(By.CssSelector("[class='pspItemTypeContentsNew pspItemRowOdd']"));

                    List<IWebElement> listItemInfoContainer = new List<IWebElement>(itemInfoContainers1.Count + itemInfoContainers2.Count);
                    listItemInfoContainer.AddRange(itemInfoContainers1);
                    listItemInfoContainer.AddRange(itemInfoContainers2);

                    IList<IWebElement> allIteminfoContainer = listItemInfoContainer;

                    foreach (IWebElement elem in allIteminfoContainer)
                    {
                        if (elem.Text.Replace(" ", "") != "")
                        {
                            string[] lines = elem.Text.Split('\n');
                            string[] itemInfo = lines[1].Split(' ');
                            string price = itemInfo[itemInfo.Length - 1].Replace(" ", "").Replace("+", "");
                            string name = lines[0];
                            
                            if (price != "-" && blockName.Replace(" ", "").ToLower().Contains(name.Replace(" ", "").Replace("\r", "").ToLower()) && GetPercentageComplete(blockName.Length, name.Length) >= _percentSim)
                            {
                                blockCost = float.Parse(price);
                                fail = false;
                                //MessageBox.Show(lines[1] + "\n" + price + "\n" + GetPercentageComplete(blockName.Length, name.Length));
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    blockCost = _assumedCost;
                }

                if (fail)
                    blockCost = _assumedCost;

                currentCost += blockCost * float.Parse(blockQuantity);
                costInfo.Add(blockName, "£" + blockCost.ToString());
                curBlockTypeCount++;
                curBlockCount += int.Parse(blockQuantity);
            }

            ChangeCtrlText(this, string.Format("{0} - Finished calculating weight of project - Block Types: {1}/{2} - Blocks: {3}/{4} - Project Weight: £{5}", ogTitle, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentCost));

            string fileText = "";

            foreach (KeyValuePair<string, string> block in costInfo)
            {
                string blockQuantity;
                blockInfo.TryGetValue(block.Key, out blockQuantity);
                fileText += string.Format("Block: {0} | Quantity: {1} | Cost(ea): {2} | Cost(total): £{3}\n\n", block.Key, blockQuantity, block.Value, float.Parse(block.Value.Replace("£", "")) * float.Parse(blockQuantity));
            }

            ChangeCtrlText(this, string.Format("{0} - Writing information to \'{1}\' - Block Types: {2}/{3} - Blocks: {4}/{5} - Project Weight: £s{6}", ogTitle, _saveInfoPath, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentCost));

            using (StreamWriter writer = new StreamWriter(_saveInfoPath))
            {
                writer.Write(fileText + string.Format("Total Cost: £{0}", currentCost));
            }

            ChangeCtrlText(this, string.Format("{0} - Finished writing information to \'{1}\' - Block Types: {2}/{3} - Blocks: {4}/{5} - Project Cost: £{6}", ogTitle, _saveInfoPath, curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentCost));
            MessageBox.Show(string.Format("Block Types: {0}/{1}\n\nBlocks: {2}/{3}\n\nProject Cost: £{4}", curBlockTypeCount, blockTypeCount, curBlockCount, blockCount, currentCost), "Finished calculating cost of project");

            //Cleanup boi
            chromeDriver.Close();
            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
            {
                proc.CloseMainWindow();
            }
            TurnOnInteractables();
        }

        private float GetPercentageComplete(float curAmount, float totalAmount)
        {
            try
            {
                return 100 - (((totalAmount - curAmount) / totalAmount) * 100);
            }
            catch
            {
                return 0;
            }
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
            saveFileDialog.Title = "Save Cost Information File";
            saveFileDialog.Filter = "Block Cost File|*.cfile";
            saveFileDialog.FileName = "BlocksCost";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_cost_info_path.Text = saveFileDialog.FileName;
            }
        }

        private void TurnOffInteractables()
        {
            foreach (Control ctrl in interactables)
            {
                ChangeCtrlEnabled(ctrl, false);
            }
            ChangeCtrlText(btn_gen_costs, "STOP");
        }

        private void TurnOnInteractables()
        {
            foreach (Control ctrl in interactables)
            {
                ChangeCtrlEnabled(ctrl, true);
            }
            ChangeCtrlText(btn_gen_costs, "Generate Projects Weight");
            ChangeCtrlText(this, ogTitle);
        }

        private void txt_block_info_path_DoubleClick(object sender, EventArgs e)
        {
            RequestOpenBlockInfo();
        }

        private void btn_open_block_info_Click(object sender, EventArgs e)
        {
            RequestOpenBlockInfo();
        }

        private void txt_cost_info_path_DoubleClick(object sender, EventArgs e)
        {
            RequestSaveWeightInfo();
        }

        private void btn_save_cost_Click(object sender, EventArgs e)
        {
            RequestSaveWeightInfo();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.TurnOnInteractables();
        }

        private void btn_gen_cost_Click(object sender, EventArgs e)
        {
            if (btn_gen_costs.Text.ToLower() == "stop") //Stop running weight calculation
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
                if (txt_cost_info_path.Text != "" && txt_block_info_path.Text != "")
                {
                    TurnOffInteractables();
                    float assumedWeight = 0f;
                    float.TryParse(txt_assumed_cost.Text, out assumedWeight);
                    if (assumedWeight == 0)
                        CalcThread = new Thread(() => CalcCostThread(txt_block_info_path.Text, txt_cost_info_path.Text));
                    else
                        CalcThread = new Thread(() => CalcCostThread(txt_block_info_path.Text, txt_cost_info_path.Text, assumedWeight));
                    CalcThread.Start();
                }
            }
        }
    }
}
