using System;
using System.Windows.Forms;

namespace LDD_Calculator
{
    public partial class MainForm : Form
    {
        Button[] btns = new Button[3];

        public MainForm()
        {
            InitializeComponent();

            btns[0] = btn_calc_weight;
            btns[1] = btn_gen;
            btns[2] = btn_calc_cost;
            TurnOnInteractables();
        }

        public void TurnOnInteractables()
        {
            this.ControlBox = true;
            foreach (Button btn in btns)
            {
                btn.Enabled = true;
            }
        }

        private void TurnOffInteractables()
        {
            this.ControlBox = false;
            foreach (Button btn in btns)
            {
                btn.Enabled = false;
            }
        }

        private void btn_gen_Click(object sender, EventArgs e)
        {
            GenForm genForm = new GenForm(this);
            genForm.TopMost = true;
            genForm.Show();
            TurnOffInteractables();
        }

        private void btn_calc_weight_Click(object sender, EventArgs e)
        {
            CalcWeightForm calcWeightForm = new CalcWeightForm(this);
            calcWeightForm.TopMost = true;
            calcWeightForm.Show();
            TurnOffInteractables();
        }

        private void btn_calc_cost_Click(object sender, EventArgs e)
        {
            CalcCostForm calcCostForm = new CalcCostForm(this);
            calcCostForm.TopMost = true;
            calcCostForm.Show();
            TurnOffInteractables();
        }
    }
}
