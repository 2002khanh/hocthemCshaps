// See https://aka.ms/new-console-template for more information
using congnhan.Dbcontext;
using congnhan.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


class program
{

    static void Main(string[] args)
    {
        using (var context = new NhanViencm())
        {
            // Tạo cơ sở dữ liệu nếu chưa có
            context.Database.Migrate();

            while (true)
            {
                Console.WriteLine("Chọn chức năng:");
                Console.WriteLine("1. Thêm nhân viên");
                Console.WriteLine("2. Sửa nhân viên");
                Console.WriteLine("3. Xóa nhân viên");
                Console.WriteLine("4. Tìm kiếm nhân viên");
                Console.WriteLine("5. Xuất báo cáo");
                Console.WriteLine("0. Thoát");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ThemNhanVien(context);
                        break;
                    case "2":
                        SuaNhanVien(context);
                        break;
                    case "3":
                        XoaNhanVien(context);
                        break;
                    case "4":
                        TimKiemNhanVien(context);
                        break;
                    case "5":
                        XuatBaoCao(context);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }
            }
        }
    }

    static void ThemNhanVien(NhanViencm context)
    {
        Console.Write("Nhập tên nhân viên: ");
        var hoTen = Console.ReadLine();
        Console.Write("Nhập chuyền may: ");
        var chuyenMay = Console.ReadLine();

        var nhanVien = new NhanVien { HoTen = hoTen, ChuyenMay = chuyenMay };

        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<NhanVien> entityEntry = context.NhanViens.Add(nhanVien);

        context.SaveChanges();

        Console.WriteLine("Thêm nhân viên thành công!");
    }

    static void SuaNhanVien(NhanViencm context)
    {
        Console.Write("Nhập ID nhân viên cần sửa: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var nhanVien = context.NhanViens.Find(id);
            if (nhanVien != null)
            {
                Console.Write("Nhập tên mới: ");
                nhanVien.HoTen = Console.ReadLine();
                Console.Write("Nhập chuyền may mới: ");
                nhanVien.ChuyenMay = Console.ReadLine();

                context.SaveChanges();
                Console.WriteLine("Sửa thông tin nhân viên thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy nhân viên!");
            }
        }
        else
        {
            Console.WriteLine("ID không hợp lệ!");
        }
    }

    static void XoaNhanVien(NhanViencm context)
    {
        Console.Write("Nhập ID nhân viên cần xóa: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var nhanVien = context.NhanViens.Find(id);
            if (nhanVien != null)
            {
                context.NhanViens.Remove(nhanVien);
                context.SaveChanges();
                Console.WriteLine("Xóa nhân viên thành công!");
            }
            else
            {
                Console.WriteLine("Không tìm thấy nhân viên!");
            }
        }
        else
        {
            Console.WriteLine("ID không hợp lệ!");
        }
    }

    static void TimKiemNhanVien(NhanViencm context)
    {
        Console.WriteLine("Tìm kiếm theo:");
        Console.WriteLine("1. Tên");
        Console.WriteLine("2. Chuyền may");
        var choice = Console.ReadLine();

        IQueryable<NhanVien> query = context.NhanViens;

        switch (choice)
        {
            case "1":
                Console.Write("Nhập tên nhân viên: ");
                var ten = Console.ReadLine();
                query = query.Where(nv => nv.HoTen.Contains(ten));
                break;
            case "2":
                Console.Write("Nhập chuyền may: ");
                var chuyenMay = Console.ReadLine();
                query = query.Where( nv => nv.ChuyenMay.Contains(chuyenMay));
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ");
                return;
        }

        var nhanViens = query.ToList();
        foreach (var nv in nhanViens)
        {
            Console.WriteLine($"ID: {nv.NhanVienId}, Tên: {nv.HoTen}, Chuyền may: {nv.ChuyenMay}");
        }
    }

    static void XuatBaoCao(NhanViencm context)
    {
        var baoCao = context.NhanViens
            .GroupBy(nv => nv.HoTen)
            .Select(nv => new
            {
                Hoten = nv.Key,
             ChuyenMay = nv.Key,
                
            }) 
            .ToList();

        Console.WriteLine("Báo cáo:");
        foreach (var item in baoCao)
        {
            Console.WriteLine($"Tên: {item.Hoten}, Chuyền may: {item.ChuyenMay}");
        }
    }
}