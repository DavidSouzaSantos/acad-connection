using System;
using System.Collections.Generic;
using WebApiAcadConnection.DAOs;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.Models
{
    public class AlunoModel
    {
        private AlunoDAO alunoDAO;
        private AlunoCursoDAO alunoCursoDAO;

        public AlunoModel()
        {
            alunoDAO = new AlunoDAO();
            alunoCursoDAO = new AlunoCursoDAO();
        }

        public List<AlunoDTO> ConsultarPorCurso(int pCodigoCurso)
        {
            List<AlunoDTO> aluno = alunoCursoDAO.ConsultarAlunosPorCurso(pCodigoCurso);

            if (aluno == null || aluno.Count <= 0)
                throw new Exception("Nenhuma aluno foi encontrado");

            return alunoCursoDAO.ConsultarAlunosPorCurso(pCodigoCurso);
        }

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

        public AlunoDTO Cadastrar(AlunoDTO aluno)
        {
            try
            {
                EnderecoDAO enderecoDAO = new EnderecoDAO();
                aluno.Endereco.Codigo = enderecoDAO.Cadastrar(aluno.Endereco);

                UsuarioDAO usuarioDAO = new UsuarioDAO();
                aluno.Usuario.Codigo = usuarioDAO.Cadastrar(aluno.Usuario);

                aluno.Codigo = alunoDAO.Cadastrar(aluno);

                if (aluno.Codigo == null || aluno.Codigo.Value == 0)
                    throw new Exception("Erro ao cadastrar aluno");

                return aluno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AlunoDTO Atualizar(AlunoDTO aluno)
        {
            try
            {
                aluno.Codigo = alunoDAO.Atualizar(aluno);

                if (aluno.Codigo == null || aluno.Codigo.Value == 0)
                    throw new Exception("Erro ao alterar aluno");

                return aluno;
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
                int codigo = alunoDAO.Excluir(pCodigo);

                if (codigo == 0)
                    throw new Exception("Erro ao excluir aluno");

                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int VincularCurso(AlunoCursoDTO alunoCursoDTO)
        {
            try
            {
                int codigo = alunoCursoDAO.Cadastrar(alunoCursoDTO);

                if (codigo == 0)
                    throw new Exception("Erro ao vincular curso");

                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DesvincularCurso(AlunoCursoDTO alunoCursoDTO)
        {
            try
            {
                alunoCursoDTO.Ativo = !alunoCursoDTO.Ativo;
                int codigo = alunoCursoDAO.Atualizar(alunoCursoDTO);

                if (codigo == 0)
                    throw new Exception("Erro ao vincular curso");

                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}