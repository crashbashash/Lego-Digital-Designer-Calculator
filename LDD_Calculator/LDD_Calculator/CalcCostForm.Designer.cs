namespace LDD_Calculator
{
    partial class CalcCostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_open_block_info = new System.Windows.Forms.Button();
            this.txt_block_info_path = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_assumed_cost = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_gen_costs = new System.Windows.Forms.Button();
            this.btn_save_costs = new System.Windows.Forms.Button();
            this.txt_cost_info_path = new System.Windows.Forms.TextBox();
            this.tTip_assumed_cost = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_open_block_info
            // 
            this.btn_open_block_info.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open_block_info.Location = new System.Drawing.Point(762, 11);
            this.btn_open_block_info.Name = "btn_open_block_info";
            this.btn_open_block_info.Size = new System.Drawing.Size(75, 32);
            this.btn_open_block_info.TabIndex = 11;
            this.btn_open_block_info.Text = "Open";
            this.btn_open_block_info.UseVisualStyleBackColor = true;
            this.btn_open_block_info.Click += new System.EventHandler(this.btn_open_block_info_Click);
            // 
            // txt_block_info_path
            // 
            this.txt_block_info_path.Location = new System.Drawing.Point(11, 20);
            this.txt_block_info_path.Margin = new System.Windows.Forms.Padding(2);
            this.txt_block_info_path.Name = "txt_block_info_path";
            this.txt_block_info_path.ReadOnly = true;
            this.txt_block_info_path.Size = new System.Drawing.Size(747, 20);
            this.txt_block_info_path.TabIndex = 10;
            this.txt_block_info_path.DoubleClick += new System.EventHandler(this.txt_block_info_path_DoubleClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(515, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Assumed Cost (£)";
            // 
            // txt_assumed_cost
            // 
            this.txt_assumed_cost.Location = new System.Drawing.Point(676, 128);
            this.txt_assumed_cost.Margin = new System.Windows.Forms.Padding(2);
            this.txt_assumed_cost.Name = "txt_assumed_cost";
            this.txt_assumed_cost.ReadOnly = true;
            this.txt_assumed_cost.Size = new System.Drawing.Size(83, 20);
            this.txt_assumed_cost.TabIndex = 16;
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(762, 115);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 32);
            this.btn_close.TabIndex = 15;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_gen_costs
            // 
            this.btn_gen_costs.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gen_costs.Location = new System.Drawing.Point(11, 115);
            this.btn_gen_costs.Name = "btn_gen_costs";
            this.btn_gen_costs.Size = new System.Drawing.Size(250, 32);
            this.btn_gen_costs.TabIndex = 14;
            this.btn_gen_costs.Text = "Generate Projects Weight";
            this.btn_gen_costs.UseVisualStyleBackColor = true;
            this.btn_gen_costs.Click += new System.EventHandler(this.btn_gen_cost_Click);
            // 
            // btn_save_costs
            // 
            this.btn_save_costs.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_costs.Location = new System.Drawing.Point(762, 63);
            this.btn_save_costs.Name = "btn_save_costs";
            this.btn_save_costs.Size = new System.Drawing.Size(75, 32);
            this.btn_save_costs.TabIndex = 13;
            this.btn_save_costs.Text = "Save";
            this.btn_save_costs.UseVisualStyleBackColor = true;
            this.btn_save_costs.Click += new System.EventHandler(this.btn_save_cost_Click);
            // 
            // txt_cost_info_path
            // 
            this.txt_cost_info_path.Location = new System.Drawing.Point(11, 71);
            this.txt_cost_info_path.Margin = new System.Windows.Forms.Padding(2);
            this.txt_cost_info_path.Name = "txt_cost_info_path";
            this.txt_cost_info_path.ReadOnly = true;
            this.txt_cost_info_path.Size = new System.Drawing.Size(747, 20);
            this.txt_cost_info_path.TabIndex = 12;
            this.txt_cost_info_path.DoubleClick += new System.EventHandler(this.txt_cost_info_path_DoubleClick);
            // 
            // tTip_assumed_cost
            // 
            this.tTip_assumed_cost.AutomaticDelay = 200;
            this.tTip_assumed_cost.AutoPopDelay = 10000;
            this.tTip_assumed_cost.InitialDelay = 200;
            this.tTip_assumed_cost.IsBalloon = true;
            this.tTip_assumed_cost.ReshowDelay = 40;
            this.tTip_assumed_cost.ToolTipTitle = "Assumed Weight";
            // 
            // CalcCostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 157);
            this.ControlBox = false;
            this.Controls.Add(this.btn_open_block_info);
            this.Controls.Add(this.txt_block_info_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_assumed_cost);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_gen_costs);
            this.Controls.Add(this.btn_save_costs);
            this.Controls.Add(this.txt_cost_info_path);
            this.Name = "CalcCostForm";
            this.Text = "CalcCostForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open_block_info;
        private System.Windows.Forms.TextBox txt_block_info_path;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_assumed_cost;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_gen_costs;
        private System.Windows.Forms.Button btn_save_costs;
        private System.Windows.Forms.TextBox txt_cost_info_path;
        private System.Windows.Forms.ToolTip tTip_assumed_cost;
    }
}