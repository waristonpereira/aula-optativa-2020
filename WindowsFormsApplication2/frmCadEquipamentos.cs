using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace WindowsFormsApplication2
{
    public partial class frmCadEquipamentos : Form
    {
        public frmCadEquipamentos()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Limitar somente numeros e ponto
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmCadEquipamentos_Load(object sender, EventArgs e)
        {
            clsConexao conexao = new clsConexao();
        
            SQLiteCommand comando = new SQLiteCommand();
            comando.CommandText = "SELECT id, nome FROM ambientes ORDER BY nome";
            comando.Connection = conexao.obterConexao();
            // Obtem os dados
            SQLiteDataReader dr = comando.ExecuteReader();
            // Carrega os dados na tabela virtual
            DataTable dt = new DataTable();
            dt.Load(dr);

            cmbAmbiente.Items.Clear();

            cmbAmbiente.DataSource = dt;
            cmbAmbiente.DisplayMember = "nome"; // Campo de exibição
            cmbAmbiente.ValueMember = "id"; // Campo de valor


            cmbAmbiente.Items.Add(")
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                clsConexao conexao = new clsConexao();

                SQLiteCommand comando = new SQLiteCommand();
                comando.CommandText = "INSERT INTO equipamentos (nome, consumo, porta, ambiente_id) VALUES (@nome, @consumo, @porta, @ambiente_id)";
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Parameters.AddWithValue("@consumo", txtConsumo.Text);
                comando.Parameters.AddWithValue("@porta", cmbPorta.Text);
                comando.Parameters.AddWithValue("@ambiente_id", cmbAmbiente.SelectedValue);
                comando.Connection = conexao.obterConexao();
                comando.ExecuteNonQuery();

                MessageBox.Show("Equipamento cadastrado com sucesso!",
                                "Sucesso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ops! Ocorreu um erro!",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
