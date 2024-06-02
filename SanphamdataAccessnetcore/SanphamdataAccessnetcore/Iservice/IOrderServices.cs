using SanphamdataAccessnetcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanphamdataAccessnetcore.Iservice
{
    public interface IOrderServices
    {
        Task<Order_CreateReturnData> Order_Create(OrdersCreateRequestData requestData);
    }
}
