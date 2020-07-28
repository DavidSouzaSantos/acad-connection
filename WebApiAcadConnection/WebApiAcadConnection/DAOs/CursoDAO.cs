using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class CursoDAO
    {
        private AcessoBD AcessoBD;

        public CursoDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public List<CursoDTO> ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                List<CursoDTO> Cursos = new List<CursoDTO>();
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           C.CURCOD,
                           C.CURNOME,
                           C.CURDESCRICAO,
                           C.CURDATAINICIO,
                           C.CURDATAFIM,
                           C.CURDURACAO
                            P.PROCOD,
                            P.PRONOME,
                            D.DISCOD,
                            D.DISNOME,
                            I.INSCOD,
                            I.INsSNOME,
                           C.CURDATACRIACAO
                        FROM CURSO C
                        INNER JOIN 
                                PROFESSOR P
                        INNER JOIN 
                                DISCIPLINA D
                        INNER JOIN 
                                INSTITUICAO I
                        WHERE C.CURINSCOD = @CURINSCOD AND
                              P.PROCOD = C.CURPROCOD AND
                              D.DISCOD = C.CURDISCOD AND
                              I.INSCOD = C.CURINSCOD";

                AcessoBD.AdicionarParametro("@CURINSCOD", SqlDbType.BigInt, pCodigoInstituicao);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {

                    foreach (DataRow row in dtEndereco.Rows)
                    {

                        CursoDTO curso = new CursoDTO()
                        {
                            Codigo = Convert.ToInt32(row["CURCOD"]),
                            Nome = row["CURNOME"].ToString(),
                            Descricao = row["CURDESCRICAO"].ToString(),
                            DataInicio = DateTime.Parse(row["CURDATAINICIO"].ToString()),
                            DataFim = DateTime.Parse(row["INSDATAFIM"].ToString()),
                            Duracao = Convert.ToInt32(row["INSDURACAO"]),
                            Professor = new ProfessorDTO()
                            {
                                Codigo = Convert.ToInt32(row["PROCOD"]),
                                Nome = row["PRONOME"].ToString()
                            },
                            Disciplina = new DisciplinaDTO()
                            {
                                Codigo = Convert.ToInt32(row["DISCOD"]),
                                Nome = row["DISNOME"].ToString()
                            },
                            Instituicao = new InstituicaoDTO()
                            {
                                Codigo = Convert.ToInt32(row["INSCOD"]),
                                Nome = row["INSNOME"].ToString()
                            },
                            DataCriacao = DateTime.Parse(row["CURDATACRIACAO"].ToString())
                        };

                        Cursos.Add(curso);
                    }

                    return Cursos;
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

        public int Cadastrar(CursoDTO pCurso)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO CURSO
                                (CURNOME, CURDESCRICAO, CURDATAINICIO, CURDATAFIM, CURDURACAO, CURPROCOD, CURDISCOD, @CURINSCOD, CURDATACRIACAO)
                               VALUES
                                (@CURNOME, @CURDESCRICAO, @CURDATAINICIO, @CURDATAFIM, @CURDURACAO, @CURPROCOD, @CURDISCOD. @CURINSCOD, @CURDATACRIACAO)";

                AcessoBD.AdicionarParametro("@CURNOME", SqlDbType.VarChar, pCurso.Nome);
                AcessoBD.AdicionarParametro("@CURDESCRICAO", SqlDbType.VarChar, pCurso.Descricao);
                AcessoBD.AdicionarParametro("@CURDATAINICIO", SqlDbType.DateTime, pCurso.DataInicio);
                AcessoBD.AdicionarParametro("@CURDATAFIM", SqlDbType.DateTime, pCurso.DataFim);
                AcessoBD.AdicionarParametro("@CURDURACAO", SqlDbType.VarChar, pCurso.Duracao);
                AcessoBD.AdicionarParametro("@CURPROCOD", SqlDbType.VarChar, pCurso.Professor.Codigo);
                AcessoBD.AdicionarParametro("@CURDISCOD", SqlDbType.VarChar, pCurso.Disciplina.Codigo);
                AcessoBD.AdicionarParametro("@CURDATACRIACAO", SqlDbType.DateTime, pCurso.DataCriacao);

                return AcessoBD.ExecutaComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Atualizar(CursoDTO pCurso)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE INSTITUICAO SET
                                CURNOME=@CURNOME, CURDESCRICAO=@CURDESCRICAO, CURDATAINICIO=@CURDATAINICIO, CURDATAFIM=@CURDATAFIM, CURDURACAO=@CURDURACAO, CURPROCOD=@CURPROCOD, CURDISCOD=@CURDISCOD, CURDATACRIACAO=@CURDATACRIACAO
                               WHERE
                                CURCOD=@CURCOD";

                AcessoBD.AdicionarParametro("@CURCOD", SqlDbType.BigInt, pCurso.Codigo);
                AcessoBD.AdicionarParametro("@CURNOME", SqlDbType.VarChar, pCurso.Nome);
                AcessoBD.AdicionarParametro("@CURDESCRICAO", SqlDbType.VarChar, pCurso.Descricao);
                AcessoBD.AdicionarParametro("@CURDATAINICIO", SqlDbType.DateTime, pCurso.DataInicio);
                AcessoBD.AdicionarParametro("@CURDATAFIM", SqlDbType.DateTime, pCurso.DataFim);
                AcessoBD.AdicionarParametro("@CURDURACAO", SqlDbType.VarChar, pCurso.Duracao);
                AcessoBD.AdicionarParametro("@CURPROCOD", SqlDbType.VarChar, pCurso.Professor.Codigo);
                AcessoBD.AdicionarParametro("@CURDISCOD", SqlDbType.VarChar, pCurso.Disciplina.Codigo);
                AcessoBD.AdicionarParametro("@CURDATACRIACAO", SqlDbType.DateTime, pCurso.DataCriacao);

                return AcessoBD.ExecutaComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Excluir(int pCodigo)
        {
            try
            {
                AcessoBD.LimparParanetros();

                string sql = @"DELETE FROM CURSO WHERE CURCOD=@CURCOD";
                AcessoBD.AdicionarParametro("@CURCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutaComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}