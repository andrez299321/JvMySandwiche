using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureContracts.DataAccessContract
{
    public interface IMongo
    {
        Task<Object> Get(int id);
        List<object> Get();
        Task<bool> Update(int id, Object payment);
        Task<bool> Delete(int id);
        Task<bool> Create(Object id);

    }
}
