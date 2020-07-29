using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class UsuarioModel
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioModel()
        {
            usuarioDAO = new UsuarioDAO();
        }

        public UsuarioDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                UsuarioDTO usuario = usuarioDAO.ConsultarPorCodigo(pCodigo);

                if (usuario.Codigo == null || usuario.Codigo.Value == 0)
                    throw new Exception("Usuário não encontrado");

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDTO Cadastrar(UsuarioDTO usuario)
        {
            try
            {
                usuario.Codigo = usuarioDAO.Cadastrar(usuario);

                if (usuario.Codigo == null || usuario.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar usuário");

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDTO Atualizar(UsuarioDTO usuario)
        {
            try
            {
                usuario.Codigo = usuarioDAO.Atualizar(usuario);

                if (usuario.Codigo == null || usuario.Codigo.Value == 0)
                    throw new Exception("Erro ao alterar usuário");

                return usuario;
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
                int codigo = usuarioDAO.Excluir(pCodigo);

                if (codigo == 0)
                    throw new Exception("Erro ao excluir usuário");

                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}