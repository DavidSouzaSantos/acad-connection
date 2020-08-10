using System;
using System.Collections.Generic;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    ///<summary>
    ///Classe Model de Aluno
    ///</summary>
    public class AlunoModel
    {
        private AlunoDAO alunoDAO;
        private AlunoCursoDAO alunoCursoDAO;

        ///<summary>
        ///Construtor AlunoModel
        ///</summary>
        public AlunoModel()
        {
            alunoDAO = new AlunoDAO();
            alunoCursoDAO = new AlunoCursoDAO();
        }

        ///<summary>
        ///Método para Consultar Alunos pelo Curso
        ///</summary>
        ///<param name="pCodigoCurso">Código do Curso</param>
        public List<AlunoDTO> ConsultarPorCurso(int pCodigoCurso)
        {
            List<AlunoDTO> aluno = alunoCursoDAO.ConsultarAlunosPorCurso(pCodigoCurso);

            if (aluno == null || aluno.Count <= 0)
                throw new Exception("Nenhuma aluno foi encontrado");

            return alunoCursoDAO.ConsultarAlunosPorCurso(pCodigoCurso);
        }

        ///<summary>
        ///Método para Consultar Aluno pelo Código
        ///</summary>
        ///<param name="pCodigo">Código do Aluno</param>
        public AlunoDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
                AlunoDTO aluno = alunoDAO.ConsultarPorCodigo(pCodigo);

                if (aluno.Codigo == null || aluno.Codigo.Value == 0)
                    throw new Exception("Aluno não encontrado");

                return aluno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Cadastrar Aluno
        ///</summary>
        ///<param name="pAluno">Objeto do Aluno</param>
        public AlunoDTO Cadastrar(AlunoDTO pAluno)
        {
            try
            {
                EnderecoModel enderecoModel = new EnderecoModel();
                pAluno.Endereco = enderecoModel.Cadastrar(pAluno.Endereco);

                UsuarioModel usuarioModel = new UsuarioModel();
                pAluno.Usuario = usuarioModel.Cadastrar(pAluno.Usuario);

                pAluno.Codigo = alunoDAO.Cadastrar(pAluno);

                if (pAluno.Codigo == null || pAluno.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar aluno");

                return pAluno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Alterar Aluno
        ///</summary>
        ///<param name="pAluno">Objeto do Aluno</param>
        public AlunoDTO Alterar(AlunoDTO pAluno)
        {
            try
            {

                if (pAluno.Endereco != null && (pAluno.Endereco.Codigo != null && pAluno.Endereco.Codigo > 0))
                {
                    EnderecoModel enderecoModel = new EnderecoModel();
                    pAluno.Endereco = enderecoModel.Alterar(pAluno.Endereco);
                }

                if (pAluno.Usuario != null && (pAluno.Usuario.Codigo != null && pAluno.Usuario.Codigo > 0))
                {
                    UsuarioModel usuarioModel = new UsuarioModel();
                    pAluno.Usuario = usuarioModel.Alterar(pAluno.Usuario);
                }

                if (!alunoDAO.Alterar(pAluno))
                    throw new Exception("Erro ao alterar aluno");

                return pAluno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Excluir Aluno
        ///</summary>
        ///<param name="pCodigo">Código do Aluno</param>
        public int Excluir(int pCodigo)
        {
            try
            {
                AlunoDTO aluno = alunoDAO.ConsultarPorCodigo(pCodigo);

                if(aluno==null)
                    throw new Exception("Aluno não encontrado");



                if (!alunoDAO.Excluir(pCodigo))
                    throw new Exception("Erro ao excluir aluno");

                return pCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Vincular Aluno ao Curso
        ///</summary>
        ///<param name="pAlunoCursoDTO">Objeto do AlunoCurso</param>
        public AlunoCursoDTO VincularCurso(AlunoCursoDTO pAlunoCursoDTO)
        {
            try
            {
                int codigo = alunoCursoDAO.Cadastrar(pAlunoCursoDTO);

                if (codigo == 0)
                    throw new Exception("Erro ao vincular curso");

                return pAlunoCursoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///Método para Desvincular Aluno ao Curso
        ///</summary>
        ///<param name="pAlunoCursoDTO">Objeto do AlunoCurso</param>
        public AlunoCursoDTO DesvincularCurso(AlunoCursoDTO pAlunoCursoDTO)
        {
            try
            {
                pAlunoCursoDTO.Ativo = !pAlunoCursoDTO.Ativo;
                if (!alunoCursoDAO.Alterar(pAlunoCursoDTO))
                    throw new Exception("Erro ao vincular curso");

                return pAlunoCursoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}