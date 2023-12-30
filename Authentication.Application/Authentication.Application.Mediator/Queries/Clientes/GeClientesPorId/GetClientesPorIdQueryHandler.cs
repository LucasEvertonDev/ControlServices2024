﻿using Authentication.Application.Domain.Contexts.DbAuth.Clientes.Results;

namespace Authentication.Application.Mediator.Queries.Clientes.GeClientesPorId;

public class GetClientesPorIdQueryHandler(IServiceProvider serviceProvider) : BaseHandler(serviceProvider), IRequestHandler<GetClientesPorIdQuery, Result>
{
    public async Task<Result> Handle(GetClientesPorIdQuery request, CancellationToken cancellationToken)
    {
        var cliente = await UnitOfWork.ClienteRepository
            .FirstOrDefaultAsync<ClienteModel>(
                where: cliente => cliente.Id == request.Id,
                cancellationToken: cancellationToken);

        return Result.Ok(cliente);
    }
}
