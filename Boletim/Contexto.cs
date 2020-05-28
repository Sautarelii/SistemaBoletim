using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SistemaBoletim.Repositorio
{
   public  class Contexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

     

        public Contexto()
        {
           
            minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["TIBoletimConfig"].ConnectionString);
            minhaConexao.Open();
        }
        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand()
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = minhaConexao,

            };
            cmdComando.ExecuteNonQuery();
        }
        public SqlDataReader ExecutaComandoRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
                minhaConexao.Close();
        }
    }
}

    

