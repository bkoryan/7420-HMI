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
using System.Text.RegularExpressions;

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

                Regex rgx = new Regex("[^A-Za-z0-9]");
                bool hasSpecialChars = rgx.IsMatch(UserNameTxtBox.Text);
                if(hasSpecialChars)
                {
                    MessageBox.Show("No special characters allowed in username");
                    return;
                }
               

                passTxtBoxError.Clear();
                this.Hide();
                MainPage mainPage = new MainPage();
                mainPage.Show();
                string taskname = "osk.exe";
                string processName = taskname.Replace(".exe", "");
                
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            return;            

        }

        private void contactSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("contact support");
        }

        private void viewUserManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startArgs = new ProcessStartInfo();
            startArgs.FileName = "C:\\Users\\burakfirat.koryan\\Desktop\\TemconStuff.pdf";
            startArgs.Arguments = null;
            startArgs.UseShellExecute = true;
            Process process = new Process();
            process.StartInfo = startArgs;
            process.Start();
        }
    }
}
