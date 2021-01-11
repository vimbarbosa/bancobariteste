using Vini.Domain.Entities;
using NetDevPack.Data;

namespace Vini.Domain.Interfaces
{
    public interface IHelloRepository : IRepository<Hello>
    {
        void Add(Hello customer);
    }
}