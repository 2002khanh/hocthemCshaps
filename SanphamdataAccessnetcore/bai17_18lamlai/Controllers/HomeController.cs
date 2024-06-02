using bai17_18lamlai.Models;
using Microsoft.AspNetCore.Mvc;
using SanphamdataAccessnetcore.DTO;
using System.Diagnostics;

namespace bai17_18lamlai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            var model = new List<BookModels>();

            // đưa dữ liệu vào model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sách số " + (i + 1)
                });
            }

            // Trả dữ liệu thông qua model về View
            return View(model);
            // thư mục views -> tên của thư mục trùng tên của controller (Home)
            // tìm tiếp file view nào có tên trùng với tên của Action (Index) có đuôi mở rộng là .cshtml
            // Views/Home/Index.cshtml 
        }

        public ActionResult Test()
        {
            var model = new List<BookModels>();

            // đưa dữ liệu vào model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sách số " + (i + 1)
                });
            }
            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> DemoLoadAjaxView()
        {
            var model = new List<Product>();
            try
            {
                model = await new EBook.DataAccess.NetCore.Services.ProductServices().ProductGetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return PartialView(model);
        }

        public async Task<JsonResult> SaveProduct(ProductInsertUpdateRequestData requestData)
        {
            var model = new BookInsertResponse();
            try
            {
                if (requestData == null
                    || string.IsNullOrEmpty(requestData.ProductName))
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Dữ liệu không được trống";
                    return Json(model);
                }

                var rs = await new EBook.DataAccess.NetCore.Services.ProductServices().ProductInsertUpdate(requestData);


                model.ResponseCode = rs.ReturnCode;
                model.ResponseMessage = rs.ReturnMsg;
                return Json(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return Json(model);
        }


        public async Task<JsonResult> Product_Delete(Product_DeleteRequestData requestData)
        {
            var model = new BookDeleteResponse();
            try
            {
                if (requestData == null || requestData.ProductID <= 0)
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Id sản phẩm không hợp lệ";
                    return Json(model);
                }

                var rs = await new EBook.DataAccess.NetCore.Services.ProductServices().Product_Delete(requestData);

                if (rs.ReturnCode <= 0)
                {
                    model.ResponseCode = rs.ReturnCode;
                    model.ResponseMessage = rs.ReturnMsg;
                    return Json(model);
                }

                model.ResponseCode = 1;
                model.ResponseMessage = "Xóa sản phẩm thành công!";
                return Json(model);
            }
            catch (Exception ex)
            {

                model.ResponseCode = -969;
                model.ResponseMessage = "Hệ thống đang bận!";
                return Json(model);
            }
        }

        public async Task<JsonResult> Product_Buy(OrdersCreateRequestData requestData)
        {

            var model = new BookDeleteResponse();
            try
            {
                if (requestData == null || requestData.TotalAmount <= 0)
                {
                    model.ResponseCode = -1;
                    model.ResponseMessage = "Id sản phẩm không hợp lệ";
                    return Json(model);
                }

                var rs = await new EBook.DataAccess.NetCore.Services.OrderServices().Order_Create(requestData);

                if (rs.ReturnCode <= 0)
                {
                    model.ResponseCode = rs.ReturnCode;
                    model.ResponseMessage = rs.ReturnMsg;
                    return Json(model);
                }

                model.ResponseCode = 1;
                model.ResponseMessage = "Mua sản phẩm thành công!";
                return Json(model);
            }
            catch (Exception ex)
            {

                model.ResponseCode = -969;
                model.ResponseMessage = "Hệ thống đang bận!";
                return Json(model);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private List<BookModels> GetBooks()
        {
            var model = new List<BookModels>();

            // đưa dữ liệu vào model
            for (int i = 0; i < 5; i++)
            {
                model.Add(new BookModels
                {
                    BookID = i + 1,
                    BookName = "Sách số " + (i + 1)
                });
            }

            return model;
        }
    }
}