﻿using Microsoft.EntityFrameworkCore;
using Nummy.CodeLogger.Data.Entitites;

namespace Nummy.CodeLogger.Data.DataContext;

internal class NummyCodeLoggerDataContext : DbContext
{
    public NummyCodeLoggerDataContext(DbContextOptions<NummyCodeLoggerDataContext> options) : base(options)
    {
    }

    public DbSet<NummyCodeLog> NummyCodeLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }
}