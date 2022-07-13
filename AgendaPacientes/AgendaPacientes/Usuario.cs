using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaPacientes
{
    public partial class Usuario : Form
    {
        Inicio inicio;
        Paciente paciente;
        DAOAdministrador adm;
        public Usuario()
        {
            InitializeComponent();
            adm = new DAOAdministrador();
        }

        public void Limpar()
        {
            textBox1.Text = "" + adm.ConsultarCodigo();//codigo
            textBox2.Text = "";//nome
            textBox3.Text = "";//usuario
            textBox4.Text = "";//senha
        }//fim do metodo Limpar tela

        public void AtivarCampos()
        {
            textBox1.ReadOnly = false;//codigo
            textBox2.ReadOnly = true;//nome
            textBox2.ReadOnly = true;//usuario
            textBox4.ReadOnly = true;//senha
        }//fim do metodo ativar campos

        public void InativarCampos()
        {
            textBox1.ReadOnly = true;//codigo
            textBox2.ReadOnly = false;//nome
            textBox3.ReadOnly = false;//usuario
            textBox4.ReadOnly = false;//senha
        }//fim do metodo inativar campos

        public void AtivarTodosOsCampos()
        {
            textBox1.ReadOnly = false;//codigo
            textBox2.ReadOnly = false;//nome
            textBox3.ReadOnly = false;//usuario
            textBox4.ReadOnly = false;//senha
        }//fim do metodo inativar campos

        //botao de voltar a tela anterior
        private void button1_Click(object sender, EventArgs e)
        {
            paciente = new Paciente();
            paciente.ShowDialog();

        }//fim do botao voltar


        //botao de atualizar usuario
        private void button2_Click(object sender, EventArgs e)
        {
           
        }//fim do atualizar usuario

        //botao consultar conta
        private void button3_Click(object sender, EventArgs e)
        {
            
        }//fim do constultar cont6a

        //botao de excluir conta
        private void button4_Click(object sender, EventArgs e)
        {
           
        }//fim do excluir conta

        private void Usuario_Load(object sender, EventArgs e)
        {

        }
        //caixa para mostrar a senha
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.PasswordChar = '\0';
            }
            else
            {
                textBox4.PasswordChar = '*';
            }
        }//fim do mostrar senha

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//caixa de texto codigo

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//caixa de texto nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//caixa de texto usuario

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//caixa de texto senha

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
