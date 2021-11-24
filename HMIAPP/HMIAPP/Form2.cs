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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            

        }

        private void EnterLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage mainPage = new MainPage(); 
            mainPage.Show();
        }
    }
}
