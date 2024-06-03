using LvdBaiDanhGiaGiuaKi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LvdBaiDanhGiaGiuaKi.Controllers
{
    public class LvdController : Controller
    {

        private static List<LvdProduct> LvdProducts = new List<LvdProduct>
    {
        new LvdProduct { Id = 1, Name = "Product 1", Image = "image1.jpg", Quantity = 10, Price = 20.50M, IsActive = true },
        new LvdProduct { Id = 2, Name = "Product 2", Image = "image2.jpg", Quantity = 5, Price = 15.75M, IsActive = false }
    };

        // Action để hiển thị danh sách sản phẩm
        public ActionResult Index()
        {
            return View(LvdProducts);
        }

        // Action để hiển thị form tạo mới sản phẩm
        public ActionResult Create()
        {
            return View();
        }

        // Action để xử lý việc tạo mới sản phẩm
        [HttpPost]
        public ActionResult Create(LvdProduct product)
        {
            if (ModelState.IsValid)
            {
                product.Id = LvdProducts.Count + 1; // Tạm thời tăng Id theo số lượng đã có
                LvdProducts.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Action để hiển thị form chỉnh sửa sản phẩm
        public ActionResult Edit(int id)
        {
            var product = LvdProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // Action để xử lý việc chỉnh sửa sản phẩm
        [HttpPost]
        public ActionResult Edit(int id, LvdProduct updatedProduct)
        {
            var product = LvdProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                product.Name = updatedProduct.Name;
                product.Image = updatedProduct.Image;
                product.Quantity = updatedProduct.Quantity;
                product.Price = updatedProduct.Price;
                product.IsActive = updatedProduct.IsActive;

                return RedirectToAction("Index");
            }

            return View(updatedProduct);
        }

        // Action để xóa sản phẩm
        public ActionResult Delete(int id)
        {
            var product = LvdProducts.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            LvdProducts.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
