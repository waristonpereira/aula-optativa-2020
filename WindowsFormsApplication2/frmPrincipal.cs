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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1º Parâmetro Texto
            // 2º Parâmetro Título
            // 3º Parâmetro Botões
            // 4º Parâmetro Ícone
            // 5º Parâmetro Botão padrão
            DialogResult resposta = MessageBox.Show("Deseja realmente sair?", 
                                                    "Confirmação",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (resposta == DialogResult.Yes)
            {
                // Encerra a aplicação
                Application.Exit();
            }
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instância do frmConfigSerial
            frmConfigSerial frm = new frmConfigSerial();
            // Define o form atual como PAI do form a ser aberto
            frm.MdiParent = this;
            // Mostra o form
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ambientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instância do frmCadAmbientes
            frmCadAmbientes frm = new frmCadAmbientes();
            // Define o form atual como PAI do form a ser aberto
            frm.MdiParent = this;
            // Mostra o form
            frm.Show();
        }

        private void equipamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instância do frmCadEquipamentos
            frmCadEquipamentos frm = new frmCadEquipamentos();
            // Define o form atual como PAI do form a ser aberto
            frm.MdiParent = this;
            // Mostra o form
            frm.Show();
        }
    }
}
