namespace WorkingDynamics
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbA = new System.Windows.Forms.GroupBox();
            this.cbRows = new System.Windows.Forms.ComboBox();
            this.gbB = new System.Windows.Forms.GroupBox();
            this.gbC = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gbA
            // 
            this.gbA.Location = new System.Drawing.Point(12, 57);
            this.gbA.Name = "gbA";
            this.gbA.Size = new System.Drawing.Size(260, 200);
            this.gbA.TabIndex = 5;
            this.gbA.TabStop = false;
            this.gbA.Text = "Матриця А";
            // 
            // cbRows
            // 
            this.cbRows.FormattingEnabled = true;
            this.cbRows.Location = new System.Drawing.Point(86, 12);
            this.cbRows.Name = "cbRows";
            this.cbRows.Size = new System.Drawing.Size(90, 40);
            this.cbRows.TabIndex = 6;
            this.cbRows.SelectedIndexChanged += new System.EventHandler(this.cbRows_SelectedIndexChanged);
            // 
            // gbB
            // 
            this.gbB.Location = new System.Drawing.Point(290, 57);
            this.gbB.Name = "gbB";
            this.gbB.Size = new System.Drawing.Size(260, 200);
            this.gbB.TabIndex = 7;
            this.gbB.TabStop = false;
            this.gbB.Text = "Матриця B";
            // 
            // gbC
            // 
            this.gbC.Location = new System.Drawing.Point(155, 275);
            this.gbC.Name = "gbC";
            this.gbC.Size = new System.Drawing.Size(260, 200);
            this.gbC.TabIndex = 8;
            this.gbC.TabStop = false;
            this.gbC.Text = "Результат C";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(570, 78);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 50);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSubtract.Location = new System.Drawing.Point(570, 134);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(60, 50);
            this.btnSubtract.TabIndex = 10;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMultiply.Location = new System.Drawing.Point(570, 190);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(60, 50);
            this.btnMultiply.TabIndex = 11;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Розмір:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbC);
            this.Controls.Add(this.gbB);
            this.Controls.Add(this.cbRows);
            this.Controls.Add(this.gbA);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Калькулятор Матриць";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbA;
        private System.Windows.Forms.ComboBox cbRows;
        private System.Windows.Forms.GroupBox gbB;
        private System.Windows.Forms.GroupBox gbC;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Label label1;
    }
}