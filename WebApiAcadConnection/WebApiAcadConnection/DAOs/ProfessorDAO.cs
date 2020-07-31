using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class ProfessorDAO
    {
        private AcessoBD AcessoBD;

        public ProfessorDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public List<ProfessorDTO> ConsultarPorInstituicao(int pCodigoInstituicao)
        {
            try
            {
                List<ProfessorDTO> professores = new List<ProfessorDTO>();
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           P.PROCOD,
                           P.PRONOME,
                           P.PRODESCRICAO,
                           P.PROCNPJ,
                           P.PROSEXO,
                           P.PROEMAIL,
                           P.PROTELEFONE,
                            E.ENDCOD,
                            E.ENDCEP,
                            E.ENDLOGRADOURO,
                            E.ENDNUMERO,
                            E.ENDCOMPLEMENTO,
                            E.ENDBAIRRO,
                            E.ENDCIDADE,
                            E.ENDPAIS,
                            U.USUCOD,
                            U.USULOGIN,
                            U.USUPERFIL,
                           P.PRODATACRIACAO
                        FROM PROFESSOR P
                        INNER JOIN 
                                ENDERECO E
                        INNER JOIN 
                                USUARIO U
                        WHERE P.PROINSCOD = @PROINSCOD AND
                              E.ENDCOD = P.PROENDCOD AND
                              U.USUCOD = P.PROUSUCOD";

                AcessoBD.AdicionarParametro("@PROINSCOD", SqlDbType.BigInt, pCodigoInstituicao);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {

                    foreach (DataRow row in dtEndereco.Rows)
                    {

                        ProfessorDTO professor = new ProfessorDTO()
                        {
                            Codigo = Convert.ToInt32(row["PROCOD"]),
                            Nome = row["PRONOME"].ToString(),
                            Cpf = row["PROCPF"].ToString(),
                            DataNascimento = DateTime.Parse(row["PRODATANASCIMENTO"].ToString()),
                            Sexo = (Enums.SexoEnum)row["PROSEXO"],
                            Email = row["PROEMAIL"].ToString(),
                            Telefone = row["PROTELEFONE"].ToString(),
                            Endereco = new EnderecoDTO()
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

                            },
                            Usuario = new UsuarioDTO()
                            {
                                Codigo = Convert.ToInt32(row["USUCOD"]),
                                Login = row["USULOGIN"].ToString(),
                                Perfil = (Enums.PerfilEnum)Convert.ToInt32(row["USUPERFIL"])
                            },
                            DataCriacao = DateTime.Parse(row["PRODATACRIACAO"].ToString())
                        };

                        professores.Add(professor);
                    }

                    return professores;
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

        public int Cadastrar(ProfessorDTO pProfessor)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO PROFESSOR
                                (PRONOME, PROCPF, PROEMAIL, PROTELEFONE, PROENDCOD, PROUSUCOD, PRODATACRIACAO)
                               VALUES
                                (@PRONOME, @PROCPF, @PROEMAIL, @PROTELEFONE, @PROENDCOD, @PROUSUCOD, @PRODATACRIACAO)";

                AcessoBD.AdicionarParametro("@PRONOME", SqlDbType.VarChar, pProfessor.Nome);
                AcessoBD.AdicionarParametro("@PROCPF", SqlDbType.VarChar, pProfessor.Cpf);
                AcessoBD.AdicionarParametro("@PRODATANASCIMENTO", SqlDbType.VarChar, pProfessor.DataNascimento);
                AcessoBD.AdicionarParametro("@PROSEXO", SqlDbType.VarChar, pProfessor.Sexo);
                AcessoBD.AdicionarParametro("@PROEMAIL", SqlDbType.VarChar, pProfessor.Email);
                AcessoBD.AdicionarParametro("@PROTELEFONE", SqlDbType.VarChar, pProfessor.Telefone);
                AcessoBD.AdicionarParametro("@PROENDCOD", SqlDbType.VarChar, pProfessor.Endereco.Codigo);
                AcessoBD.AdicionarParametro("@PRODISCOD", SqlDbType.VarChar, pProfessor.Disciplina.Codigo);
                AcessoBD.AdicionarParametro("@PROUSUCOD", SqlDbType.VarChar, pProfessor.Usuario.Codigo);
                AcessoBD.AdicionarParametro("@PROINSCOD", SqlDbType.VarChar, pProfessor.Instituicao.Codigo);
                AcessoBD.AdicionarParametro("@PRODATACRIACAO", SqlDbType.VarChar, pProfessor.DataCriacao);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Atualizar(ProfessorDTO pProfessor)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE PROFESSOR SET
                                PRONOME=@PRONOME, PROCPF=@PROCPF, PROEMAIL=@PROEMAIL, PROTELEFONE=@PROTELEFONE
                               WHERE
                                PROCOD=@PROCOD";

                AcessoBD.AdicionarParametro("@PROCOD", SqlDbType.VarChar, pProfessor.Codigo);
                AcessoBD.AdicionarParametro("@PRONOME", SqlDbType.VarChar, pProfessor.Nome);
                AcessoBD.AdicionarParametro("@PROCPF", SqlDbType.VarChar, pProfessor.Cpf);
                AcessoBD.AdicionarParametro("@PRODATANASCIMENTO", SqlDbType.VarChar, pProfessor.DataNascimento);
                AcessoBD.AdicionarParametro("@PROSEXO", SqlDbType.VarChar, pProfessor.Sexo);
                AcessoBD.AdicionarParametro("@PROEMAIL", SqlDbType.VarChar, pProfessor.Email);
                AcessoBD.AdicionarParametro("@PROTELEFONE", SqlDbType.VarChar, pProfessor.Telefone);
                AcessoBD.AdicionarParametro("@PROENDCOD", SqlDbType.VarChar, pProfessor.Endereco.Codigo);
                AcessoBD.AdicionarParametro("@PRODISCOD", SqlDbType.VarChar, pProfessor.Disciplina.Codigo);
                AcessoBD.AdicionarParametro("@PROUSUCOD", SqlDbType.VarChar, pProfessor.Usuario.Codigo);
                AcessoBD.AdicionarParametro("@PROINSCOD", SqlDbType.VarChar, pProfessor.Instituicao.Codigo);
                AcessoBD.AdicionarParametro("@PRODATACRIACAO", SqlDbType.VarChar, pProfessor.DataCriacao);
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

                string sql = @"DELETE FROM PROFESSOR WHERE PROCOD=@PROCOD";
                AcessoBD.AdicionarParametro("@PROCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}