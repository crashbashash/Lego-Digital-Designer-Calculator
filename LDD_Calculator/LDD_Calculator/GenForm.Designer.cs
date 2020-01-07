namespace LDD_Calculator
{
    partial class GenForm
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
            this.txt_ldd_proj_path = new System.Windows.Forms.TextBox();
            this.btn_open_ldd_proj = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.openFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.txt_save_guide = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_gen_weights = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_ldd_proj_path
            // 
            this.txt_ldd_proj_path.Location = new System.Drawing.Point(32, 30);
            this.txt_ldd_proj_path.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ldd_proj_path.Name = "txt_ldd_proj_path";
            this.txt_ldd_proj_path.ReadOnly = true;
            this.txt_ldd_proj_path.Size = new System.Drawing.Size(916, 22);
            this.txt_ldd_proj_path.TabIndex = 0;
            this.txt_ldd_proj_path.DoubleClick += new System.EventHandler(this.Txt_ldd_proj_path_DoubleClick);
            // 
            // btn_open_ldd_proj
            // 
            this.btn_open_ldd_proj.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open_ldd_proj.Location = new System.Drawing.Point(957, 21);
            this.btn_open_ldd_proj.Margin = new System.Windows.Forms.Padding(4);
            this.btn_open_ldd_proj.Name = "btn_open_ldd_proj";
            this.btn_open_ldd_proj.Size = new System.Drawing.Size(100, 39);
            this.btn_open_ldd_proj.TabIndex = 1;
            this.btn_open_ldd_proj.Text = "Open";
            this.btn_open_ldd_proj.UseVisualStyleBackColor = true;
            this.btn_open_ldd_proj.Click += new System.EventHandler(this.Btn_open_ldd_proj_Click);
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(957, 155);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 39);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // openFileDialogue
            // 
            this.openFileDialogue.FileName = "file to open";
            // 
            // txt_save_guide
            // 
            this.txt_save_guide.Location = new System.Drawing.Point(32, 96);
            this.txt_save_guide.Margin = new System.Windows.Forms.Padding(4);
            this.txt_save_guide.Name = "txt_save_guide";
            this.txt_save_guide.ReadOnly = true;
            this.txt_save_guide.Size = new System.Drawing.Size(916, 22);
            this.txt_save_guide.TabIndex = 3;
            this.txt_save_guide.DoubleClick += new System.EventHandler(this.Txt_save_guide_DoubleClick);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(957, 85);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(100, 39);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.Btn_save_Click);
            // 
            // btn_gen_weights
            // 
            this.btn_gen_weights.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gen_weights.Location = new System.Drawing.Point(32, 150);
            this.btn_gen_weights.Margin = new System.Windows.Forms.Padding(4);
            this.btn_gen_weights.Name = "btn_gen_weights";
            this.btn_gen_weights.Size = new System.Drawing.Size(333, 39);
            this.btn_gen_weights.TabIndex = 5;
            this.btn_gen_weights.Text = "Generate Block Info";
            this.btn_gen_weights.UseVisualStyleBackColor = true;
            this.btn_gen_weights.Click += new System.EventHandler(this.Btn_gen_weights_Click);
            // 
            // GenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 204);
            this.ControlBox = false;
            this.Controls.Add(this.btn_gen_weights);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_save_guide);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_open_ldd_proj);
            this.Controls.Add(this.txt_ldd_proj_path);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GenForm";
            this.Text = "LDD Calculator - Block Info Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ldd_proj_path;
        private System.Windows.Forms.Button btn_open_ldd_proj;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.OpenFileDialog openFileDialogue;
        private System.Windows.Forms.SaveFileDialog saveFileDialogue;
        private System.Windows.Forms.TextBox txt_save_guide;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_gen_weights;
    }
}