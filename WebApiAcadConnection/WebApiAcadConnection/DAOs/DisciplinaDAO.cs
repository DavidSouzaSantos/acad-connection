using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{

    ///<summary>
    ///Classe DAO de Disciplina
    ///</summary>
    public class DisciplinaDAO
    {
        private AcessoBD AcessoBD;

        ///<summary>
        ///Construtor Disciplina
        ///</summary>
        public DisciplinaDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        ///<summary>
        ///Método para Consultar Disciplina pela Instituição
        ///</summary>
        ///<param name="pCodigoInstituicao">Código da Instituição</param>
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

        ///<summary>
        ///Método para Cadastrar Disciplina
        ///</summary>
        ///<param name="pDisciplina">Objeto do Disciplina</param>
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

        ///<summary>
        ///Método para Alterar Disciplina
        ///</summary>
        ///<param name="pDisciplina">Objeto do Disciplina</param>
        public bool Alterar(DisciplinaDTO pDisciplina)
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

        ///<summary>
        ///Método para Excluir Disciplina
        ///</summary>
        ///<param name="pCodigo">Código do Disciplina</param>
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