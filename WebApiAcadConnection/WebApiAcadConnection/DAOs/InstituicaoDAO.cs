using System;
using System.Data;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class InstituicaoDAO
    {
        private AcessoBD AcessoBD;

        public InstituicaoDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public InstituicaoDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                string sql = string.Empty;

                AcessoBD.LimparParanetros();
                sql = @"SELECT 
                           I.INSCOD,
                           I.INSNOME,
                           I.INSDESCRICAO,
                           I.INSCNPJ,
                           I.INSSEXO,
                           I.INSEMAIL,
                           I.INSTELEFONE,
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
                           I.INSDATACRIACAO
                        FROM INSTITUICAO I
                        INNER JOIN 
                                ENDERECO E
                        INNER JOIN 
                                USUARIO U
                        WHERE I.INSCOD = @INSCOD AND
                              E.ENDCOD = I.INSENDCOD AND
                              U.USUCOD = I.INSUSUCOD";

                AcessoBD.AdicionarParametro("@INSCOD", SqlDbType.BigInt, pCodigo);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {
                    DataRow row = dtEndereco.Rows[0];
                    
                    InstituicaoDTO instituicao = new InstituicaoDTO()
                    {
                        Codigo = Convert.ToInt32(row["INSCOD"]),
                        Nome = row["INSNOME"].ToString(),
                        Descricao = row["INSDESCRICAO"].ToString(),
                        Cnpj = row["INSCNPJ"].ToString(),
                        Email = row["INSEMAIL"].ToString(),
                        Telefone = row["INSTELEFONE"].ToString(),
                        Endereco = new EnderecoDTO()
                        {
                            Codigo = Convert.ToInt32(row["ENDCOD"]),
                            Cep = row["ENCEP"].ToString(),
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
                        DataCriacao = DateTime.Parse(row["INSDATACRIACAO"].ToString())
                    };

                    return instituicao;
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

        public int Cadastrar(InstituicaoDTO pInstituicao)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO INSTITUICAO
                                (INSNOME, INSDESCRICAO, INSCNPJ, INSEMAIL, INSTELEFONE, INSENDCOD, INSUSUCOD, INSDATACRIACAO)
                               VALUES
                                (@INSNOME, @INSDESCRICAO, @INSCNPJ, @INSEMAIL, @INSTELEFONE, @INSENDCOD, @INSUSUCOD, @INSDATACRIACAO)";

                AcessoBD.AdicionarParametro("@INSNOME", SqlDbType.VarChar, pInstituicao.Nome);
                AcessoBD.AdicionarParametro("@INSDESCRICAO", SqlDbType.VarChar, pInstituicao.Descricao);
                AcessoBD.AdicionarParametro("@INSCNPJ", SqlDbType.VarChar, pInstituicao.Cnpj);
                AcessoBD.AdicionarParametro("@INSEMAIL", SqlDbType.VarChar, pInstituicao.Email);
                AcessoBD.AdicionarParametro("@INSTELEFONE", SqlDbType.VarChar, pInstituicao.Telefone);
                AcessoBD.AdicionarParametro("@INSENDCOD", SqlDbType.VarChar, pInstituicao.Endereco.Codigo);
                AcessoBD.AdicionarParametro("@INSUSUCOD", SqlDbType.VarChar, pInstituicao.Usuario.Codigo);
                AcessoBD.AdicionarParametro("@INSDATACRIACAO", SqlDbType.VarChar, pInstituicao.DataCriacao);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(InstituicaoDTO pInstituicao)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE INSTITUICAO SET
                                INSNOME=@INSNOME, INSDESCRICAO=@INSDESCRICAO, INSCNPJ=@INSCNPJ, INSEMAIL=@INSEMAIL, INSTELEFONE=@INSTELEFONE
                               WHERE
                                INSCOD=@INSCOD";

                AcessoBD.AdicionarParametro("@INSNOME", SqlDbType.VarChar, pInstituicao.Nome);
                AcessoBD.AdicionarParametro("@INSDESCRICAO", SqlDbType.VarChar, pInstituicao.Descricao);
                AcessoBD.AdicionarParametro("@INSCNPJ", SqlDbType.VarChar, pInstituicao.Cnpj);
                AcessoBD.AdicionarParametro("@INSEMAIL", SqlDbType.VarChar, pInstituicao.Email);
                AcessoBD.AdicionarParametro("@INSTELEFONE", SqlDbType.VarChar, pInstituicao.Telefone);
                AcessoBD.AdicionarParametro("@INSENDCOD", SqlDbType.VarChar, pInstituicao.Endereco.Codigo);
                AcessoBD.AdicionarParametro("@INSUSUCOD", SqlDbType.VarChar, pInstituicao.Usuario.Codigo);
                AcessoBD.AdicionarParametro("@INSDATACRIACAO", SqlDbType.VarChar, pInstituicao.DataCriacao);

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

                string sql = @"DELETE FROM INSTITUICAO WHERE INSCOD=@INSCOD";
                AcessoBD.AdicionarParametro("@INSCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
