
namespace ScreenshareHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonCloseApp = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHide = new System.Windows.Forms.Button();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCloseApp
            // 
            this.buttonCloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseApp.Location = new System.Drawing.Point(599, 3);
            this.buttonCloseApp.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonCloseApp.Name = "buttonCloseApp";
            this.buttonCloseApp.Size = new System.Drawing.Size(190, 77);
            this.buttonCloseApp.TabIndex = 1;
            this.buttonCloseApp.Text = "Close App";
            this.buttonCloseApp.UseVisualStyleBackColor = false;
            this.buttonCloseApp.Click += new System.EventHandler(this.buttonCloseApp_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.label2);
            this.panelButtons.Controls.Add(this.label5);
            this.panelButtons.Controls.Add(this.label4);
            this.panelButtons.Controls.Add(this.label7);
            this.panelButtons.Controls.Add(this.label6);
            this.panelButtons.Controls.Add(this.label3);
            this.panelButtons.Controls.Add(this.label1);
            this.panelButtons.Controls.Add(this.buttonCloseApp);
            this.panelButtons.Controls.Add(this.buttonHide);
            this.panelButtons.Location = new System.Drawing.Point(8, 0);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(794, 398);
            this.panelButtons.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tip";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "3. Click the Start / Hide button";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(467, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "2. In Teams, Share this \"Screensharing Helper\" window";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(591, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Use FancyZones to quickly snap this window to pre-defined locations";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(552, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "To Unhide, select \"Screensharing Helper\" in the windows taskbar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(451, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "1. Drag this window to the area to you want to share";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usage";
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(5, 3);
            this.buttonHide.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(181, 77);
            this.buttonHide.TabIndex = 1;
            this.buttonHide.Text = "Start / Hide";
            this.buttonHide.UseVisualStyleBackColor = false;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(810, 406);
            this.Controls.Add(this.panelButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Screensharing Helper";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCloseApp;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
    }
}

