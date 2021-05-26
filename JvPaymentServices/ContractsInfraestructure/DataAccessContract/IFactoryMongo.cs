﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices.GlobalEntity;
using Utils.EnumResourse;

namespace InfraestructureContracts.DataAccessContract
{
    public interface IFactoryMongo
    {
        IMongo GetMongoObject(EnumMongo type, IOptions<SecretSetting> options);
    }
}
