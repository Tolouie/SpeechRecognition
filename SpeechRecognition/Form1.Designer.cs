namespace SpeechRecognition
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
            this.components = new System.ComponentModel.Container();
            this.listBoxCommand = new System.Windows.Forms.ListBox();
            this.tmrSpeaking = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxCommand
            // 
            this.listBoxCommand.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listBoxCommand.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxCommand.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxCommand.ForeColor = System.Drawing.SystemColors.Window;
            this.listBoxCommand.FormattingEnabled = true;
            this.listBoxCommand.Location = new System.Drawing.Point(593, 0);
            this.listBoxCommand.Name = "listBoxCommand";
            this.listBoxCommand.Size = new System.Drawing.Size(207, 450);
            this.listBoxCommand.TabIndex = 0;
            this.listBoxCommand.Visible = false;
            // 
            // tmrSpeaking
            // 
            this.tmrSpeaking.Enabled = true;
            this.tmrSpeaking.Interval = 1000;
            this.tmrSpeaking.Tick += new System.EventHandler(this.tmrSpeaking_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxCommand);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCommand;
        private System.Windows.Forms.Timer tmrSpeaking;
        private System.Windows.Forms.Button button1;
    }
}

