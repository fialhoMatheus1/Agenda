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
    public partial class Cadastro : Form
    {
        Inicio inicio;
        DAOAdministrador adm;

        public Cadastro()
        {
            InitializeComponent();
            adm = new DAOAdministrador();
            textBox1.Text = Convert.ToString(adm.ConsultarCodigo() + 1);//mostra o proximo codigo na tela depois do ultimo codigo cadastrado, por isso o +1
            textBox1.ReadOnly = true;//bloqueando o codigo no primeiro acesso
        }//fim do metodo construtor


        public void Limpar()
        {
            textBox1.Text = "" + adm.ConsultarCodigo();//codigo
            textBox2.Text = "";//nome
            textBox3.Text = "";//usuario
            textBox4.Text = "";//senha
        }//fim do metodo Limpar tela
        public void InativarCampos()
        {
            textBox1.ReadOnly = false;//codigo
            textBox2.ReadOnly = true;//nome
            textBox3.ReadOnly = true;//usuario
            textBox4.ReadOnly = true;//senha
        }//fim do metodo ativar campos

        //botao de voltar a tela inicail
        private void button1_Click_1(object sender, EventArgs e)
        {
            inicio = new Inicio();
            inicio.ShowDialog();
        }//fim do botao voltar

        //botao de cadastrar conta
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.ReadOnly == false)
                {
                    Limpar();
                    InativarCampos();
                }
                else
                {
                    string nome = textBox2.Text;//Coletando o dado do campo nome
                    string usuario = textBox3.Text;//Coletando o dado do campo convenio
                    string senha = textBox4.Text;//Coletando o dado do campo tratamento
                    adm.Inserir(nome, usuario, senha);//Inserir no banco os dados do formulário
                    Limpar();//limpa os campos
                }//fim do if/else
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }//fim do try/catch
        }//fim do botao cadastrar

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

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
        }
    }//fim da classe
}//fim do projeto
