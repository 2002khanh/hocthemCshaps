
using EBook.DataAccess.NetCore.DBContext;
using EBook.DataAccess.NetCore.DTO;
using EBook.DataAccess.NetCore.IServices;
using SanphamdataAccessnetcore.Dbcontext;
using SanphamdataAccessnetcore.DTO;
using SanphamdataAccessnetcore.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.Services
{
    public class OrderServices : IOrderServices
    {
        EBookDBContext _eBookDBContext = new EBookDBContext();
        public async Task<Order_CreateReturnData> Order_Create(OrdersCreateRequestData requestData)
        {
            var returnData = new Order_CreateReturnData();
            try
            {
                // kiểm tra 

                var req = new Orders
                {
                    CreatedTime = DateTime.Now,
                    CustomerId = requestData.CustomerId == 0 ? 1 : 0,// fake data
                    ShipingAddress = requestData.ShipingAddress,
                    TotalAmount = requestData.TotalAmount,
                };
                _eBookDBContext.Add(req);
                var ketqua = _eBookDBContext.SaveChangesAsync();

                returnData.ReturnCode = 1;
                returnData.ReturnMsg = "mua sản phẩm thành công";
                return returnData;
            }
            catch (Exception EX)
            {

                returnData.ReturnCode = -969;
                returnData.ReturnMsg = EX.Message;
                return returnData;
            }
        }
    }
}
