using ContractsBusiness;
using DataAccess;
using Dto.Entity;
using EntitysServices;
using EntitysServices.GlobalEntity;
using InfraestructureContracts.DataAccessContract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int id = _DataAccessMongo.Get().Count + 1;
            var result = _DataAccessMongo.Create(new Client() { 
                id = id,
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

            var client = GetUsers();
            var user = client.Where(x => x.Identification == login.User).FirstOrDefault();
            if (user == null)
            {
                return ResponseDontAutorize();
            }
            else
            {
                if (!user.Password.Equals(login.Password))
                {
                    return ResponseDontAutorize();
                }
            }
            return ResponseSuccess();
        }

        public ResponseBase GetAllUser()
        {
            var client =GetUsers();
            return ResponseSuccess("OK", client);
        }

        private List<Client>  GetUsers() {

            var result = _DataAccessMongo.Get();
            var client = new List<Client>();
            foreach (var item in result)
            {
                client.Add((Client)item);
            }
            return client;
        }
    }
}
