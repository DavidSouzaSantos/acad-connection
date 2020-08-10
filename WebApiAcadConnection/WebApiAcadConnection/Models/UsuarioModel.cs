using System;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Usuário
    ///</summary>
    public class UsuarioModel
    {
        private UsuarioDAO usuarioDAO;

        ///<summary>
        ///Construtor UsuarioModel
        ///</summary>
        public UsuarioModel()
        {
            usuarioDAO = new UsuarioDAO();
        }

        ///<summary>
        ///Método para Consultar Usuário pelo Código
        ///</summary>
        ///<param name="pCodigo">Código do Usuário</param>
        public UsuarioDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                UsuarioDTO usuario = usuarioDAO.ConsultarPorCodigo(pCodigo);

                if (usuario == null)
                    throw new Exception("Usuário não encontrado");

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Consultar Usuário pelo Login e Senha
        ///</summary>
        ///<param name="pLogin">Login do Usuário</param>
        ///<param name="pSenha">Senha do Usuário</param>cc
        public UsuarioDTO ConsultarUsuarioPorCredenciais(string pLogin, string pSenha)
        {
            try
            {
                UsuarioDTO usuario = usuarioDAO.ConsultarUsuarioPorCredenciais(pLogin, pSenha);

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Usuário
        ///</summary>
        ///<param name="pUsuario">Objeto do Usuário</param>
        public UsuarioDTO Cadastrar(UsuarioDTO pUsuario)
        {
            try
            {
                pUsuario.Codigo = usuarioDAO.Cadastrar(pUsuario);

                if (pUsuario.Codigo == null || pUsuario.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar usuário");

                return pUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Altera Usuário
        ///</summary>
        ///<param name="pUsuario">Objeto do Usuário</param>
        public UsuarioDTO Alterar(UsuarioDTO pUsuario)
        {
            try
            {
                if (!usuarioDAO.Alterar(pUsuario))
                    throw new Exception("Erro ao alterar usuário");

                return pUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Usuário
        ///</summary>
        ///<param name="pCodigo">Objeto do Usuário</param>
        public int Excluir(int pCodigo)
        {
            try
            {
                if(usuarioDAO.ConsultarPorCodigo(pCodigo)==null)
                    throw new Exception("Usuário não existe"); ;

                if (!usuarioDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir usuário");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}