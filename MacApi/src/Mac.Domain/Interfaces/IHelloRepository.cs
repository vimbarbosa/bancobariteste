using Mac.Domain.Entities;
using NetDevPack.Data;

namespace Mac.Domain.Interfaces
{
    public interface IHelloRepository : IRepository<Hello>
    {
        void Add(Hello customer);
    }
}