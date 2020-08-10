using System;
using System.Collections.Generic;
using System.Data;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    ///<summary>
    ///Classe DAO de Nota
    ///</summary>
    public class NotaDAO
    {
        private AcessoBD AcessoBD;

        ///<summary>
        ///Construtor NotaDAO
        ///</summary>
        public NotaDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        ///<summary>
        ///Método para Consultar Nota pela Avaliação e Aluno
        ///</summary>
        ///<param name="pCodigoAvaliacao">Código da Avaliação</param>
        ///<param name="pCodigoAluno">Código do Aluno</param>
        public List<NotaDTO> ConsultarPorAvaliacaoAluno(int pCodigoAvaliacao, int pCodigoAluno)
        {
            try
            {
                List<NotaDTO> notas = new List<NotaDTO>();
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           N.NOTCOD,
                           N.NOTNOTA,
                           N.NOTDATACRIACAO
                        FROM NOTA N
                        INNER JOIN 
                                AVALIACAO AV
                        INNER JOIN 
                                ALUNO A
                        WHERE   N.NOTAVACOD = @NOTAVACOD AND
                                N.NOTALUCOD = @NOTALUCOD AND
                                AV.AVACOD = N.NOTAVACOD AND
                                A.ALUCOD = N.NOTALUCOD";

                AcessoBD.AdicionarParametro("@NOTAVACOD", SqlDbType.BigInt, pCodigoAvaliacao);
                AcessoBD.AdicionarParametro("@NOTALUCOD", SqlDbType.BigInt, pCodigoAluno);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {

                    foreach (DataRow row in dtEndereco.Rows)
                    {

                        NotaDTO nota = new NotaDTO()
                        {
                            Codigo = Convert.ToInt32(row["NOTCOD"]),
                            Nota = Convert.ToInt32(row["NOTNOTA"].ToString()),
                            DataCriacao = DateTime.Parse(row["NOTDATACRIACAO"].ToString())
                        };

                        notas.Add(nota);
                    }

                    return notas;
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
        ///Método para Cadastrar Nota
        ///</summary>
        ///<param name="pNota">Objeto da Nota</param>
        public int Cadastrar(NotaDTO pNota)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO NOTA
                                (NOTNOTA, NOTAVACOD, NOTALUCOD, NOTDATACRIACAO)
                               VALUES
                                (@NOTNOTA, @NOTAVACOD, @NOTALUCOD, @NOTDATACRIACAO)";

                AcessoBD.AdicionarParametro("@NOTNOTA", SqlDbType.VarChar, pNota.Nota);
                AcessoBD.AdicionarParametro("@NOTAVACOD", SqlDbType.BigInt, pNota.Avaliacao.Codigo);
                AcessoBD.AdicionarParametro("@NOTALUCOD", SqlDbType.BigInt, pNota.Aluno.Codigo);
                AcessoBD.AdicionarParametro("@NOTDATACRIACAO", SqlDbType.DateTime, pNota.DataCriacao);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Nota
        ///</summary>
        ///<param name="pNota">Objeto da Nota</param>
        public bool Alterar(NotaDTO pNota)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE NOTA SET
                                NOTNOTA=@NOTNOTA, NOTAVACOD=@NOTAVACOD, NOTALUCOD=@NOTALUCOD, NOTDATACRIACAO=@NOTDATACRIACAO
                               WHERE
                                NOTCOD=@NOTCOD";

                AcessoBD.AdicionarParametro("@NOTCOD", SqlDbType.BigInt, pNota.Codigo);
                AcessoBD.AdicionarParametro("@NOTNOTA", SqlDbType.VarChar, pNota.Nota);
                AcessoBD.AdicionarParametro("@NOTAVACOD", SqlDbType.BigInt, pNota.Avaliacao.Codigo);
                AcessoBD.AdicionarParametro("@NOTALUCOD", SqlDbType.BigInt, pNota.Aluno.Codigo);
                AcessoBD.AdicionarParametro("@NOTDATACRIACAO", SqlDbType.DateTime, pNota.DataCriacao);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Nota
        ///</summary>
        ///<param name="pCodigo">Código da Nota</param>
        public bool Excluir(int pCodigo)
        {
            try
            {
                AcessoBD.LimparParanetros();

                string sql = @"DELETE FROM NOTA WHERE NOTCOD=@NOTCOD";
                AcessoBD.AdicionarParametro("@NOTCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}