using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;

namespace InfraestructureContracts.DataAccessContract
{
    public interface IFactoryMongo
    {
        IMongo GetMongoObject(EnumMongo type);
    }
}
