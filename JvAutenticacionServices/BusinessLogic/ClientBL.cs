using ContractsBusiness;
using DataAccess;
using DataAccess.Entity;
using EntitysServices;
using InfraestructureContracts.DataAccessContract;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;

namespace LogicsBusiness
{
    public class ClientBL : BaseBL, IClientBL
    {
        IFactoryMongo _factoryMongo;
        IMongo _DataAccessMongo;
        public ClientBL(IFactoryMongo factoryMongo)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.ClientMongo);
        }

        public ResponseBase CreateUser(ClientRequest client)
        {
            _DataAccessMongo.Create(client);
            return ResponseSuccess();
        }

        public ResponseBase DeleteUser(int id)
        {
            _DataAccessMongo.Delete(id);
            return ResponseSuccess();
        }
        public ResponseBase UpdateUser(int id, ClientRequest client)
        {
            
            _DataAccessMongo.Update(id, client);
            return ResponseSuccess();
        }
        public ResponseBase GetUser(int id)
        {
            _DataAccessMongo.Get(id);
            return ResponseSuccess();
        }
    }
}
