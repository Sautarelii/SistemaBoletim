using SistemaBoletim.Dominio;
using SistemaBoletim.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunoAplicaçao
{
  public  class AlunoAplicaçao
    {
        private Contexto contexto;

        private void Inserir (Aluno aluno) 
        {
            var strQuery = "";
            strQuery += "INSERT INTO ALUNO (Nome,Telefone,dataNascimento) ";
            strQuery += string.Format("VALUES ('{0}','{1}','{2}')  ",aluno.Nome,aluno.Telefone,aluno.DataNascimento );

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }
        private void Alterar(Aluno aluno)
        {
            var strQuery = "";
            strQuery += "UPDATE  ALUNO SET";
            strQuery += string.Format("Nome = '{0}', ",aluno.Nome);
            strQuery += string.Format("Telefone = '{0}', ", aluno.Telefone);
            strQuery += string.Format("DataNascimeto = '{0}', ", aluno.DataNascimento);
            strQuery += string.Format("WHERE  idAluno = {0}  ", aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }


        }
        public void Salvar(Aluno aluno)
        {
             if(aluno.Id > 0)
                Alterar(aluno);
            else
                Inserir(aluno);
      
            
        }
        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("DELETE FROM ALUNO WHERE  idAluno{0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }


        public List<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM ALUNO";
                var retornoDataReader = contexto.ExecutaComandoRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        
        }
        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var temObjeto = new Aluno()
                {
                    Id = int.Parse(reader["idAluno"].ToString()),
                   Nome = reader["Nome"].ToString(),
                   Telefone =reader["Telefone"].ToString(),
                   DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())

                };
                alunos.Add(temObjeto);
            }
      reader.Close();
       return alunos;
        }
    }
}
