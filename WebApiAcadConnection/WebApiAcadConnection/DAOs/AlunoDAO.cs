using System;
using System.Data;
using WebApiAcadConnection.DAL;
using WebApiAcadConnection.DTOs;

namespace WebApiAcadConnection.DAOs
{
    ///<summary>
    ///Classe DAO de Aluno
    ///</summary>
    public class AlunoDAO
    {
        private AcessoBD AcessoBD;

        ///<summary>
        ///Construtor AlunoDAO
        ///</summary>
        public AlunoDAO()
        {
            AcessoBD = new AcessoBD();
            AcessoBD.ConexaoSql = AcessoBD.ObterConexao();
        }

        ///<summary>
        ///Método para Consultar Aluno pelo Código
        ///</summary>
        ///<param name="pCodigo">Código do Aluno</param>
        public AlunoDTO ConsultarPorCodigo(int pCodigo)
        {
            try
            {
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
                        FROM ALUNO A
                        INNER JOIN 
                                ENDERECO E
                        INNER JOIN 
                                USUARIO U
                        WHERE A.ALUCOD = @ALUCOD AND
                              E.ENDCOD = A.ALUENDCOD AND
                              U.USUCOD = A.ALUUSUCOD";

                AcessoBD.AdicionarParametro("@ALUCOD", SqlDbType.BigInt, pCodigo);

                DataTable dtEndereco = AcessoBD.ExecutarConsulta(sql);

                if (dtEndereco.Rows.Count > 0)
                {
                    DataRow row = dtEndereco.Rows[0];

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

                    return aluno;
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

        ///<summary>
        ///Método para Cadastrar Aluno
        ///</summary>
        ///<param name="pAluno">Objeto do Aluno</param>
        public int Cadastrar(AlunoDTO pAluno)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"INSERT INTO ALUNO
                                (ALUNOME, ALUCPF, ALUDATANASCIMENTO, ALUSEXO, ALUEMAIL, ALUTELEFONE, ALUENDCOD, ALUUSUCOD, ALUDATACRIACAO)
                               VALUES
                                (@ALUNOME, @ALUCPF, @ALUDATANASCIMENTO, @ALUSEXO, @ALUEMAIL, @ALUTELEFONE, @ALUENDCOD, @ALUUSUCOD, @ALUDATACRIACAO)";

                AcessoBD.AdicionarParametro("@ALUNOME", SqlDbType.VarChar, pAluno.Nome);
                AcessoBD.AdicionarParametro("@ALUCPF", SqlDbType.VarChar, pAluno.Cpf);
                AcessoBD.AdicionarParametro("@ALUDATANASCIMENTO", SqlDbType.VarChar, pAluno.DataNascimento);
                AcessoBD.AdicionarParametro("@ALUSEXO", SqlDbType.VarChar, pAluno.Sexo);
                AcessoBD.AdicionarParametro("@ALUEMAIL", SqlDbType.VarChar, pAluno.Email);
                AcessoBD.AdicionarParametro("@ALUTELEFONE", SqlDbType.VarChar, pAluno.Telefone);
                AcessoBD.AdicionarParametro("@ALUENDCOD", SqlDbType.VarChar, pAluno.Endereco.Codigo);
                AcessoBD.AdicionarParametro("@ALUUSUCOD", SqlDbType.VarChar, pAluno.Usuario.Codigo);
                AcessoBD.AdicionarParametro("@ALUDDATACRIACAO", SqlDbType.VarChar, pAluno.DataCriacao);

                return AcessoBD.ExecutarCadastrar(sql);
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
        public bool Alterar(AlunoDTO pAluno)
        {
            try
            {
                AcessoBD.LimparParanetros();
                string sql = @"UPDATE ALUNO SET
                                ALUNOME=@ALUNOME, ALUCPF=@ALUCPF, ALUDATANASCIMENTO=@ALUDATANASCIMENTO, ALUSEXO=@ALUSEXO, ALUEMAIL=@ALUEMAIL, ALUTELEFONE=@ALUTELEFONE
                               WHERE
                                ALUCOD=@ALUCOD";

                AcessoBD.AdicionarParametro("@ALUNOME", SqlDbType.VarChar, pAluno.Nome);
                AcessoBD.AdicionarParametro("@ALUCPF", SqlDbType.VarChar, pAluno.Cpf);
                AcessoBD.AdicionarParametro("@ALUDATANASCIMENTO", SqlDbType.VarChar, pAluno.DataNascimento);
                AcessoBD.AdicionarParametro("@ALUSEXO", SqlDbType.VarChar, pAluno.Sexo);
                AcessoBD.AdicionarParametro("@ALUEMAIL", SqlDbType.VarChar, pAluno.Email);
                AcessoBD.AdicionarParametro("@ALUTELEFONE", SqlDbType.VarChar, pAluno.Telefone);
                AcessoBD.AdicionarParametro("@ALUDDATACRIACAO", SqlDbType.VarChar, pAluno.DataCriacao);

                return AcessoBD.ExecutarComando(sql);
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
        public bool Excluir(int pCodigo)
        {
            try
            {
                AcessoBD.LimparParanetros();

                string sql = @"DELETE FROM ALUNO WHERE ALUCOD=@ALUCOD";
                AcessoBD.AdicionarParametro("@ALUCOD", SqlDbType.BigInt, pCodigo);

                return AcessoBD.ExecutarComando(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}