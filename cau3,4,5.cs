
using System;
using System.Collections.Generic;

public abstract class NguoiHoc
{
    public string HoTen { get; set; } = "";
    public int SoTinChi { get; set; }

    public abstract decimal TinhHocPhi();
}

public class SinhVienChinhQuy : NguoiHoc
{
    public override decimal TinhHocPhi()
    {
        return SoTinChi * 450000m;
    }
}

public class SinhVienLienThong : NguoiHoc
{
    public override decimal TinhHocPhi()
    {
        return SoTinChi * 520000m;
    }
}

public interface IValidatable
{
    bool IsValid(out string message);
}

public interface IPrintable
{
    string ToDisplayText();
}

public class SinhVienThongTin : IValidatable, IPrintable
{
    public string MaSV { get; set; } = "";
    public string HoTen { get; set; } = "";
    public double DiemTB { get; set; }

    public bool IsValid(out string message)
    {
        if (string.IsNullOrWhiteSpace(MaSV))
        {
            message = "Thieu ma sinh vien";
            return false;
        }

        if (string.IsNullOrWhiteSpace(HoTen))
        {
            message = "Thieu ho ten";
            return false;
        }

        if (DiemTB < 0 || DiemTB > 10)
        {
            message = "Diem phai tu 0 den 10";
            return false;
        }

        message = "Du lieu hop le";
        return true;
    }

    public string ToDisplayText()
    {
        return $"{MaSV} - {HoTen} - Diem: {DiemTB:N2}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== KIEM TRA INTERFACE ===");

        SinhVienThongTin sv = new SinhVienThongTin
        {
            MaSV = "SV001",
            HoTen = "Nguyen Van An",
            DiemTB = 8.5
        };

        Console.WriteLine(sv.IsValid(out string message)
            ? message
            : "Loi: " + message);

        Console.WriteLine(sv.ToDisplayText());

        Console.WriteLine("\n=== DANH SACH HOC PHI ===");

        List<NguoiHoc> ds = new List<NguoiHoc>
        {
            new SinhVienChinhQuy
            {
                HoTen = "Nguyen Van An",
                SoTinChi = 18
            },
            new SinhVienLienThong
            {
                HoTen = "Tran Thi Binh",
                SoTinChi = 15
            }
        };

        decimal tong = 0;

        foreach (NguoiHoc item in ds)
        {
            decimal hocPhi = item.TinhHocPhi();
            tong += hocPhi;
            Console.WriteLine(
                $"{item.HoTen}: {hocPhi:N0} VND");
        }

        Console.WriteLine($"Tong hoc phi: {tong:N0} VND");
        Console.ReadKey();
    }
}
