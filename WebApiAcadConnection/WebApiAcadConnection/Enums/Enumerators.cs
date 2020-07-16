﻿using System.ComponentModel;

namespace WebApiAcadConnection.Enums
{
    public enum PerfilEnum
    {
        [DefaultValue(0)]
        [Description("Não Definido")]
        NaoDefinido,

        [DefaultValue(1)]
        [Description("Administrador")]
        Administrador,

        [DefaultValue(2)]
        [Description("Instituição")]
        Instituicao,

        [DefaultValue(3)]
        [Description("Professor")]
        Professor,

        [DefaultValue(4)]
        [Description("Aluno")]
        Aluno
    }

    public enum SexoEnum
    {
        [DefaultValue("")]
        [Description("Não Definido")]
        NaoDefinido,

        [DefaultValue("F")]
        [Description("Feminino")]
        Feminino,

        [DefaultValue("M")]
        [Description("Masculino")]
        Masculino
    }
}