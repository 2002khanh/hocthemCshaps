using System.ComponentModel.DataAnnotations;

using System;
using System.Text.RegularExpressions;


namespace bai19.Models
{
      
        public class Student
        {
            [Required(ErrorMessage = "Tên là bắt buộc.")]
            [StringLength(50, ErrorMessage = "Tên không được dài quá 50 ký tự.")]
            [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Tên không được chứa ký tự đặc biệt.")]
            [DataType(DataType.Text)]
            public string? Name { get; set; }

            [Required(ErrorMessage = "Tuổi là bắt buộc.")]
            [Range(18, 100, ErrorMessage = "Tuổi phải từ 18 đến 100.")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Email là bắt buộc.")]
            [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
            public string? Email { get; set; }
        }
    }

