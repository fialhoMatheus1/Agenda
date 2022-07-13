using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AgendaPacientes

{
    public partial class Inicio : Form
    {
        Paciente telaPaciente;
        Cadastro cadastro;
        DAOPaciente paciente;
        public Inicio()
        {
           InitializeComponent();
            paciente = new DAOPaciente();
        }//fim do construtor

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        //botao entrar/login
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //conexao com BD
                string conexao = "server=localhost;DataBase=agenda;Uid=root;password=";
                var connection = new MySqlConnection(conexao);
                var comand = connection.CreateCommand();

                MySqlCommand query = new MySqlCommand("select* from Administrador where usuario ='" + textBox1.Text + "' and senha ='" + textBox2.Text + "'", connection);

                connection.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dataTable);

                foreach (DataRow list in dataTable.Rows)
                {
                    if (Convert.ToInt32(list.ItemArray[0]) > 0)
                    {
                        telaPaciente = new Paciente();
                        MessageBox.Show("Bem-Vindo!");
                        telaPaciente.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Senha ou usuário incorretos. Tente novamente.");
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("erro" + erro);
            }//fim do try catch

            //abaixo metodo basico caso o login de errado:

            //telaPaciente = new Paciente();
            //telaPaciente.ShowDialog();
        }//fim do botao entrar

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadastro = new Cadastro();
            cadastro.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }//fim da classe
}//fim do projeto
