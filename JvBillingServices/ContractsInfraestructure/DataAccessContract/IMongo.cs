using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureContracts.DataAccessContract
{
    public interface IMongo
    {
        Task<Object> Get(int id);
        Task<IList<Object>> Get();
        Task<bool> Update(int id, Object client);
        Task<bool> Delete(int id);
        Task<bool> Create(Object id);

    }
}
