using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class DisciplinaDAO
    {
        private AcessoBD AcessoBD;

        public DisciplinaDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public List<DisciplinaDTO> ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                List<DisciplinaDTO> disciplinas = new List<DisciplinaDTO>();
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           DISCOD,
                           DISNOME
                        FROM DISCIPLINA D
                        WHERE D.DISCOD = @DISCOD";

                AcessoBD.AdicionarParametro("@DISINSCOD", SqlDbType.BigInt, pCodigoInstituicao);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {
                    foreach (DataRow row in dtEndereco.Rows)
                    {
                        DisciplinaDTO disciplina = new DisciplinaDTO()
                        {
                            Codigo = Convert.ToInt32(row["DISCOD"]),
                            Nome = row["DISNOME"].ToString(),
                        };

                        disciplinas.Add(disciplina);
                    }

                    return disciplinas;
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

        public int Cadastrar(DisciplinaDTO pDisciplina)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO DISCIPLINA
                                (DISNOME)
                               VALUES
                                (@DISNOME)";

                AcessoBD.AdicionarParametro("@DISNOME", SqlDbType.VarChar, pDisciplina.Nome);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Atualizar(DisciplinaDTO pDisciplina)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE DISCIPLINA SET
                                DISNOME = @DISNOME
                               WHERE
                                DISCOD = @DISCOD";

                AcessoBD.AdicionarParametro("@DISCOD", SqlDbType.BigInt, pDisciplina.Codigo);
                AcessoBD.AdicionarParametro("@DISNOME", SqlDbType.VarChar, pDisciplina.Nome);

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

                string sql = @"DELETE FROM DISCIPLINA WHERE DISCOD=@DISCOD";
                AcessoBD.AdicionarParametro("@DISCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}