﻿namespace Authentication.Application.Domain.Contexts.DbAuth.Servicos;
public static class ServicoFailures
{
    public static readonly FailureModel ServicoNaoEncontrado = new("ServicoNaoEncontrado", "Não foi possível recuperar o serviço informado.");

    public static readonly FailureModel NomeObrigatorio = new("NomeObrigatorio", "Nome é obrigatório.");
}
