//Project Name: HMI of Temcon Folding Machine 
//Project Code: 7420 
//Developer: Burak Koryan (burak.koryan@dedemmekatronik.com)
//Date: November 2021
//Description: 
//History:


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using TwinCAT.Ads;
using TCEVENTLOGGERLib;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;


namespace HMIAPP
{

    public partial class MainPage : Form
    {
        TcAdsClient plcClient = new TcAdsClient();
        TcEventLog tcEventLogger = new TcEventLog();
        List<Panel> listPanel = new List<Panel>();
        bool toggletemp;
        int nNotificationHandle = -1;

        int SensorIdentifier;
        
        
        public int VariableBool { get; private set; }

        enum Sensors
        {
            S101RollBroke,
            S102RollBroke,
            S103RollBroke,
            S104RollBroke,
            S105RollBroke,
            S106RollBroke,
            S128Stack2Max,
            S129PullerHeightHome,
            S130PullerHeightMax,
            S131HeightExitHome,
            S132HeightExitMax,
            S133KnifeHome,
            S134MetalSensor
        }

        enum Buttons
        {
            AutoManuButton = 33,
        }

        public MainPage()
        {
            InitializeComponent();
            plcClient.Connect("169.254.128.144.1.1", 800);      // IP of Beckhoff CX2030 PLC and the selected port (800)
           //plcClient.Connect("", 800);      // IP of Beckhoff CX2030 PLC and the selected port (800)


            /*
            try
            {
                plcClient.Connect("169.254.128.144.1.1", 800);      // IP of Beckhoff CX2030 PLC and the selected port (800)
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC Connection problem" + ex.Message);
                PLCConnection.ForeColor = Color.White;
                PLCConnection.BackColor = Color.Red;
            }
            finally
            {
                PLCConnection.Text = "PLC Connected";
                PLCConnection.ForeColor = Color.White;
                PLCConnection.BackColor = Color.Green;
            }
            */

        }


        private void MainPage_Load(object sender, EventArgs e)
        {

           // LoginForm loginPage = new LoginForm();
          //  loginPage.Show();
           
           // loginPage.Opacity = 100;

            listPanel.Add(MainPanel);
            listPanel.Add(SettingsPanel);
            listPanel.Add(AlarmPanel);
            listPanel.Add(RecipePanel);
            listPanel.Add(ManualControlPanel);
            listPanel.Add(IOControlPanel);

            listPanel[0].BringToFront();
            listPanel[1].Hide();
            listPanel[2].Hide();
            listPanel[3].Hide();
            listPanel[4].Hide();
            listPanel[5].Hide();
            MainPanel.Location = new Point(113, 73);
            RecipePanel.Location = new Point(113, 73);
            SettingsPanel.Location = new Point(113, 73);
            AlarmPanel.Location = new Point(113, 73);
            AlarmPanel.Location = new Point(113, 73);
            ManualControlPanel.Location = new Point(113, 73);
            IOControlPanel.Location = new Point(113, 73);
            MainLabel.Text = "MAIN PAGE";
        }


        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { 
            plcClient.DeleteDeviceNotification(nNotificationHandle);
            plcClient.Disconnect();
                }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error:",ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DateLabel.Text = today.ToString();
            //toggletemp = !toggletemp;
            SensorIdentifier = ((int)Sensors.S101RollBroke);
            IOControlFunc("SensorsList.S101RollBrokeSensor");
            SensorIdentifier = ((int)Sensors.S102RollBroke); ;
            IOControlFunc("SensorsList.S102RollBrokeSensor");
            SensorIdentifier = ((int)Sensors.S103RollBroke); ;
            IOControlFunc("SensorsList.S103RollBrokeSensor");
            SensorIdentifier = ((int)Sensors.S104RollBroke); ;
            IOControlFunc("SensorsList.S104RollBrokeSensor");
            SensorIdentifier = ((int)Sensors.S105RollBroke); ;
            IOControlFunc("SensorsList.S105RollBrokeSensor");
            SensorIdentifier = ((int)Sensors.S106RollBroke); ;
            IOControlFunc("SensorsList.S106RollBrokeSensor");
            SensorIdentifier = ((int)Sensors.S128Stack2Max); ;
            IOControlFunc("SensorsList.S128Stack2MaxSensor");
            SensorIdentifier = ((int)Sensors.S129PullerHeightHome); ;
            IOControlFunc("SensorsList.S129PullerHeightHomeSensor");
            SensorIdentifier = ((int)Sensors.S130PullerHeightMax); ;
            IOControlFunc("SensorsList.S130PullerHeightMaxSensor");
            SensorIdentifier = ((int)Sensors.S131HeightExitHome); ;
            IOControlFunc("SensorsList.S131HeightExitHomeSensor");
            SensorIdentifier = ((int)Sensors.S132HeightExitMax); ;
            IOControlFunc("SensorsList.S132HeightExitMaxSensor");
            SensorIdentifier = ((int)Sensors.S133KnifeHome); ;
            IOControlFunc("SensorsList.S133KnifeHomeSensor");
            SensorIdentifier = ((int)Sensors.S134MetalSensor); ;
            IOControlFunc("SensorsList.S134MetalSensor");
            SensorIdentifier = (int)Buttons.AutoManuButton ;
            IOControlFunc("ButtonList.AutoManualButton");


        }

        private void SettingsBut_Click(object sender, EventArgs e)
        {
            MainLabel.Text = "SETTINGS";

            listPanel[1].Show();
            listPanel[1].BringToFront();


            listPanel[2].Hide();
            listPanel[0].Hide();
            listPanel[3].Hide();
            listPanel[4].Hide();
            listPanel[5].Hide();

        }

        private void MainBut_Click(object sender, EventArgs e)
        {
            MainLabel.Text = "MAIN PAGE";
            listPanel[0].Show();

            listPanel[0].BringToFront();

            listPanel[1].Hide();
            listPanel[2].Hide();
            listPanel[3].Hide();
            listPanel[4].Hide();
            listPanel[5].Hide();

        }

        private void AlarmsBut_Click(object sender, EventArgs e)
        {
            MainLabel.Text = "ALARMS";

            listPanel[2].BringToFront();
            listPanel[2].Show();

            listPanel[3].Hide();
            listPanel[1].Hide();
            listPanel[0].Hide();
            listPanel[4].Hide();
            listPanel[5].Hide();

        }

        private void RecipeBut_Click(object sender, EventArgs e)
        {
            MainLabel.Text = "RECIPES";

            listPanel[3].BringToFront();
            listPanel[3].Show();

            listPanel[2].Hide();
            listPanel[1].Hide();
            listPanel[0].Hide();
            listPanel[4].Hide();
            listPanel[5].Hide();

            RecipeNumberTxtBox.Text = "3";
            RecipeNumberTxtBox.Font = new Font("Microsoft Sans Serif", 15f);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Recipe Saved!");

        }

        private void ManualControlButton_Click(object sender, EventArgs e)
        {
            MainLabel.Text = "MANUAL CONTROL";
            listPanel[4].BringToFront();
            listPanel[4].Show();
            listPanel[2].Hide();
            listPanel[3].Hide();
            listPanel[1].Hide();
            listPanel[0].Hide();
            listPanel[5].Hide();
            if(AutoManLabel.BackColor == Color.Green)
            {
                MessageBox.Show("Machine in Automatic Mode. Switch to Manual Mode");
                return;
            }
        }

        private void IOControlButton_Click(object sender, EventArgs e)
        {
            MainLabel.Text = "IO CONTROL";
            listPanel[5].BringToFront();
            listPanel[5].Show();
            listPanel[0].Hide();
            listPanel[1].Hide();
            listPanel[2].Hide();
            listPanel[3].Hide();
            listPanel[4].Hide();
        }

        public void InsertAlarm(string AlarmID, string AlarmType, string AlarmDescrip, string AlarmDateTime)
        {
            string connectionString;

            SqlConnection cnn;
            connectionString = "Data Source=PC-112;Initial Catalog=dB7420;Integrated Security=True;TrustServerCertificate=True";
            cnn = new SqlConnection(connectionString);
            string query = "INSERT INTO Alarms (AlarmID,AlarmType,AlarmDescription,AlarmDateTime) VALUES(@AlarmID,@AlarmType,@AlarmDescription,@AlarmDateTime)";
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@AlarmID", Convert.ToString(AlarmID));
            command.Parameters.AddWithValue("@AlarmType", Convert.ToString(AlarmType));
            command.Parameters.AddWithValue("@AlarmDescription", Convert.ToString(AlarmDescrip));
            command.Parameters.AddWithValue("@AlarmDateTime", Convert.ToString(AlarmDateTime));

            cnn.Open();
            DBConnection.Text = "DB Connected";
            DBConnection.BackColor = Color.Green;

            command.ExecuteNonQuery();
            cnn.Close();
            DBConnection.Text = "DB Disconnected";
            DBConnection.BackColor = Color.Red;


        }

        public void IOControlFunc(string VariableName)
        {

            int VariableHandle = plcClient.CreateVariableHandle(VariableName);
            int VariableBool = Convert.ToInt16(plcClient.ReadAny(VariableHandle, typeof(int)));
            plcClient.DeleteVariableHandle(VariableHandle);


            if (VariableBool == 1)
            {
                if (SensorIdentifier == ((int)Sensors.S101RollBroke))
                {
                    S101RollBrokeLabel.ForeColor = Color.White;
                    S101RollBrokeLabel.BackColor = Color.Green;

                    InsertAlarm("0x01", "Info", "S101RollBroke", DateTime.Today.ToString());
                }
                else if (SensorIdentifier == ((int)Sensors.S102RollBroke))
                {
                    S102RollBrokeLabel.ForeColor = Color.White;
                    S102RollBrokeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S103RollBroke))
                {
                    S103RollBrokeLabel.ForeColor = Color.White;
                    S103RollBrokeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S104RollBroke))
                {
                    S104RollBrokeLabel.ForeColor = Color.White;
                    S104RollBrokeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S105RollBroke))
                {
                    S105RollBrokeLabel.ForeColor = Color.White;
                    S105RollBrokeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S106RollBroke))
                {
                    S106RollBrokeLabel.ForeColor = Color.White;
                    S106RollBrokeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S128Stack2Max))
                {
                    S128Stack2MaxLabel.ForeColor = Color.White;
                    S128Stack2MaxLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S129PullerHeightHome))
                {
                    S129PullerHeightHomeLabel.ForeColor = Color.White;
                    S129PullerHeightHomeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S130PullerHeightMax))
                {
                    S130PullerHeightMaxLabel.ForeColor = Color.White;
                    S130PullerHeightMaxLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S131HeightExitHome))
                {
                    S131HeightExitHomeLabel.ForeColor = Color.White;
                    S131HeightExitHomeLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S132HeightExitMax))
                {
                    S132HeightExitMaxLabel.ForeColor = Color.White;
                    S132HeightExitMaxLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S133KnifeHome))
                {
                    S133KnifeHomeSensorLabel.ForeColor = Color.White;
                    S133KnifeHomeSensorLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Sensors.S134MetalSensor))
                {
                    S134MetalSensorLabel.ForeColor = Color.White;
                    S134MetalSensorLabel.BackColor = Color.Green;
                }
                else if (SensorIdentifier == ((int)Buttons.AutoManuButton))
                {
                    AutoManLabel.ForeColor = Color.White;
                    AutoManLabel.BackColor = Color.Green;
                }
                else
                { }
            }
            else
            {
                if (SensorIdentifier == ((int)Sensors.S101RollBroke))
                {
                    S101RollBrokeLabel.ForeColor = Color.White;
                    S101RollBrokeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S102RollBroke))
                {
                    S102RollBrokeLabel.ForeColor = Color.White;
                    S102RollBrokeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S103RollBroke))
                {
                    S103RollBrokeLabel.ForeColor = Color.White;
                    S103RollBrokeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S104RollBroke))
                {
                    S104RollBrokeLabel.ForeColor = Color.White;
                    S104RollBrokeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S105RollBroke))
                {
                    S105RollBrokeLabel.ForeColor = Color.White;
                    S105RollBrokeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S106RollBroke))
                {
                    S106RollBrokeLabel.ForeColor = Color.White;
                    S106RollBrokeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S128Stack2Max))
                {
                    S128Stack2MaxLabel.ForeColor = Color.White;
                    S128Stack2MaxLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S129PullerHeightHome))
                {
                    S129PullerHeightHomeLabel.ForeColor = Color.White;
                    S129PullerHeightHomeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S130PullerHeightMax))
                {
                    S130PullerHeightMaxLabel.ForeColor = Color.White;
                    S130PullerHeightMaxLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S131HeightExitHome))
                {
                    S131HeightExitHomeLabel.ForeColor = Color.White;
                    S131HeightExitHomeLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S132HeightExitMax))
                {
                    S132HeightExitMaxLabel.ForeColor = Color.White;
                    S132HeightExitMaxLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S133KnifeHome))
                {
                    S133KnifeHomeSensorLabel.ForeColor = Color.White;
                    S133KnifeHomeSensorLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Sensors.S134MetalSensor))
                {
                    S134MetalSensorLabel.ForeColor = Color.White;
                    S134MetalSensorLabel.BackColor = Color.Red;
                }
                else if (SensorIdentifier == ((int)Buttons.AutoManuButton))
                {
                    AutoManLabel.ForeColor = Color.White;
                    AutoManLabel.BackColor = Color.Red;
                }
                else
                {

                }
            }
            return;
        }

        private void ClearAlarmsButton_Click(object sender, EventArgs e)
        {

            ProcessStartInfo startArgs = new ProcessStartInfo();
            startArgs.FileName = "C:\\Windows\\System32\\osk.exe";
            startArgs.Arguments = null;
            startArgs.UseShellExecute = true;
            Process process = new Process();
            process.StartInfo = startArgs;
            process.Start();



        }

        private void CloseAppButton_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }

    }

}
