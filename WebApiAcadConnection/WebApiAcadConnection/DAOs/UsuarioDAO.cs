using System;
using System.Data;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class UsuarioDAO
    {
        private AcessoBD AcessoBD;

        public UsuarioDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public UsuarioDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                {
                    string sql = string.Empty;

                    AcessoBD.LimparParanetros();
                    sql = @"SELECT 
                           U.USUCOD, 
                           U.USULOGIN, 
                           U.USUPERFIL
                        FROM USUARIO U
                        WHERE U.USUCOD = @USUCOD";

                    AcessoBD.AdicionarParametro("@USUCOD", SqlDbType.BigInt, pCodigo);

                    DataTable dtUsuario = AcessoBD.ExecutarConsulta(sql);

                    if (dtUsuario.Rows.Count > 0)
                    {
                        DataRow row = dtUsuario.Rows[0];

                        UsuarioDTO usuario = new UsuarioDTO
                        {
                            Codigo = Convert.ToInt32(row["USUCOD"]),
                            Login = row["USULOGIN"].ToString(),
                            Perfil = (Enums.PerfilEnum)Convert.ToInt32(row["USUPERFIL"])
                        };

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDTO ConsultarUsuarioPorCredenciais(string pLogin, string pSenha)
        {
            try
            {
                {
                    string sql = string.Empty;

                    AcessoBD.LimparParanetros();
                    sql = @"SELECT 
                           U.USUCOD, 
                           U.USULOGIN,
                           U.USUPERFIL
                        FROM USUARIO U
                        WHERE U.USULOGIN = @USULOGIN AND
                              U.USUSENHA = @USUSENHA";

                    AcessoBD.AdicionarParametro("@USULOGIN", SqlDbType.VarChar, pLogin);
                    AcessoBD.AdicionarParametro("@USUSENHA", SqlDbType.VarChar, pSenha);

                    DataTable dtUsuario = AcessoBD.ExecutarConsulta(sql);

                    if (dtUsuario.Rows.Count > 0)
                    {
                        DataRow row = dtUsuario.Rows[0];

                        UsuarioDTO usuario = new UsuarioDTO
                        {
                            Codigo = Convert.ToInt32(row["USUCOD"]),
                            Login = row["USULOGIN"].ToString(),
                            Perfil = (Enums.PerfilEnum)Convert.ToInt32(row["USUPERFIL"])
                        };

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Cadastrar(UsuarioDTO pUsuario)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO USUARIO
                                (USULOGIN, USUSENHA, USUPERFIL)
                               VALUES
                                (@USULOGIN, @USUSENHA, @USUPERFIL)";

                AcessoBD.AdicionarParametro("@USULOGIN", SqlDbType.VarChar, pUsuario.Login);
                AcessoBD.AdicionarParametro("@USUSENHA", SqlDbType.VarChar, pUsuario.Senha);
                AcessoBD.AdicionarParametro("@USUPERFIL", SqlDbType.SmallInt, Convert.ToInt32(pUsuario.Perfil.GetValueOrDefault()));

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Alterar(UsuarioDTO pUsuario)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE USUARIO SET
                                USULOGIN=@USULOGIN, USUSENHA=@USUSENHA, USUPERFIL=@USUPERFIL
                               WHERE
                                USUCOD=@USUCOD";

                AcessoBD.AdicionarParametro("@USUCOD", SqlDbType.BigInt, pUsuario.Codigo);
                AcessoBD.AdicionarParametro("@USULOGIN", SqlDbType.VarChar, pUsuario.Login);
                AcessoBD.AdicionarParametro("@USUSENHA", SqlDbType.VarChar, pUsuario.Senha);
                AcessoBD.AdicionarParametro("@USUPERFIL", SqlDbType.SmallInt, Convert.ToInt32(pUsuario.Perfil.GetValueOrDefault()));

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

                string sql = @"DELETE FROM USUARIO WHERE USUCOD=@USUCOD";
                AcessoBD.AdicionarParametro("@USUCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}