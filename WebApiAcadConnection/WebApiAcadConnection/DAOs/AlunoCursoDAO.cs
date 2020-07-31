using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    public class AlunoCursoDAO
    {
        private AcessoBD AcessoBD;

        public AlunoCursoDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        public List<AlunoDTO> ConsultarAlunosPorCurso(int pCodigoCurso)
        {
            try
            {
                List<AlunoDTO> alunos = new List<AlunoDTO>();
                string sql = string.Empty;
                AcessoBD.LimparParanetros();

                sql = @"SELECT 
                           A.ALUCOD,
                           A.ALUNOME,
                           A.ALUCPF,
                           A.ALUDATANASCIMENTO,
                           A.ALUSEXO,
                           A.ALUEMAIL,
                           A.ALUTELEFONE,
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
                           A.ALUDATACRIACAO
                        FROM ALUNOCURSO AC
                        INNER JOIN 
                                ALUNO A
                        INNER JOIN 
                                CURSO C
                        WHERE 
                             AC.ACCURCOD = @ACCURCOD AND
                             C.CURCOD = AC.ACCURCOD AND
                             A.ALUCOD = AC.ACALUCOD AND
                             P.ENDCOD = A.ALUENDCOD AND
                             U.USUCOD = A.ALUUSUCODD";

                AcessoBD.AdicionarParametro("@ACCURCOD", SqlDbType.BigInt, pCodigoCurso);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {
                    foreach (DataRow row in dtEndereco.Rows)
                    {
                        AlunoDTO aluno = new AlunoDTO()
                        {
                            Codigo = Convert.ToInt32(row["ALUCOD"]),
                            Nome = row["ALUNOME"].ToString(),
                            Cpf = row["ALUCPF"].ToString(),
                            DataNascimento = DateTime.Parse(row["ALUDATANASCIMENTO"].ToString()),
                            Sexo = (Enums.SexoEnum)row["ALUSEXO"],
                            Email = row["ALUEMAIL"].ToString(),
                            Telefone = row["ALUTELEFONE"].ToString(),
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
                            DataCriacao = DateTime.Parse(row["ALUDATACRIACAO"].ToString())
                        };

                        alunos.Add(aluno);
                    }

                    return alunos;
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

        public List<CursoDTO> ConsultarCursosPorAluno(int pCodigoAluno)
        {
            try
            {
                List<CursoDTO> cursos = new List<CursoDTO>();
                string sql = string.Empty;
                AcessoBD.LimparParanetros();

                sql = @"SELECT
                           C.CURCOD,
                           C.CURNOME,
                           C.CURDESCRICAO,
                           C.CURDATAINICIO,
                           C.CURDATAFIM,
                           C.CURDURACAO,
                               ---C.CURPROCOD,
                               ---C.CURDISCOD,
                               ---C.CURINSCOD,
                           C.CURDATACRIACAO
                        FROM ALUNOCURSO AC
                        INNER JOIN 
                                ALUNO A
                        INNER JOIN 
                                CURSO C
                        WHERE 
                             AC.ACCURCOD = @ACCURCOD AND
                             A.ALUCOD = AC.ACALUCOD AND
                             C.CURCOD = AC.ACCURCOD AND 
                             P.PROCOD = C.CURPROCOD AND
                             D.DISCOD = C.CURDISCOD AND
                             I.INSCOD = C.CURINSCOD";
                AcessoBD.AdicionarParametro("@ACCURCOD", SqlDbType.BigInt, pCodigoAluno);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {
                    foreach (DataRow row in dtEndereco.Rows)
                    {
                        CursoDTO curso = new CursoDTO()
                        {
                            Codigo = Convert.ToInt32(row["ALUCOD"]),
                            Nome = row["ALUNOME"].ToString(),

                            DataCriacao = DateTime.Parse(row["ALUDATACRIACAO"].ToString())
                        };

                        cursos.Add(curso);
                    }

                    return cursos;
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

        public int Cadastrar(AlunoCursoDTO pAlunoCurso)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO ALUNOCURSO
                                (ACALUCOD, ACCURCOD)
                               VALUES
                                (@ACALUCOD, @ACCURCOD)";

                AcessoBD.AdicionarParametro("@ACALUCOD", SqlDbType.BigInt, pAlunoCurso.Aluno.Codigo);
                AcessoBD.AdicionarParametro("@ACCURCOD", SqlDbType.BigInt, pAlunoCurso.Curso.Codigo);

                return AcessoBD.ExecutarCadastrar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Atualizar(AlunoCursoDTO pAlunoCurso)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE ALUNOCURSO SET
                                ACATIVO = @ACATIVO
                               WHERE
                                ACALUCOD = @ACALUCOD AND
                                ACCURCOD = @ACCURCOD";

                AcessoBD.AdicionarParametro("@ACALUCOD", SqlDbType.BigInt, pAlunoCurso.Aluno.Codigo);
                AcessoBD.AdicionarParametro("@ACCURCOD", SqlDbType.BigInt, pAlunoCurso.Curso.Codigo);
                AcessoBD.AdicionarParametro("@ACATIVO", SqlDbType.Bit, pAlunoCurso.Ativo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int pCodigoAluno, int pCodigoCurso)
        {
            try
            {
                AcessoBD.LimparParanetros();

                string sql = @"DELETE FROM ALUNOCURSO WHERE ACALUCOD = @ACALUCOD AND ACCURCOD = @ACCURCOD";

                AcessoBD.AdicionarParametro("@ACALUCOD", SqlDbType.BigInt, pCodigoAluno);
                AcessoBD.AdicionarParametro("@ACCURCOD", SqlDbType.BigInt, pCodigoCurso);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}