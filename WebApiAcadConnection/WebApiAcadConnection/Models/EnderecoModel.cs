using System;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Endereço
    ///</summary>
    public class EnderecoModel
    {
        private EnderecoDAO enderecoDAO;

        ///<summary>
        ///Construtor EnderecoModel
        ///</summary>
        public EnderecoModel()
        {
            enderecoDAO = new EnderecoDAO();
        }

        ///<summary>
        ///Método para Consultar Endereço pelo Código
        ///</summary>
        ///<param name="pCodigo">Código do Endereço</param>
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

        ///<summary>
        ///Método para Cadastrar Aluno
        ///</summary>
        ///<param name="pEndereco">Objeto do Endereço</param>
        public EnderecoDTO Cadastrar(EnderecoDTO pEndereco)
        {
            try
            {
                pEndereco.Codigo = enderecoDAO.Cadastrar(pEndereco);

                if (pEndereco.Codigo == null || pEndereco.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar endereço");

                return pEndereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Aluno
        ///</summary>
        ///<param name="pEndereco">Objeto do Endereço</param>
        public EnderecoDTO Alterar(EnderecoDTO pEndereco)
        {
            try
            {
                if (!enderecoDAO.Alterar(pEndereco))
                    throw new Exception("Erro ao alterar endereço");

                return pEndereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Aluno
        ///</summary>
        ///<param name="pCodigo">Código do Endereço</param>
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