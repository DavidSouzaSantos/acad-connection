﻿using System;
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
        ///<summary>
        ///Objeto estático de Conexão SQL
        ///</summary>
        public static SqlConnection ConexaoSql = new SqlConnection();

        ///<summary>
        ///Objeto estático de Comando SQL
        ///</summary
        public static SqlCommand ComandoSql = new SqlCommand();

        ///<summary>
        ///Objeto estático de Parametro SQL
        ///</summary
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
                string dadosConexao = ConfigurationManager.ConnectionStrings["DevConnection"].ConnectionString;
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
            SqlTransaction transactionSql = ConexaoSql.BeginTransaction();
            try
            {

                ComandoSql.Connection = ObterConexao();
                ComandoSql.CommandText = pSql;
                ComandoSql.ExecuteScalar();

                IDataReader dtReader = ComandoSql.ExecuteReader();

                DataTable dtResult = new DataTable();
                dtResult.Load(dtReader);

                transactionSql.Commit();

                return dtResult;

            }
            catch (Exception ex)
            {
                transactionSql.Rollback();
                throw ex;
            }
            finally
            {
                ConexaoSql.Close();
            }

        }

        ///<summary>
        ///Método executa script de cadastro no banco de dados
        ///</summary>
        ///<param name="pSql">Comando SQL</param>
        ///<returns>Retorna o código do registro que foi executado com sucesso</returns>
        public int ExecutarCadastrar(string pSql)
        {
            SqlTransaction transactionSql = ConexaoSql.BeginTransaction();
            try
            {
                ComandoSql.Connection = ObterConexao();
                ComandoSql.CommandText = pSql + "; SELECT SCOPE_IDENTITY()";
                object retornoCodigo = ComandoSql.ExecuteScalar();

                transactionSql.Commit();

                return Convert.ToInt32(retornoCodigo);
            }
            catch (Exception ex)
            {
                transactionSql.Rollback();
                throw ex;
            }
            finally
            {
                ConexaoSql.Close();
            }
        }

        ///<summary>
        ///Método executa comando no banco de dados
        ///</summary>
        ///<param name="pSql">Comando SQL</param>
        ///<returns>Retorna true se o sql for executado com sucesso</returns>
        public bool ExecutarComando(string pSql)
        {
            SqlTransaction transactionSql = ConexaoSql.BeginTransaction();
            try
            {
                ComandoSql.Connection = ObterConexao();
                ComandoSql.CommandText = pSql;

                transactionSql.Commit();

                return ComandoSql.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                transactionSql.Rollback();
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