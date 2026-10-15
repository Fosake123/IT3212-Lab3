
using System;
using System.Collections.Generic;

public interface IPayment
{
    bool ThanhToan(decimal soTien);
    string TenPhuongThuc { get; }
}

public class ThanhToanTienMat : IPayment
{
    public string TenPhuongThuc => "Tien mat";

    public bool ThanhToan(decimal soTien)
    {
        return soTien > 0;
    }
}

public class ChuyenKhoan : IPayment
{
    public string TenPhuongThuc => "Chuyen khoan";

    public bool ThanhToan(decimal soTien)
    {
        return soTien > 0;
    }
}

public class ViDienTu : IPayment
{
    public string TenPhuongThuc => "Vi dien tu";

    public bool ThanhToan(decimal soTien)
    {
        return soTien > 0;
    }
}

class Program
{
    static void Main()
    {
        List<IPayment> ds = new List<IPayment>
        {
            new ThanhToanTienMat(),
            new ChuyenKhoan(),
            new ViDienTu()
        };

        decimal soTien = 500000m;

        Console.WriteLine("=== HE THONG THANH TOAN ===");

        foreach (IPayment p in ds)
        {
            bool thanhCong = p.ThanhToan(soTien);

            Console.WriteLine(
                $"{p.TenPhuongThuc}: " +
                (thanhCong ? "Giao dich hop le" : "Giao dich that bai"));
        }

        Console.ReadKey();
    }
}
