
using System;
using System.Collections.Generic;

public abstract class NhanVien
{
    public string HoTen { get; set; }
    public decimal LuongCoBan { get; set; }

    public NhanVien(string ten, decimal luong)
    {
        HoTen = ten;
        LuongCoBan = luong;
    }

    public abstract decimal TinhLuong();
}

public class NhanVienVanPhong : NhanVien
{
    public NhanVienVanPhong(string ten, decimal luong)
        : base(ten, luong) { }

    public override decimal TinhLuong()
    {
        return LuongCoBan + 1000000m;
    }
}

public class NhanVienKinhDoanh : NhanVien
{
    public decimal DoanhSo { get; set; }

    public NhanVienKinhDoanh(string ten, decimal luong, decimal doanhSo)
        : base(ten, luong)
    {
        DoanhSo = doanhSo;
    }

    public override decimal TinhLuong()
    {
        return LuongCoBan + DoanhSo * 0.05m;
    }
}

public class GiangVien : NhanVien
{
    public int SoTiet { get; set; }

    public GiangVien(string ten, decimal luong, int soTiet)
        : base(ten, luong)
    {
        SoTiet = soTiet;
    }

    public override decimal TinhLuong()
    {
        return LuongCoBan + SoTiet * 150000m;
    }
}

class Program
{
    static void Main()
    {
        List<NhanVien> ds = new List<NhanVien>
        {
            new NhanVienVanPhong("Nguyen Van An", 8000000m),
            new NhanVienKinhDoanh("Tran Van Binh", 7000000m, 20000000m),
            new GiangVien("Le Van Cuong", 9000000m, 20)
        };

        Console.WriteLine("=== BANG LUONG NHAN VIEN ===");

        foreach (NhanVien nv in ds)
        {
            Console.WriteLine(
                $"{nv.HoTen,-20} {nv.TinhLuong():N0} VND");
        }

        Console.ReadKey();
    }
}
