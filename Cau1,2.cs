
using System;

public class Nguoi
{
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }

    public Nguoi(string hoTen, DateTime ngaySinh)
    {
        HoTen = hoTen;
        NgaySinh = ngaySinh;
    }

    public virtual string MoTa()
    {
        return $"{HoTen} - {NgaySinh:dd/MM/yyyy}";
    }
}

public class SinhVien : Nguoi
{
    public string MaSV { get; set; }
    public double DiemTB { get; set; }

    public SinhVien(string ma, string ten, DateTime ngaySinh, double diem)
        : base(ten, ngaySinh)
    {
        MaSV = ma;
        DiemTB = diem;
    }

    public override string MoTa()
    {
        return base.MoTa() + $" - {MaSV} - {DiemTB:N2}";
    }
}

class Program
{
    static void Main()
    {
        SinhVien sv = new SinhVien(
            "SV001", "Nguyen Van An",
            new DateTime(2005, 5, 10), 8.5);

        Console.WriteLine("=== THONG TIN SINH VIEN ===");
        Console.WriteLine(sv.MoTa());
        Console.ReadKey();
    }
}
