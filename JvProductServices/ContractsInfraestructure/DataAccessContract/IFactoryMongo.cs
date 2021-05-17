using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;
using Utils.GlobalEntity;

namespace InfraestructureContracts.DataAccessContract
{
    public interface IFactoryMongo
    {
        IMongo GetMongoObject(EnumMongo type, IOptions<SecretSetting> options);
    }
}
