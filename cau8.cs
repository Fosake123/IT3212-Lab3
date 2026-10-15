
using System;
using System.Collections.Generic;
using System.Linq;

public abstract class TaiLieu
{
    public string MaTaiLieu { get; set; }
    public string TieuDe { get; set; }

    public TaiLieu(string ma, string tieuDe)
    {
        MaTaiLieu = ma;
        TieuDe = tieuDe;
    }

    public abstract string ThongTin();
}

public class Sach : TaiLieu
{
    public string TacGia { get; set; }

    public Sach(string ma, string ten, string tacGia)
        : base(ma, ten)
    {
        TacGia = tacGia;
    }

    public override string ThongTin()
    {
        return $"Sach: {MaTaiLieu} - {TieuDe} - Tac gia: {TacGia}";
    }
}

public class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }

    public TapChi(string ma, string ten, int so)
        : base(ma, ten)
    {
        SoPhatHanh = so;
    }

    public override string ThongTin()
    {
        return $"Tap chi: {MaTaiLieu} - {TieuDe} - So: {SoPhatHanh}";
    }
}

public class LuanVan : TaiLieu
{
    public string ChuyenNganh { get; set; }

    public LuanVan(string ma, string ten, string nganh)
        : base(ma, ten)
    {
        ChuyenNganh = nganh;
    }

    public override string ThongTin()
    {
        return $"Luan van: {MaTaiLieu} - {TieuDe} - Nganh: {ChuyenNganh}";
    }
}

class Program
{
    static void Main()
    {
        List<TaiLieu> ds = new List<TaiLieu>
        {
            new Sach("TL01", "Lap trinh C#", "Nguyen Van A"),
            new TapChi("TL02", "Cong nghe thong tin", 5),
            new LuanVan("TL03", "Xay dung phan mem", "Cong nghe phan mem")
        };

        Console.WriteLine("=== DANH SACH TAI LIEU ===");

        foreach (TaiLieu tl in ds)
        {
            Console.WriteLine(tl.ThongTin());
        }

        Console.Write("\nNhap tu khoa tim kiem: ");
        string tuKhoa = Console.ReadLine() ?? "";

        var ketQua = ds.Where(tl =>
            tl.TieuDe.Contains(tuKhoa,
                StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("\n=== KET QUA TIM KIEM ===");

        foreach (TaiLieu tl in ketQua)
        {
            Console.WriteLine(tl.ThongTin());
        }

        Console.ReadKey();
    }
}
