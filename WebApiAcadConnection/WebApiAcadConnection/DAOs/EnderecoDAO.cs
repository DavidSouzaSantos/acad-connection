﻿using System;
using System.Data;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    ///<summary>
    ///Classe DAO de Endereço
    ///</summary>
    public class EnderecoDAO
    {
        private AcessoBD AcessoBD;

        ///<summary>
        ///Construtor EnderecoDAO
        ///</summary>
        public EnderecoDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        ///<summary>
        ///Método para Consultar Endereço pelo Código
        ///</summary>
        ///<param name="pCodigo">Código do Endereço</param>
        public EnderecoDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           ENDCOD,
                           ENDCEP,
                           ENDLOGRADOURO,
                           ENDNUMERO,
                           ENDCOMPLEMENTO,
                           ENDBAIRRO,
                           ENDCIDADE,
                           ENDESTADO,
                           ENDPAIS
                        FROM ENDERECO
                        WHERE ENDCOD = @ENDCOD";

                AcessoBD.AdicionarParametro("@ENDCOD", SqlDbType.BigInt, pCodigo);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {
                    DataRow row = dtEndereco.Rows[0];

                    EnderecoDTO endereco = new EnderecoDTO
                    {
                        Codigo = Convert.ToInt32(row["ENDCOD"]),
                        Cep = row["ENDCEP"].ToString(),
                        Logradouro = row["ENDLOGRADOURO"].ToString(),
                        Numero = row["ENDNUMERO"].ToString(),
                        Complemento = row["ENDCOMPLEMENTO"].ToString(),
                        Bairro = row["ENDBAIRRO"].ToString(),
                        Cidade = row["ENDCIDADE"].ToString(),
                        Estado = row["ENDESTADO"].ToString(),
                        Pais = row["ENDPAIS"].ToString()
                    };

                    return endereco;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Aluno
        ///</summary>
        ///<param name="pEndereco">Objeto do Endereço</param>
        public int Cadastrar(EnderecoDTO pEndereco)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO ENDERECO
                                (ENDCEP, ENDLOGRADOURO, ENDNUMERO, ENDCOMPLEMENTO,  ENDBAIRRO, ENDCIDADE, ENDESTADO, ENDPAIS)
                               VALUES
                                (@ENDCEP, @ENDLOGRADOURO, @ENDNUMERO, @ENDCOMPLEMENTO,  @ENDBAIRRO, @ENDCIDADE, @ENDESTADO, @ENDPAIS)";

                AcessoBD.AdicionarParametro("@ENDCEP", SqlDbType.VarChar, pEndereco.Cep);
                AcessoBD.AdicionarParametro("@ENDLOGRADOURO", SqlDbType.VarChar, pEndereco.Logradouro);
                AcessoBD.AdicionarParametro("@ENDNUMERO", SqlDbType.VarChar, pEndereco.Numero);
                AcessoBD.AdicionarParametro("@ENDCOMPLEMENTO", SqlDbType.VarChar, pEndereco.Complemento);
                AcessoBD.AdicionarParametro("@ENDBAIRRO", SqlDbType.VarChar, pEndereco.Bairro);
                AcessoBD.AdicionarParametro("@ENDCIDADE", SqlDbType.VarChar, pEndereco.Cidade);
                AcessoBD.AdicionarParametro("@ENDESTADO", SqlDbType.VarChar, pEndereco.Estado);
                AcessoBD.AdicionarParametro("@ENDPAIS", SqlDbType.VarChar, pEndereco.Pais);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Aluno
        ///</summary>
        ///<param name="pEndereco">Objeto do Endereço</param>
        public bool Alterar(EnderecoDTO pEndereco)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE ENDERECO SET
                                ENDCEP=@ENDCEP, ENDLOGRADOURO=@ENDLOGRADOURO, ENDNUMERO=@ENDNUMERO, ENDCOMPLEMENTO=@ENDCOMPLEMENTO, ENDBAIRRO=@ENDBAIRRO, ENDCIDADE=@ENDCIDADE, ENDESTADO=@ENDESTADO, ENDPAIS=@ENDPAIS
                               WHERE
                                ENDCOD=@ENDCOD";

                AcessoBD.AdicionarParametro("@ENDCOD", SqlDbType.BigInt, pEndereco.Codigo);
                AcessoBD.AdicionarParametro("@ENDCEP", SqlDbType.VarChar, pEndereco.Cep);
                AcessoBD.AdicionarParametro("@ENDLOGRADOURO", SqlDbType.VarChar, pEndereco.Logradouro);
                AcessoBD.AdicionarParametro("@ENDNUMERO", SqlDbType.VarChar, pEndereco.Numero);
                AcessoBD.AdicionarParametro("@ENDCOMPLEMENTO", SqlDbType.VarChar, pEndereco.Complemento);
                AcessoBD.AdicionarParametro("@ENDBAIRRO", SqlDbType.VarChar, pEndereco.Bairro);
                AcessoBD.AdicionarParametro("@ENDCIDADE", SqlDbType.VarChar, pEndereco.Cidade);
                AcessoBD.AdicionarParametro("@ENDESTADO", SqlDbType.VarChar, pEndereco.Estado);
                AcessoBD.AdicionarParametro("@ENDPAIS", SqlDbType.VarChar, pEndereco.Pais);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Aluno
        ///</summary>
        ///<param name="pCodigo">Código do Endereço</param>
        public bool Excluir(int pCodigo)
        {
            try
            {
                AcessoBD.LimparParanetros();

                string sql = @"DELETE FROM ENDERECO WHERE ENDCOD=@ENDCOD";
                AcessoBD.AdicionarParametro("@ENDCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}