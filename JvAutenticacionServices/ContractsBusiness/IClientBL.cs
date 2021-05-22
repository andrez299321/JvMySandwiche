using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
namespace ContractsBusiness
{
    public interface IClientBL
    {
        ResponseBase CreateUser(ClientRequest client);

        ResponseBase DeleteUser(int id);

        ResponseBase UpdateUser(int id, ClientRequest client);

        ResponseBase GetUser(int id);

        ResponseBase GetLogin(LoginRequest login);

    }
}
