using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HMIAPP
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


   

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try 
            {
                UserNameTxtBox.Clear();
                PassTxtBox.Clear();
                passTxtBoxError.Clear();
                userNameTxtBoxError.Clear();

            }
            catch (Exception ex) 
            { 
              MessageBox.Show("Error Message:" + ex.Message);   
            }
            
        }


        private void UserNameTxtBox_Click(object sender, EventArgs e)
        {
            try { 
            ProcessStartInfo startArgs = new ProcessStartInfo();
            startArgs.FileName = "C:\\Windows\\System32\\osk.exe";
            startArgs.Arguments = null;
            startArgs.UseShellExecute = true;
            Process process = new Process();
            process.StartInfo = startArgs;
            process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message :" + ex.Message);
            }
        }

      

        private void EnterLogin_Click(object sender, EventArgs e)
        {

            bool userNamechk = string.IsNullOrEmpty(UserNameTxtBox.Text);
            bool passBoxchk = string.IsNullOrEmpty(PassTxtBox.Text);

            if(userNamechk)
            {   
               userNameTxtBoxError.SetError(UserNameTxtBox, "cannot leave blank!");
            }
            else
            {
                userNameTxtBoxError.Clear();
                if (passBoxchk)
                {
                    passTxtBoxError.SetError(PassTxtBox, "cannot leave blank!");
                    return;
                }
         
                passTxtBoxError.Clear();
                this.Hide();
                MainPage mainPage = new MainPage();
                mainPage.Show();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
