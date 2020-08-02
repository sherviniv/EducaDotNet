using Educa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Educa.Application.Common.Interfaces
{
    public interface IEducaDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        public DbSet<Person> People { get; set; }
    }
}
