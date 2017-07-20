namespace SoftBlueBD
{
    partial class Form1
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
            this.KondensatoryButton = new System.Windows.Forms.Button();
            this.IndukcyjneButton = new System.Windows.Forms.Button();
            this.RezystoryButton = new System.Windows.Forms.Button();
            this.TranzystoryButton = new System.Windows.Forms.Button();
            this.UkladyButton = new System.Windows.Forms.Button();
            this.ZlaczaButton = new System.Windows.Forms.Button();
            this.MechaniczneButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KondensatoryButton
            // 
            this.KondensatoryButton.Location = new System.Drawing.Point(62, 30);
            this.KondensatoryButton.Name = "KondensatoryButton";
            this.KondensatoryButton.Size = new System.Drawing.Size(149, 23);
            this.KondensatoryButton.TabIndex = 0;
            this.KondensatoryButton.Text = "Kondensatory";
            this.KondensatoryButton.UseVisualStyleBackColor = true;
            this.KondensatoryButton.Click += new System.EventHandler(this.KondensatoryButton_Click);
            // 
            // IndukcyjneButton
            // 
            this.IndukcyjneButton.Location = new System.Drawing.Point(62, 70);
            this.IndukcyjneButton.Name = "IndukcyjneButton";
            this.IndukcyjneButton.Size = new System.Drawing.Size(149, 23);
            this.IndukcyjneButton.TabIndex = 1;
            this.IndukcyjneButton.Text = "Elementy Indukcyjne";
            this.IndukcyjneButton.UseVisualStyleBackColor = true;
            this.IndukcyjneButton.Click += new System.EventHandler(this.IndukcyjneButton_Click);
            // 
            // RezystoryButton
            // 
            this.RezystoryButton.Location = new System.Drawing.Point(62, 114);
            this.RezystoryButton.Name = "RezystoryButton";
            this.RezystoryButton.Size = new System.Drawing.Size(149, 23);
            this.RezystoryButton.TabIndex = 2;
            this.RezystoryButton.Text = "Rezystory";
            this.RezystoryButton.UseVisualStyleBackColor = true;
            this.RezystoryButton.Click += new System.EventHandler(this.RezystoryButton_Click);
            // 
            // TranzystoryButton
            // 
            this.TranzystoryButton.Location = new System.Drawing.Point(62, 159);
            this.TranzystoryButton.Name = "TranzystoryButton";
            this.TranzystoryButton.Size = new System.Drawing.Size(149, 23);
            this.TranzystoryButton.TabIndex = 3;
            this.TranzystoryButton.Text = "Tranzystory i Diody";
            this.TranzystoryButton.UseVisualStyleBackColor = true;
            this.TranzystoryButton.Click += new System.EventHandler(this.TranzystoryButton_Click);
            // 
            // UkladyButton
            // 
            this.UkladyButton.Location = new System.Drawing.Point(62, 207);
            this.UkladyButton.Name = "UkladyButton";
            this.UkladyButton.Size = new System.Drawing.Size(149, 23);
            this.UkladyButton.TabIndex = 4;
            this.UkladyButton.Text = "Układy Scalone";
            this.UkladyButton.UseVisualStyleBackColor = true;
            this.UkladyButton.Click += new System.EventHandler(this.UkladyButton_Click);
            // 
            // ZlaczaButton
            // 
            this.ZlaczaButton.Location = new System.Drawing.Point(62, 247);
            this.ZlaczaButton.Name = "ZlaczaButton";
            this.ZlaczaButton.Size = new System.Drawing.Size(149, 23);
            this.ZlaczaButton.TabIndex = 5;
            this.ZlaczaButton.Text = "Złącza";
            this.ZlaczaButton.UseVisualStyleBackColor = true;
            this.ZlaczaButton.Click += new System.EventHandler(this.ZlaczaButton_Click);
            // 
            // MechaniczneButton
            // 
            this.MechaniczneButton.Location = new System.Drawing.Point(62, 289);
            this.MechaniczneButton.Name = "MechaniczneButton";
            this.MechaniczneButton.Size = new System.Drawing.Size(149, 23);
            this.MechaniczneButton.TabIndex = 6;
            this.MechaniczneButton.Text = "Elementy Mechaniczne";
            this.MechaniczneButton.UseVisualStyleBackColor = true;
            this.MechaniczneButton.Click += new System.EventHandler(this.MechaniczneButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 372);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MechaniczneButton);
            this.Controls.Add(this.ZlaczaButton);
            this.Controls.Add(this.UkladyButton);
            this.Controls.Add(this.TranzystoryButton);
            this.Controls.Add(this.RezystoryButton);
            this.Controls.Add(this.IndukcyjneButton);
            this.Controls.Add(this.KondensatoryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftBlue Database";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button KondensatoryButton;
        private System.Windows.Forms.Button IndukcyjneButton;
        private System.Windows.Forms.Button RezystoryButton;
        private System.Windows.Forms.Button TranzystoryButton;
        private System.Windows.Forms.Button UkladyButton;
        private System.Windows.Forms.Button ZlaczaButton;
        private System.Windows.Forms.Button MechaniczneButton;
        private System.Windows.Forms.Button button1;
    }
}

