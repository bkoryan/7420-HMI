namespace HMIAPP
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.EnterLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UserNameTxtBox = new System.Windows.Forms.TextBox();
            this.PassTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userNameTxtBoxError = new System.Windows.Forms.ErrorProvider(this.components);
            this.passTxtBoxError = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StripMenuLoginForm = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTxtBoxError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passTxtBoxError)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnterLogin
            // 
            this.EnterLogin.Location = new System.Drawing.Point(32, 205);
            this.EnterLogin.Margin = new System.Windows.Forms.Padding(0);
            this.EnterLogin.Name = "EnterLogin";
            this.EnterLogin.Size = new System.Drawing.Size(118, 58);
            this.EnterLogin.TabIndex = 0;
            this.EnterLogin.Text = "Enter";
            this.EnterLogin.UseVisualStyleBackColor = true;
            this.EnterLogin.Click += new System.EventHandler(this.EnterLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(111, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 99);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(185, 205);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(118, 58);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // UserNameTxtBox
            // 
            this.UserNameTxtBox.Location = new System.Drawing.Point(111, 132);
            this.UserNameTxtBox.Name = "UserNameTxtBox";
            this.UserNameTxtBox.Size = new System.Drawing.Size(112, 23);
            this.UserNameTxtBox.TabIndex = 3;
            this.UserNameTxtBox.Click += new System.EventHandler(this.UserNameTxtBox_Click);
            // 
            // PassTxtBox
            // 
            this.PassTxtBox.Location = new System.Drawing.Point(111, 161);
            this.PassTxtBox.Name = "PassTxtBox";
            this.PassTxtBox.PasswordChar = '*';
            this.PassTxtBox.Size = new System.Drawing.Size(112, 23);
            this.PassTxtBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "UserName :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(40, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password :";
            // 
            // userNameTxtBoxError
            // 
            this.userNameTxtBoxError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.userNameTxtBoxError.ContainerControl = this;
            // 
            // passTxtBoxError
            // 
            this.passTxtBoxError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.passTxtBoxError.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuLoginForm});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(329, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StripMenuLoginForm
            // 
            this.StripMenuLoginForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.StripMenuLoginForm.Name = "StripMenuLoginForm";
            this.StripMenuLoginForm.Size = new System.Drawing.Size(50, 20);
            this.StripMenuLoginForm.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Help";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(329, 274);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PassTxtBox);
            this.Controls.Add(this.UserNameTxtBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EnterLogin);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameTxtBoxError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passTxtBoxError)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox UserNameTxtBox;
        private System.Windows.Forms.TextBox PassTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider userNameTxtBoxError;
        private System.Windows.Forms.ErrorProvider passTxtBoxError;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StripMenuLoginForm;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}