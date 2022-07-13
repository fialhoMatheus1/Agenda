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
            AtivarTodosOsCampos();
            //mesmos metodos do consultar, porem acrescentar if/else:
            if (textBox1.Text == "")//se textBox.Text (nome, no caso) esta vazio, entao preenche com os dados do banco
            {
                textBox2.Text = "" + adm.ConsultarNome(Convert.ToInt32(textBox1.Text));//preenchendo o campo nome
                textBox3.Text = "" + adm.ConsultarUsuario(Convert.ToInt32(textBox1.Text));//preenchendo o campo usuario
                textBox4.Text = "" + adm.ConsultarSenha (Convert.ToInt32(textBox1.Text));//preenchendo o campo senha
            }
            else//se nao estiver vazio, atualizar com novos dados:
            {
                //declara novas variaveis, que receberao as atualizaçoes de dados e as armazenarão
                string atuNome = adm.Atualizar(Convert.ToInt32(textBox1.Text), "nome", textBox2.Text);//atualizar nome
                string atuUser = adm.Atualizar(Convert.ToInt32(textBox1.Text), "usuario", textBox3.Text);//atualizar usuario
                string atuSenha = adm.Atualizar(Convert.ToInt32(textBox1.Text), "senha", textBox4.Text);//atualizar senha

                //apos declaração, verificar se os novos dados estao atualizados
                if ((atuNome == "Atualizado!") && (atuUser == "Atualizado!") && (atuSenha == "Atualizado!"))
                {
                    //se estiver tudo certo, mostra essa mensagem
                    MessageBox.Show("Atualizado com sucesso!");
                }
                else
                {
                    //se algo estiver errado, mostra essa mensagem
                    MessageBox.Show("Não atualizado!");
                }//fim do if/else local
                Limpar();
            }//fim do if/else
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
                textBox4.PasswordChar = ' ';
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
