using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaPacientes
{
    class DAOPaciente
    {
        //declarando variaves de conexao com o BD
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;
        public string msg;
        //declarando variaveis de opeações logicas
        public int i;
        public int contador;
        public int contarCodigo;
        //declarando os vetores
        public int[] codigoVet;
        public string[] nomeVet;
        public string[] telefoneVet;
        public string[] convenioVet;
        public string[] tratamentoVet;
        public string[] lugarVet;
        public string[] cpfVet;
        public string[] dividaVet;
        public string[] horarioVet;
        public string[] diasVet;
        public string[] impostoVet;

        public DAOPaciente()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=agenda;Uid=root;password=");
            try
            {
                conexao.Open();//Tentando conectar ao BD
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);//Enviando a mesagem de erro aos usuários
                conexao.Close();//fechando a conexão com o banco de dados
            }
        }//fim do metodo construtor

        public void Inserir(string nome, string convenio, string tratamento, string lugar,
            string telefone, string horario, string dias, string cpf, string imposto, string divida)
        {
            try
            {
                //Preparar os dados para inserir no banco
                dados = "('','" + nome + "','" + convenio + "','" + tratamento + "','" + lugar + "','" + telefone +
                    "','" + horario + "','" + dias + "','" + cpf + "','" + imposto + "','" + divida + "')";
                comando = "Insert into Paciente(codigoPaciente, nome, convenio, tratamento, lugar, telefone, horario, dias, cpf, imposto, divida) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
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
            string query = "select * from Paciente";//comand para coletar todos os dados do banco

            //instanciando os vetores
            codigoVet = new int[100];
            nomeVet = new string[100];
            telefoneVet = new string[100];
            convenioVet = new string[100];
            tratamentoVet = new string[100];
            lugarVet = new string[100];
            cpfVet = new string[100];
            dividaVet = new string[100];
            horarioVet = new string[100];
            diasVet = new string[100];
            impostoVet = new string[100];

            //preencher os vetores previamente criados, ou seja, da-los valores inicias
            for (i = 0; i < 100; i++)
            {
                codigoVet[i] = 0;
                nomeVet[i] = "";
                telefoneVet[i] = "";
                convenioVet[i] = "";
                tratamentoVet[i] = "";
                lugarVet[i] = "";
                cpfVet[i] = "";
                dividaVet[i] = "";
                horarioVet[i] = "";
                diasVet[i] = "";
                impostoVet[i] = "";

            }//fim do for

            //realizar os comandos de consulta ao banco de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //ler os dados de acordo com o que esta no banco
            MySqlDataReader leitura = coletar.ExecuteReader(); //variavel 'leitura' faz uma consulta ao banco

            i = 0;//declaracao do contador 0 para o while
            contador = 0;//declaracao do contador 0 para o while
            contarCodigo = 0;//instanciando o contador para o codigo
            //preencher vetores com dados do banco de dados
            while (leitura.Read())//enquanto leitura for verdadeiro executa while
            {
                codigoVet[i] = Convert.ToInt32(leitura["codigoPaciente"]);
                nomeVet[i] = leitura["nome"] + "";//concateno com aspsa para converter para string
                telefoneVet[i] = leitura["telefone"] + "";
                convenioVet[i] = leitura["convenio"] + "";
                tratamentoVet[i] = leitura["tratamento"] + "";
                lugarVet[i] = leitura["lugar"] + "";
                cpfVet[i] = leitura["cpf"] + "";
                dividaVet[i] = leitura["divida"] + "";
                horarioVet[i] = leitura["horario"] + "";
                diasVet[i] = leitura["dias"] + "";
                impostoVet[i] = leitura["imposto"] + "";
                contarCodigo = contador;//armazenando a ultima posição do contador
                i++;//contador sai da posicao 0 e vai se incrementando
                contador++;//contar os loops do while
            }//fim do while

            leitura.Close();//fechar conexao e leitura do banco de dados
        }//fim do metodo preencher vetor

        //criar um consultar tudo por MessageBox
        public string ConsultarTudo()
        {
            PreencherVetor();//primeira coisa => preencher vetores com dados do DB

            msg = "";//zerando variavel que vai receber os dados
            for (i = 0; i < contador; i++)
            {
                msg += "Codigo: " + codigoVet[i] +
                    ", Nome: " + nomeVet[i] +
                    ", Telefone: " + telefoneVet[i] +
                    ", Convenio: " + convenioVet[i] +
                    ", Tratamento: " + tratamentoVet +
                    ", Lugar: " + lugarVet[i] +
                    ", CPF: " + cpfVet[i] +
                    ", Dívida: " + dividaVet[i] +
                    ", Horário: " + horarioVet[i] +
                    ", Dias: " + diasVet[i] +
                    ",Imposto: " + impostoVet[i] +
                    "\n\n";
            }//fim fo for
            return msg;//retorna todos os dados guardados na variavel 'msg'

        }//fim do metodo consultar tudo

        public int ConsultarCodigo()
        {
            PreencherVetor();//preencher os vetores com os dados do banco
            return codigoVet[contarCodigo];
        }//fim do metodo consultar codigo

        public string ConsultarNome(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return nomeVet[i];
                }//fim do if
            }//fim do for
            return "Nome não encontrado.";
        }//fim do consultar nome

        public string ConsultarTelefone(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return telefoneVet[i];
                }//fim do if
            }//fim do for
            return "Telefone não encontrado.";
        }//fim do consultar telefone

        public string ConsultarConvenio(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return convenioVet[i];
                }//fim do if
            }//fim do for
            return "Convenio não encontrado.";
        }//fim do consultar convenio

        public string ConsultarTratamento(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return tratamentoVet[i];
                }//fim do if
            }//fim do for
            return "Tratamento não encontrado.";
        }//fim do consultar tratamento

        public string ConsultarLugar(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return lugarVet[i];
                }//fim do if
            }//fim do for
            return "Lugar não encontrado.";
        }//fim do consultar lugar

        public string ConsultarCPF(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return cpfVet[i];
                }//fim do if
            }//fim do for
            return "CPF não encontrado.";
        }//fim do metodo consultar cpf

        public string ConsultarDivida(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return dividaVet[i];
                }//fim do if
            }//fim do for
            return "Dívida não encontrada.";
        }//fim do metodo consultar divida

        public string ConsultarHorario(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return horarioVet[i];
                }//fim do if
            }//fim do for
            return "Horário não encontrado.";
        }//fim do consultar horario

        public string ConsultarDias(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return diasVet[i];
                }//fim do if
            }//fim do for
            return "Dias não encontrados.";
        }//fim do consultar dias

        public string ConsultarImposto(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (codigoVet[i] == cod)
                {
                    return impostoVet[i];
                }//fim do if
            }//fim do for
            return "Informações de Imposto não encontradas.";
        }//fim do consultar imposto


        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = "update Paciente set " + campo + " = '" + novoDado + "' where codigoPaciente = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
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
        }//fim do método atualizar

        public void Excluir(int codigo)
        {
            try
            {
                string query = "delete from Paciente where codigoPaciente = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
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
        }//fim do excluir
        }//fim da classe
 }//fim do projeto
