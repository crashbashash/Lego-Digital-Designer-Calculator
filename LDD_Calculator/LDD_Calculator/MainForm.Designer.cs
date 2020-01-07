namespace LDD_Calculator
{
    partial class MainForm
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
            this.btn_gen = new System.Windows.Forms.Button();
            this.btn_calc_weight = new System.Windows.Forms.Button();
            this.btn_calc_cost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_gen
            // 
            this.btn_gen.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gen.Location = new System.Drawing.Point(107, 52);
            this.btn_gen.Name = "btn_gen";
            this.btn_gen.Size = new System.Drawing.Size(379, 51);
            this.btn_gen.TabIndex = 0;
            this.btn_gen.Text = "Generate Block Info";
            this.btn_gen.UseVisualStyleBackColor = true;
            this.btn_gen.Click += new System.EventHandler(this.btn_gen_Click);
            // 
            // btn_calc_weight
            // 
            this.btn_calc_weight.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calc_weight.Location = new System.Drawing.Point(107, 166);
            this.btn_calc_weight.Name = "btn_calc_weight";
            this.btn_calc_weight.Size = new System.Drawing.Size(379, 51);
            this.btn_calc_weight.TabIndex = 1;
            this.btn_calc_weight.Text = "Calculate LDD Weight";
            this.btn_calc_weight.UseVisualStyleBackColor = true;
            this.btn_calc_weight.Click += new System.EventHandler(this.btn_calc_weight_Click);
            // 
            // btn_calc_cost
            // 
            this.btn_calc_cost.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calc_cost.Location = new System.Drawing.Point(107, 274);
            this.btn_calc_cost.Name = "btn_calc_cost";
            this.btn_calc_cost.Size = new System.Drawing.Size(379, 51);
            this.btn_calc_cost.TabIndex = 2;
            this.btn_calc_cost.Text = "Calculate LDD Cost";
            this.btn_calc_cost.UseVisualStyleBackColor = true;
            this.btn_calc_cost.Click += new System.EventHandler(this.btn_calc_cost_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 435);
            this.Controls.Add(this.btn_calc_cost);
            this.Controls.Add(this.btn_calc_weight);
            this.Controls.Add(this.btn_gen);
            this.Name = "MainForm";
            this.Text = "LDD Calculator - Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_gen;
        private System.Windows.Forms.Button btn_calc_weight;
        private System.Windows.Forms.Button btn_calc_cost;
    }
}

