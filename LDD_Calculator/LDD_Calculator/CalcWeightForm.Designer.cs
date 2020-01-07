namespace LDD_Calculator
{
    partial class CalcWeightForm
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
            this.txt_block_info_path = new System.Windows.Forms.TextBox();
            this.btn_open_block_info = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txt_weight_info_path = new System.Windows.Forms.TextBox();
            this.btn_save_weights = new System.Windows.Forms.Button();
            this.btn_gen_weights = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_assumed_weight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tTip_assumed_weight = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txt_block_info_path
            // 
            this.txt_block_info_path.Location = new System.Drawing.Point(12, 24);
            this.txt_block_info_path.Name = "txt_block_info_path";
            this.txt_block_info_path.ReadOnly = true;
            this.txt_block_info_path.Size = new System.Drawing.Size(995, 22);
            this.txt_block_info_path.TabIndex = 0;
            this.txt_block_info_path.DoubleClick += new System.EventHandler(this.txt_block_info_path_DoubleClick);
            // 
            // btn_open_block_info
            // 
            this.btn_open_block_info.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open_block_info.Location = new System.Drawing.Point(1014, 13);
            this.btn_open_block_info.Margin = new System.Windows.Forms.Padding(4);
            this.btn_open_block_info.Name = "btn_open_block_info";
            this.btn_open_block_info.Size = new System.Drawing.Size(100, 39);
            this.btn_open_block_info.TabIndex = 2;
            this.btn_open_block_info.Text = "Open";
            this.btn_open_block_info.UseVisualStyleBackColor = true;
            this.btn_open_block_info.Click += new System.EventHandler(this.btn_open_block_info_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // txt_weight_info_path
            // 
            this.txt_weight_info_path.Location = new System.Drawing.Point(12, 87);
            this.txt_weight_info_path.Name = "txt_weight_info_path";
            this.txt_weight_info_path.ReadOnly = true;
            this.txt_weight_info_path.Size = new System.Drawing.Size(995, 22);
            this.txt_weight_info_path.TabIndex = 3;
            this.txt_weight_info_path.DoubleClick += new System.EventHandler(this.txt_weight_info_path_DoubleClick);
            // 
            // btn_save_weights
            // 
            this.btn_save_weights.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_weights.Location = new System.Drawing.Point(1014, 77);
            this.btn_save_weights.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save_weights.Name = "btn_save_weights";
            this.btn_save_weights.Size = new System.Drawing.Size(100, 39);
            this.btn_save_weights.TabIndex = 4;
            this.btn_save_weights.Text = "Save";
            this.btn_save_weights.UseVisualStyleBackColor = true;
            this.btn_save_weights.Click += new System.EventHandler(this.btn_save_weights_Click);
            // 
            // btn_gen_weights
            // 
            this.btn_gen_weights.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gen_weights.Location = new System.Drawing.Point(12, 141);
            this.btn_gen_weights.Margin = new System.Windows.Forms.Padding(4);
            this.btn_gen_weights.Name = "btn_gen_weights";
            this.btn_gen_weights.Size = new System.Drawing.Size(333, 39);
            this.btn_gen_weights.TabIndex = 6;
            this.btn_gen_weights.Text = "Generate Projects Weight";
            this.btn_gen_weights.UseVisualStyleBackColor = true;
            this.btn_gen_weights.Click += new System.EventHandler(this.btn_gen_weights_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(1014, 141);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 39);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_assumed_weight
            // 
            this.txt_assumed_weight.Location = new System.Drawing.Point(898, 158);
            this.txt_assumed_weight.Name = "txt_assumed_weight";
            this.txt_assumed_weight.ReadOnly = true;
            this.txt_assumed_weight.Size = new System.Drawing.Size(109, 22);
            this.txt_assumed_weight.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(684, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Assumed Weight (g)";
            // 
            // tTip_assumed_weight
            // 
            this.tTip_assumed_weight.AutomaticDelay = 200;
            this.tTip_assumed_weight.AutoPopDelay = 10000;
            this.tTip_assumed_weight.InitialDelay = 200;
            this.tTip_assumed_weight.IsBalloon = true;
            this.tTip_assumed_weight.ReshowDelay = 40;
            this.tTip_assumed_weight.ToolTipTitle = "Assumed Weight";
            // 
            // CalcWeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 193);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_assumed_weight);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_gen_weights);
            this.Controls.Add(this.btn_save_weights);
            this.Controls.Add(this.txt_weight_info_path);
            this.Controls.Add(this.btn_open_block_info);
            this.Controls.Add(this.txt_block_info_path);
            this.Name = "CalcWeightForm";
            this.Text = "LDD Calculator - Project Weight Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_block_info_path;
        private System.Windows.Forms.Button btn_open_block_info;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txt_weight_info_path;
        private System.Windows.Forms.Button btn_save_weights;
        private System.Windows.Forms.Button btn_gen_weights;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_assumed_weight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip tTip_assumed_weight;
    }
}