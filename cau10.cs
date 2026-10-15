
using System;
using System.Collections.Generic;
using System.Linq;

public interface IPrintable
{
    string ToDisplayText();
}

public abstract class SinhVien : IPrintable
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }

    public SinhVien(string ma, string ten)
    {
        MaSV = ma;
        HoTen = ten;
    }

    public abstract string LoaiSinhVien();

    public virtual string ToDisplayText()
    {
        return $"{MaSV} - {HoTen} - {LoaiSinhVien()}";
    }
}

public class SinhVienChinhQuy : SinhVien
{
    public SinhVienChinhQuy(string ma, string ten)
        : base(ma, ten) { }

    public override string LoaiSinhVien() => "Chinh quy";
}

public class SinhVienLienThong : SinhVien
{
    public SinhVienLienThong(string ma, string ten)
        : base(ma, ten) { }

    public override string LoaiSinhVien() => "Lien thong";
}

class Program
{
    static void Main()
    {
        List<SinhVien> ds = new List<SinhVien>
        {
            new SinhVienChinhQuy("SV001", "Nguyen Van An"),
            new SinhVienLienThong("SV002", "Tran Thi Binh"),
            new SinhVienChinhQuy("SV003", "Le Van Cuong")
        };

        int chon;

        do
        {
            Console.WriteLine("\n=== QUAN LY SINH VIEN ===");
            Console.WriteLine("1. Hien thi danh sach");
            Console.WriteLine("2. Tim sinh vien theo ma");
            Console.WriteLine("3. Thong ke theo loai");
            Console.WriteLine("0. Thoat");
            Console.Write("Nhap lua chon: ");

            if (!int.TryParse(Console.ReadLine(), out chon))
            {
                chon = -1;
            }

            switch (chon)
            {
                case 1:
                    foreach (SinhVien sv in ds)
                    {
                        Console.WriteLine(sv.ToDisplayText());
                    }
                    break;

                case 2:
                    Console.Write("Nhap ma sinh vien: ");
                    string ma = Console.ReadLine() ?? "";

                    SinhVien? tim = ds.FirstOrDefault(
                        sv => sv.MaSV.Equals(
                            ma, StringComparison.OrdinalIgnoreCase));

                    Console.WriteLine(tim == null
                        ? "Khong tim thay sinh vien"
                        : tim.ToDisplayText());
                    break;

                case 3:
                    Console.WriteLine("Chinh quy: " +
                        ds.Count(sv => sv is SinhVienChinhQuy));

                    Console.WriteLine("Lien thong: " +
                        ds.Count(sv => sv is SinhVienLienThong));
                    break;

                case 0:
                    Console.WriteLine("Ket thuc chuong trinh");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le");
                    break;
            }

        } while (chon != 0);
    }
}
