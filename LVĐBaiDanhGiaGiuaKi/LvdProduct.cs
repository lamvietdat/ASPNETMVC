using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LvdBaiDanhGiaGiuaKi.Models
{
    public class LvdProduct
    {
            public int Id { get; set; }
            [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
            [RegularExpression(@"^[A-Z ]{5,100}$", ErrorMessage = "Tên sản phẩm chỉ chứa ký tự viết hoa và khoảng trắng, độ dài từ 5 đến 100 ký tự")]
            public string Name { get; set; }
            public string Image { get; set; }
            [Required(ErrorMessage = "Số lượng sản phẩm không được để trống")]
            [Range(1, 100, ErrorMessage = "Số lượng sản phẩm phải nằm trong khoảng từ 1 đến 100")]
            public int Quantity { get; set; }
            [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0")]
            public decimal Price { get; set; }
            public bool IsActive { get; set; }
    }
}