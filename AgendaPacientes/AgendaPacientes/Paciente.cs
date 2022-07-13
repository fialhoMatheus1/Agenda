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
    public partial class Paciente : Form
    {
        DAOPaciente paciente;
        Inicio inicio;
        Usuario usuario;
        public Paciente()
        {
            InitializeComponent();
            paciente = new DAOPaciente();
            textBox7.Text = Convert.ToString(paciente.ConsultarCodigo() + 1);//mostra o proximo codigo na tela depois do ultimo codigo cadastrado, por isso o +1
            textBox7.ReadOnly = true;//bloqueando o codigo no primeiro acesso
        }//fim do metodo construtor

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void Limpar()
        {
            textBox7.Text = "" + paciente.ConsultarCodigo();//codigo
            textBox1.Text = "";//nome
            textBox2.Text = "";//convenio
            textBox3.Text = "";//tratamento
            textBox4.Text = "";//lugar
            maskedTextBox3.Text = "";//telefone
            maskedTextBox1.Text = "";//horario
            textBox5.Text = "";//dias da semana
            maskedTextBox4.Text = "";//cpf
            textBox6.Text = "";//declara imposto de renda?
            maskedTextBox5.Text = "";//possui divida?
        }//fim do metodo Limpar tela

        public void AtivarCampos()
        {
            textBox7.ReadOnly = false;//codigo
            textBox1.ReadOnly = true;//nome
            textBox2.ReadOnly = true;//convenio
            textBox3.ReadOnly = true;//tratamento
            textBox4.ReadOnly = true;//lugar
            maskedTextBox3.ReadOnly = true;//telefone
            maskedTextBox1.ReadOnly = true;//horario
            textBox5.ReadOnly = true;//dias da semana
            maskedTextBox4.ReadOnly = true;//cpf
            textBox6.ReadOnly = true;//declara imposto de renda?
            maskedTextBox5.ReadOnly = true;//possui divida?
        }//fim do metodo ativar campos

        public void InativarCampos()
        {
            textBox7.ReadOnly = true;//codigo
            textBox1.ReadOnly = false;//nome
            textBox2.ReadOnly = false;//convenio
            textBox3.ReadOnly = false;//tratamento
            textBox4.ReadOnly = false;//lugar
            maskedTextBox3.ReadOnly = false;//telefone
            maskedTextBox1.ReadOnly = false;//horario
            textBox5.ReadOnly = false;//dias da semana
            maskedTextBox4.ReadOnly = false;//cpf
            textBox6.ReadOnly = false;//declara imposto de renda?
            maskedTextBox5.ReadOnly = false;//possui divida?
        }//fim do metodo inativar campos

        public void AtivarTodosOsCampos()
        {
            textBox7.ReadOnly = false;//codigo
            textBox1.ReadOnly = false;//nome
            textBox2.ReadOnly = false;//convenio
            textBox3.ReadOnly = false;//tratamento
            textBox4.ReadOnly = false;//lugar
            maskedTextBox3.ReadOnly = false;//telefone
            maskedTextBox1.ReadOnly = false;//horario
            textBox5.ReadOnly = false;//dias da semana
            maskedTextBox4.ReadOnly = false;//cpf
            textBox6.ReadOnly = false;//declara imposto de renda?
            maskedTextBox5.ReadOnly = false;//possui divida?
        }//fim do metodo ativar campos

        //botao de cadastrar
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.ReadOnly == false)
                {
                    Limpar();
                    InativarCampos();
                }
                else
                {
                    string nome = textBox1.Text;//Coletando o dado do campo nome
                    string convenio = textBox2.Text;//Coletando o dado do campo convenio
                    string tratamento = textBox3.Text;//Coletando o dado do campo tratamento
                    string lugar = textBox4.Text;//Coletando o dado do campo lugar
                    string telefone = maskedTextBox3.Text;//Coletando o dado do campo telefone
                    string horario = maskedTextBox1.Text;//Coletnado o dado do camoo Horario
                    string dias = textBox5.Text;//Coletando o dado do campo dias
                    string cpf = maskedTextBox4.Text;//Coletando o dado do campo CPF
                    string imposto = textBox6.Text;//Coletando o dado do campo imposto
                    string divida = maskedTextBox5.Text;//Coletando o dado do campo divida
                    paciente.Inserir(nome, convenio, tratamento, lugar, telefone, horario, dias, cpf, imposto, divida);//Inserir no banco os dados do formulário
                    Limpar();//limpa os campos
                }//fim do if/else
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }//fim do try/catch
        }//fim do botao cadastrar

        //botao de consulta
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.ReadOnly == true)
            {
                AtivarCampos();
            }
            else
            {
                textBox1.Text = "" + paciente.ConsultarNome(Convert.ToInt32(textBox7.Text));//preenchendo o campo nome
                textBox2.Text = "" + paciente.ConsultarConvenio(Convert.ToInt32(textBox7.Text));//preenchendo o campo convenio
                textBox3.Text = "" + paciente.ConsultarTratamento(Convert.ToInt32(textBox7.Text));//preenchendo o campo tratamento
                textBox4.Text = "" + paciente.ConsultarLugar(Convert.ToInt32(textBox7.Text));//preenchendo o campo lugar
                maskedTextBox3.Text = "" + paciente.ConsultarTelefone(Convert.ToInt32(textBox7.Text));//preenchendo o campo telefone
                maskedTextBox1.Text = "" + paciente.ConsultarHorario(Convert.ToInt32(textBox7.Text));//preenchendo o campo horario
                textBox5.Text = "" + paciente.ConsultarDias(Convert.ToInt32(textBox7.Text));//preenchendo o campo dias
                maskedTextBox4.Text = "" + paciente.ConsultarCPF(Convert.ToInt32(textBox7.Text));//preenchendo o campo cpf
                textBox6.Text = "" + paciente.ConsultarImposto(Convert.ToInt32(textBox7.Text));//preenchendo o campo imposto
                maskedTextBox5.Text = "" + paciente.ConsultarDivida(Convert.ToInt32(textBox7.Text));//preenchendo o campo divida
            }//fim do if/else
        }//fim do botao consultar

        //botao de excluir
        private void button4_Click(object sender, EventArgs e)
        {
            AtivarCampos();
            paciente.Excluir(Convert.ToInt32(textBox7.Text));
        }//fim do botao excluir

        //botao de atualizar
        private void button3_Click(object sender, EventArgs e)
        {
            AtivarTodosOsCampos();
            //mesmos metodos do consultar, porem acrescentar if/else:
            if (textBox7.Text == "")//se textBox.Text (nome, no caso) esta vazio, entao preenche com os dados do banco
            {
                textBox1.Text = "" + paciente.ConsultarNome(Convert.ToInt32(textBox7.Text));//preenchendo o campo nome
                textBox2.Text = "" + paciente.ConsultarConvenio(Convert.ToInt32(textBox7.Text));//preenchendo o campo convenio
                textBox3.Text = "" + paciente.ConsultarTratamento(Convert.ToInt32(textBox7.Text));//preenchendo o campo tratamento
                textBox4.Text = "" + paciente.ConsultarLugar(Convert.ToInt32(textBox7.Text));//preenchendo o campo lugar
                maskedTextBox3.Text = "" + paciente.ConsultarTelefone(Convert.ToInt32(textBox7.Text));//preenchendo o campo telefone
                maskedTextBox1.Text = "" + paciente.ConsultarHorario(Convert.ToInt32(textBox7.Text));//preenchendo o campo horario
                textBox5.Text = "" + paciente.ConsultarDias(Convert.ToInt32(textBox7.Text));//preenchendo o campo dias
                maskedTextBox4.Text = "" + paciente.ConsultarCPF(Convert.ToInt32(textBox7.Text));//preenchendo o campo cpf
                textBox6.Text = "" + paciente.ConsultarImposto(Convert.ToInt32(textBox7.Text));//preenchendo o campo imposto
                maskedTextBox5.Text = "" + paciente.ConsultarDivida(Convert.ToInt32(textBox7.Text));//preenchendo o campo divida
            }
            else//se nao estiver vazio, atualizar com novos dados:
            {
                //declara novas variaveis, que receberao as atualizaçoes de dados e as armazenarão
                string atuNome = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "nome", textBox1.Text);//atualizar nome
                string atuConvenio = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "convenio", textBox2.Text);//atualizar convenio
                string atuTratamento = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "tratamento", textBox3.Text);//atualizar tratamento
                string atuLugar = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "lugar", textBox4.Text);//atualizar lugar
                string atuTelefone = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "telefone", maskedTextBox3.Text);//atualizar telefone
                string atuHorario = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "horario", maskedTextBox1.Text);//atualizar horario
                string atuDias = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "dias", textBox5.Text);//atualizar dias
                string atuCpf = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "cpf", maskedTextBox4.Text);//atualizar cpf
                string atuImposto = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "imposto", textBox6.Text);//atualizar imposto
                string atuDivida = paciente.Atualizar(Convert.ToInt32(textBox7.Text), "divida", maskedTextBox5.Text);//atualizar divida

                //apos declaração, verificar se os novos dados estao atualizados
                if ((atuNome == "Atualizado!") && (atuConvenio == "Atualizado!") && (atuTratamento == "Atualizado!")
                    && (atuLugar == "Atualizado!") && (atuTelefone == "Atualizado!") && (atuHorario == "Atualizado!")
                    && (atuDias == "Atualizado!") && (atuCpf == "Atualizado!") && (atuImposto == "Atualizado!")
                    && (atuDivida == "Atualizado!"))
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
        }//fim do botao de atualizar

        //botao voltar
        private void button5_Click_1(object sender, EventArgs e)
        {
            inicio = new Inicio();
            inicio.ShowDialog();
        }//fim do botao voltar

        //botao para acessar a conta do usuario
        private void button6_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            usuario.ShowDialog();
        }//fim do botao conta

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }//fim da classe
}//fim do projeto
