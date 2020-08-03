using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class AvaliacaoDAO
    {
        private AcessoBD AcessoBD;

        public AvaliacaoDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public List<AvaliacaoDTO> ConsultarPorCurso(int pCodigoCurso)
        {
            try
            {
                List<AvaliacaoDTO> avaliacoes = new List<AvaliacaoDTO>();
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           AV.AVACOD,
                           AV.AVANOME,
                           AV.AVADESCRICAO,
                           AV.AVAPESO,
                            C.PROCOD,
                            C.PRONOME,
                           AV.AVADATACRIACAO
                        FROM AVALIACAO AV
                        INNER JOIN 
                                CURSO C
                        WHERE   AV.AVACURCOD = @AVACURCOD AND
                                C.CURCOD = AV.AVACURCOD";

                AcessoBD.AdicionarParametro("@AVACURCOD", SqlDbType.BigInt, pCodigoCurso);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {

                    foreach (DataRow row in dtEndereco.Rows)
                    {

                        AvaliacaoDTO avaliacao = new AvaliacaoDTO()
                        {
                            Codigo = Convert.ToInt32(row["AVACOD"]),
                            Nome = row["AVANOME"].ToString(),
                            Descricao = row["AVADESCRICAO"].ToString(),
                            Peso = Convert.ToInt32(row["AVADATAINICIO"].ToString()),
                            Curso = new CursoDTO()
                            {
                                Codigo = Convert.ToInt32(row["CURCOD"]),
                                Nome = row["CURNOME"].ToString(),
                            },
                            DataCriacao = DateTime.Parse(row["AVADATACRIACAO"].ToString())
                        };

                        avaliacoes.Add(avaliacao);
                    }

                    return avaliacoes;
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

        public int Cadastrar(AvaliacaoDTO pAvaliacao)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO AVALIACAO
                                (AVANOME, AVADESCRICAO, AVAPESO, AVADATACRIACAO)
                               VALUES
                                (@AVANOME, @AVADESCRICAO, @AVAPESO, @AVADATACRIACAO)";

                AcessoBD.AdicionarParametro("@AVANOME", SqlDbType.VarChar, pAvaliacao.Nome);
                AcessoBD.AdicionarParametro("@AVADESCRICAO", SqlDbType.VarChar, pAvaliacao.Descricao);
                AcessoBD.AdicionarParametro("@AVAPESO", SqlDbType.DateTime, pAvaliacao.Peso);
                AcessoBD.AdicionarParametro("@AVADATACRIACAO", SqlDbType.DateTime, pAvaliacao.DataCriacao);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(AvaliacaoDTO pAvaliacao)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE AVALIACAO SET
                                AVANOME=@AVANOME, AVADESCRICAO=@AVADESCRICAO, AVAPESO=@AVAPESO
                               WHERE
                                AVACOD=@AVACOD";

                AcessoBD.AdicionarParametro("@AVACOD", SqlDbType.BigInt, pAvaliacao.Codigo);
                AcessoBD.AdicionarParametro("@AVANOME", SqlDbType.VarChar, pAvaliacao.Nome);
                AcessoBD.AdicionarParametro("@AVADESCRICAO", SqlDbType.VarChar, pAvaliacao.Descricao);
                AcessoBD.AdicionarParametro("@AVAPESO", SqlDbType.SmallInt, pAvaliacao.Peso);
                AcessoBD.AdicionarParametro("@AVADATACRIACAO", SqlDbType.DateTime, pAvaliacao.DataCriacao);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int pCodigo)
        {
            try
            {
                AcessoBD.LimparParanetros();

                string sql = @"DELETE FROM AVALIACAO WHERE AVACOD=@AVACOD";
                AcessoBD.AdicionarParametro("@AVACOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}