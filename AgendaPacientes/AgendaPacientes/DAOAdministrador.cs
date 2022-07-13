using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaPacientes
{
    class DAOAdministrador
    {
        //declarando variaves de conexao com o BD
        public MySqlConnection conexaoAdm;
        public string dados;
        public string comando;
        public string resultado;
        public string msgAdm;
        //declarando variaveis de opeações logicas
        public int a;
        public int contadorAdm;
        public int contarCodigoAdm;
        //declarando os vetores
        public int[] codigoAdmVet;
        public string[] nomeAdmVet;
        public string[] usuarioVet;
        public string[] senhaVet;

        public DAOAdministrador()
        {
            conexaoAdm = new MySqlConnection("server=localhost;DataBase=agenda;Uid=root;password=");
            try
            {
                conexaoAdm.Open();//Tentando conectar ao BD
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);//Enviando a mesagem de erro aos usuários
                conexaoAdm.Close();//fechando a conexão com o banco de dados
            }
        }//fim do metodo construtor

        public void Inserir(string nome, string usuario, string senha)
        {
            try
            {
                //Preparar os dados para inserir no banco
                dados = "('','" + nome + "','" + usuario + "','" + senha + "')";
                comando = "Insert into Administrador(codigo, nome, usuario, senha) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexaoAdm);
                resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não cadastrado!");
                }//fim do if/else
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from Administrador";//comand para coletar todos os dados do banco

            //instanciando os vetores
            codigoAdmVet = new int[100];
            nomeAdmVet = new string[100];
            usuarioVet = new string[100];
            senhaVet = new string[100];

            //preencher os vetores previamente criados, ou seja, da-los valores inicias
            for (a = 0; a < 100; a++)
            {
                codigoAdmVet[a] = 0;
                nomeAdmVet[a] = "";
                usuarioVet[a] = "";
                senhaVet[a] = "";
            }//fim do for

            //realizar os comandos de consulta ao banco de dados
            MySqlCommand coletar = new MySqlCommand(query, conexaoAdm);
            //ler os dados de acordo com o que esta no banco
            MySqlDataReader leitura = coletar.ExecuteReader(); //variavel 'leitura' faz uma consulta ao banco

            a = 0;//declaracao do contador 0 para o while
            contadorAdm = 0;//declaracao do contador 0 para o while
            contarCodigoAdm = 0;//instanciando o contador para o codigo
            //preencher vetores com dados do banco de dados
            while (leitura.Read())//enquanto leitura for verdadeiro executa while
            {
                codigoAdmVet[a] = Convert.ToInt32(leitura["codigo"]);
                nomeAdmVet[a] = leitura["nome"] + "";//concateno com aspsa para converter para string
                usuarioVet[a] = leitura["usuario"] + "";
                senhaVet[a] = leitura["senha"] + "";
                contarCodigoAdm = contadorAdm;//armazenando a ultima posição do contador
                a++;//contador sai da posicao 0 e vai se incrementando
                contadorAdm++;//contar os loops do while
            }//fim do while
            leitura.Close();//fechar conexao e leitura do banco de dados
        }//fim do metodo preencher vetor

        //criar um consultar tudo por MessageBox
        public string ConsultarTudo()
        {
            PreencherVetor();//primeira coisa => preencher vetores com dados do DB

            msgAdm = "";//zerando variavel que vai receber os dados
            for (a = 0; a < contadorAdm; a++)
            {
                msgAdm += "Codigo: " + codigoAdmVet[a] +
                    ", Nome: " + nomeAdmVet[a] +
                    ", Usuário: " + usuarioVet[a] +
                    ", Senha: " + senhaVet[a] +
                    "\n\n";
            }//fim fo for
            return msgAdm;//retorna todos os dados guardados na variavel 'msg'

        }//fim do metodo consultar tudo

        public int ConsultarCodigo()
        {
            PreencherVetor();//preencher os vetores com os dados do banco
            return codigoAdmVet[contarCodigoAdm];
        }//fim do metodo consultar codigo

        public string ConsultarNome(int cod)
        {
            PreencherVetor();
            for (a = 0; a < contadorAdm; a++)
            {
                if (codigoAdmVet[a] == cod)
                {
                    return nomeAdmVet[a];
                }//fim do if
            }//fim do for
            return "Nome não encontrado.";
        }//fim do consultar nome

        public string ConsultarUsuario(int cod)
        {
            PreencherVetor();
            for (a = 0; a < contadorAdm; a++)
            {
                if (codigoAdmVet[a] == cod)
                {
                    return usuarioVet[a];
                }//fim do if
            }//fim do for
            return "Nome de usuário não encontrado.";
        }//fim do consultar nome de usuario

        public string ConsultarSenha(int cod)
        {
            PreencherVetor();
            for (a = 0; a < contadorAdm; a++)
            {
                if (codigoAdmVet[a] == cod)
                {
                    return senhaVet[a];
                }//fim do if
            }//fim do for
            return "Senha de usuário não encontrado.";
        }//fim do consultar nome de usuario

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = "update Administrador set " + campo + " = '" + novoDado + "' where codigo = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(query, conexaoAdm);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Atualizado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Não atualizado!";
        }//fim do método atualizar conta

        public void Excluir(int codigo)
        {
            try
            {
                string query = "delete from Administrador where codigo = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(query, conexaoAdm);
                string resultado = "" + sql.ExecuteNonQuery();



                if (resultado == "1")
                {
                    MessageBox.Show("Excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não excluído!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }//fim do excluir conta
    }//fim da classe
}//fim do projeto
