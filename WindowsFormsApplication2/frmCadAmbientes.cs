using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    public partial class frmCadAmbientes : Form
    {
        public frmCadAmbientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                clsConexao conexao = new clsConexao();

                SQLiteCommand comando = new SQLiteCommand();
                comando.CommandText = "INSERT INTO ambientes (nome) VALUES (@nome)";
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Connection = conexao.obterConexao();
                comando.ExecuteNonQuery();

                MessageBox.Show("Ambiente cadastrado com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            } 
            catch(Exception err)
            {
                MessageBox.Show("Ops! Ocorreu um erro!",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
