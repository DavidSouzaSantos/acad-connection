using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApiAcadConnection.DAL
{
    ///<summary>
    ///Classe de Acesso ao Banco de Dados
    ///</summary>
    public class AcessoBD
    {
        #region Objetos Estáticos
        public static SqlConnection ConexaoSql = new SqlConnection();
        public static SqlCommand ComandoSql = new SqlCommand();
        public static SqlParameter ParametroSql = new SqlParameter();
        #endregion

        #region Métodos
        ///<summary>
        ///Método para obter conexão com banco de dados
        ///</summary>
        public static SqlConnection ObterConexao()
        {
            try
            {
                string dadosConexao = ConfigurationManager.ConnectionStrings["AcadDBConnectionString"].ConnectionString;
                ConexaoSql = new SqlConnection(dadosConexao);

                if (ConexaoSql.State == ConnectionState.Closed)
                    ConexaoSql.Open();

                return ConexaoSql;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #region Parâmetros
        ///<summary>
        ///Método para adicionar parametro ao comando
        ///</summary>
        ///<param name="pNome">Nome do parametro</param>
        ///<param name="pTipo">Tipo do parametro</param>
        ///<param name="pValor">Valor do parametro</param>
        public void AdicionarParametro(string pNome, SqlDbType pTipo, object pValor)
        {
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = pNome,
                SqlDbType = pTipo,
                Value = pValor
            };

            ComandoSql.Parameters.Add(parameter);
        }

        ///<summary>
        ///Método para limpar parametro ao comando
        ///</summary>
        ///<param name="pNome">Nome do parametro</param>
        public void LimparParanetros()
        {
            ComandoSql.Parameters.Clear();
        }
        #endregion

        #region Executar CRUD
        ///<summary>
        ///Método executa select no banco de dados
        ///</summary>
        ///<param name="pSql">Consulta SQL</param>
        ///<returns>DataTable da consulta</returns>
        public DataTable ExecutarConsulta(string pSql)
        {
            try
            {
                ComandoSql.Connection = ObterConexao();
                ComandoSql.CommandText = pSql;
                ComandoSql.ExecuteScalar();

                IDataReader dtReader = ComandoSql.ExecuteReader();

                DataTable dtResult = new DataTable();
                dtResult.Load(dtReader);

                ConexaoSql.Close();

                return dtResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConexaoSql.Close();
            }

        }

        ///<summary>
        ///Método executa select no banco de dados
        ///</summary>
        ///<param name="pSql">Comando SQL</param>
        ///<returns>Retorna true se comando foi executado com sucesso</returns>
        public int ExecutaComando(string pSql)
        {
            try
            {
                ComandoSql.Connection = ObterConexao();
                ComandoSql.CommandText = pSql;

                return Convert.ToInt32(ComandoSql.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConexaoSql.Close();
            }
        }
        #endregion

        #endregion
    }
}