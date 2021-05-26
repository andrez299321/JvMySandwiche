using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfraestructureContracts.DataAccessContract
{
    public interface IMongo
    {
        Task<Object> Get(int id);
        List<Object> Get();
        List<Object> GetDetail(int id);
        Task<bool> Update(int id, Object client);
        Task<bool> Delete(int id);
        Task<bool> Create(Object id);

    }
}
