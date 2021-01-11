using System;
using System.Threading.Tasks;
using Vini.Domain.Interfaces;
using Vini.Domain.Entities;
using Vini.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Vini.Infra.Data.Repository
{
    public class HelloRepository : IHelloRepository
    {
        protected readonly ViniContext Db;
        protected readonly DbSet<Hello> DbSet;

        public HelloRepository(ViniContext context)
        {
            Db = context;
            DbSet = Db.Set<Hello>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Hello> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Add(Hello customer)
        {
           DbSet.Add(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
