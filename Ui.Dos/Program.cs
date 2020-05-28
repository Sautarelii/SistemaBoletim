using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemaBoletim.Dominio;
using AlunoAplicaçao;

namespace Ui.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var appAluno = new SistemaBoletimAlunoAplicaçao();

            // string strQueryUpdate = "UPDATE ALUNO SET Nome = 'Joao Bastista da silva Where idAluno = 4";
            // SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, minhaConexao);
            //cmdComandoUpdate.ExecuteNonQuery();

            //string strQueryDelete = "Delete From Aluno Where idAluno = 4";
            //SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, minhaConexao);
            //cmdComandoDelete.ExecuteNonQuery();


             Console.Write("Digite o nome do aluno");
             string nome = Console.ReadLine();

             Console.Write("Digite o Telefone"); 
             string Telefone = Console.ReadLine();

            Console.Write("Digite a data de Nascimento");

            string dataNascimento = Console.ReadLine(); 

            var aluno1= new Aluno
            {
                Nome = nome,
                Telefone = Telefone,
                DataNascimento = DateTime.Parse(dataNascimento)
            };

           appAluno.Salvar(aluno1);



            //Console.Write("Digite a data do Cadastro");
            //string dataCadastro = Console.ReadLine();

            //Console.Write("Digite a Atualição");
            //string dataUltAtualizacao = Console.ReadLine();





            var dados = appAluno.ListarTodos();

            foreach (var aluno in dados)
            {
                Console.WriteLine("Id:{0},Nome:{1},Telefone:{2},dataNascimento:{3}"           
                    , aluno.Id, aluno.Nome ,aluno.Telefone,aluno.DataNascimento);//dados["dataCadastro"],//dados["dataUltAtualizacao"]);
            }
            // ,dataCadastro: { 4},dataUltAtualizacao: { 5}


            

        }
    }
}
