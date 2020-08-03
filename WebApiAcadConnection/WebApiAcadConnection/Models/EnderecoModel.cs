using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class EnderecoModel
    {
        private EnderecoDAO enderecoDAO;

        public EnderecoModel()
        {
            enderecoDAO = new EnderecoDAO();
        }

        public EnderecoDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                EnderecoDTO endereco = enderecoDAO.ConsultarPorCodigo(pCodigo);

                if (endereco.Codigo == null || endereco.Codigo.Value == 0)
                    throw new Exception("Endereço não encontrado");

                return endereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EnderecoDTO Cadastrar(EnderecoDTO endereco)
        {
            try
            {
                endereco.Codigo = enderecoDAO.Cadastrar(endereco);

                if (endereco.Codigo == null || endereco.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar endereço");

                return endereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EnderecoDTO Alterar(EnderecoDTO endereco)
        {
            try
            {
                if (!enderecoDAO.Alterar(endereco))
                    throw new Exception("Erro ao alterar endereço");

                return endereco;
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
                if (!enderecoDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir endereço");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}