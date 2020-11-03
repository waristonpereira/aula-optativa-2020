using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class frmConfigSerial : Form
    {
        public frmConfigSerial()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Limpa o combobox
            comboBox1.Items.Clear();
            // Iterar sobre as portas encontradas
            foreach (string porta in System.IO.Ports.SerialPort.GetPortNames())
            {
                // Adiciona o nome da porta no combobox
                comboBox1.Items.Add(porta);
            }
            // Buscar valor configurado
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            comboBox1.Text = settings["porta"].Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings["porta"].Value = comboBox1.Text;

            configFile.Save();
            ConfigurationManager.RefreshSection("AppSettings");

            this.Close();
        }
    }
}
