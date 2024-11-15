﻿using FwksLabs.AppService.Core.Abstractions.Repositories;
using FwksLabs.AppService.Core.Resources.Orders;
using FwksLabs.AppService.Infra.Data.Contexts;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.AppService.Infra.Data.Repositories;

public sealed class OrderRepository(DatabaseContext dbContext) : TransactionalRepository<int, OrderEntity>(dbContext), IOrderRepository
{
    public override Task<List<OrderEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        DbSet.Include(x => x.Customer).ToListAsync(cancellationToken);

    public Task<List<OrderEntity>> GetByCustomerIdAsync(int customerId, CancellationToken cancellationToken = default) =>
        DbSet.Include(x => x.Customer).Where(x => x.CustomerId == customerId).ToListAsync(cancellationToken);
}