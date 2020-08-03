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
                EnderecoModel enderecoModel = new EnderecoModel();
                aluno.Endereco = enderecoModel.Cadastrar(aluno.Endereco);

                UsuarioModel usuarioModel = new UsuarioModel();
                aluno.Usuario = usuarioModel.Cadastrar(aluno.Usuario);

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

        public AlunoDTO Alterar(AlunoDTO aluno)
        {
            try
            {

                if (aluno.Endereco != null && (aluno.Endereco.Codigo != null && aluno.Endereco.Codigo > 0))
                {
                    EnderecoModel enderecoModel = new EnderecoModel();
                    aluno.Endereco = enderecoModel.Alterar(aluno.Endereco);
                }

                if (aluno.Usuario != null && (aluno.Usuario.Codigo != null && aluno.Usuario.Codigo > 0))
                {
                    UsuarioModel usuarioModel = new UsuarioModel();
                    aluno.Usuario = usuarioModel.Alterar(aluno.Usuario);
                }

                if (!alunoDAO.Alterar(aluno))
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

        public AlunoCursoDTO VincularCurso(AlunoCursoDTO alunoCursoDTO)
        {
            try
            {
                int codigo = alunoCursoDAO.Cadastrar(alunoCursoDTO);

                if (codigo == 0)
                    throw new Exception("Erro ao vincular curso");

                return alunoCursoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AlunoCursoDTO DesvincularCurso(AlunoCursoDTO alunoCursoDTO)
        {
            try
            {
                alunoCursoDTO.Ativo = !alunoCursoDTO.Ativo;
                if (!alunoCursoDAO.Alterar(alunoCursoDTO))
                    throw new Exception("Erro ao vincular curso");

                return alunoCursoDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}