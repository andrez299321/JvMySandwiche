﻿using ContractsBusiness;
using DataAccess;
using Dto.Entity;
using EntitysServices;
using EntitysServices.GlobalEntity;
using InfraestructureContracts.DataAccessContract;
using Microsoft.Extensions.Options;
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
        public ClientBL(IFactoryMongo factoryMongo, IOptions<SecretSetting> options)
        {
            _factoryMongo = factoryMongo;
            _DataAccessMongo = _factoryMongo.GetMongoObject(EnumMongo.ClientMongo,options);
        }

        public ResponseBase CreateUser(ClientRequest client)
        {
            var result = _DataAccessMongo.Create(new Client() { 
                id =client.Id,
                Identification = client.Identification,
                Name = client.Name,
                LastName = client.LastName,
                Celphone = client.Celphone,
                Password = client.Password
            }).GetAwaiter().GetResult();

            if (result == false) 
            {
                return ResponseError("Error en la insercion");
            }
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
            var result = _DataAccessMongo.Get(id).GetAwaiter().GetResult();
            return ResponseSuccess("OK", result);
        }

        public ResponseBase GetLogin(LoginRequest login)
        {
            var result = _DataAccessMongo.Get().GetAwaiter().GetResult();
            return ResponseSuccess("OK", result);
        }
    }
}
