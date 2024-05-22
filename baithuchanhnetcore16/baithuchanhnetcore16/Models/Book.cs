namespace baithuchanhnetcore16.Models
{ 

  
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public class Book
    {

            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Key]
            [Required(ErrorMessage = "id không được để trống ")]
            [DisplayName("mã sách")]
            public int ID { get; set; }

            [Required(ErrorMessage = "tên sách không được để trống ")]

            [StringLength(50)]
            [DisplayName("Tên  sách")]
            public string TenSach { get; set; }

            [Required(ErrorMessage = "tên tác giả không được để trống ")]
            [StringLength(50)]
            [DisplayName("tác giả")]
            public string TacGia { get; set; }

            [DisplayName("năm xuất bản")]
            [DataType(DataType.Date)]
            public DateTime NXB { get; set; }
    }  }


