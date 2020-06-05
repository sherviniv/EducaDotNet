using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Educa.Application.Common.Interfaces
{
    public interface IEducaDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
