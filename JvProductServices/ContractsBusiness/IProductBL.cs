using System;
using System.Collections.Generic;
using System.Text;
using EntitysServices;
namespace ContractsBusiness
{
    public interface IProductBL
    {
        ResponseBase CreateProduct(ProductRequest client);

        ResponseBase DeleteProduct(int id);

        ResponseBase UpdateProduct(int id, ProductRequest product);

        ResponseBase GetProduct(int id);
        
    }
}
