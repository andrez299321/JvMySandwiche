using EntitysServices;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.EnumResourse;

namespace LogicsBusiness
{
    public class BaseBL
    {
        public ResponseBase ResponseSuccess()
        {
            return new ResponseBase()
            {
                Message = "OK",
                Status = EnumResponse.Success,
                Data = null
            };
        }
        public ResponseBase ResponseSuccess(string message)
        {
            return new ResponseBase()
            {
                Message = message,
                Status = EnumResponse.Success,
                Data = null
            };
        }
        public ResponseBase ResponseSuccess(string message,object obj)
        {
            return new ResponseBase()
            {
                Message = message,
                Status = EnumResponse.Success,
                Data = obj
            };
        }

        public ResponseBase ResponseError(string message)
        {
            return new ResponseBase()
            {
                Message = message,
                Status = EnumResponse.Error,
                Data = null
            };
        }

        public ResponseBase ResponseDontFound()
        {
            return new ResponseBase()
            {
                Message = "Funcionalidad no existe",
                Status = EnumResponse.DontFound,
                Data = null
            };
        }

        public ResponseBase ResponseDontAutorize()
        {
            return new ResponseBase()
            {
                Message = "Acceso no autorizado",
                Status = EnumResponse.DontAuthorize,
                Data = null
            };
        }
    }
}
