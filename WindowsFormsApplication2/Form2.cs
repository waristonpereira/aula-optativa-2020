using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
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
        }
    }
}
