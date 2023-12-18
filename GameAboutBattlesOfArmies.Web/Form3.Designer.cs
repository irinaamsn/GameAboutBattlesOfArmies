namespace GameAboutBattlesOfArmies.Web
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(23, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "Горизонтальная стратегия";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(180, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 65);
            this.button2.TabIndex = 2;
            this.button2.Text = "Стратегия 3х3";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(341, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 65);
            this.button3.TabIndex = 3;
            this.button3.Text = "Вертикальная стратегия";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // materialDrawer1
            // 
            this.materialDrawer1.AutoHide = false;
            this.materialDrawer1.AutoShow = false;
            this.materialDrawer1.BackgroundWithAccent = false;
            this.materialDrawer1.BaseTabControl = null;
            this.materialDrawer1.Depth = 0;
            this.materialDrawer1.HighlightWithAccent = true;
            this.materialDrawer1.IndicatorWidth = 0;
            this.materialDrawer1.IsOpen = false;
            this.materialDrawer1.Location = new System.Drawing.Point(-250, 245);
            this.materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDrawer1.Name = "materialDrawer1";
            this.materialDrawer1.ShowIconsWhenHidden = false;
            this.materialDrawer1.Size = new System.Drawing.Size(250, 120);
            this.materialDrawer1.TabIndex = 4;
            this.materialDrawer1.Text = "materialDrawer1";
            this.materialDrawer1.UseColors = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 320);
            this.Controls.Add(this.materialDrawer1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберете стратегию";
            this.ResumeLayout(false);

        }

        #endregion
        public Button button1;
        public Button button2;
        public Button button3;
        private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
    }
}