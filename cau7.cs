
using System;
using System.Collections.Generic;

public interface IMove
{
    double TocDo();
    decimal ChiPhiVanHanh(int soKm);
}

public class XeMay : IMove
{
    public double TocDo() => 60;

    public decimal ChiPhiVanHanh(int soKm)
    {
        return soKm * 1000m;
    }
}

public class OTo : IMove
{
    public double TocDo() => 100;

    public decimal ChiPhiVanHanh(int soKm)
    {
        return soKm * 3000m;
    }
}

public class XeDap : IMove
{
    public double TocDo() => 20;

    public decimal ChiPhiVanHanh(int soKm)
    {
        return soKm * 100m;
    }
}

class Program
{
    static void Main()
    {
        List<IMove> ds = new List<IMove>
        {
            new XeMay(),
            new OTo(),
            new XeDap()
        };

        string[] ten = { "Xe may", "O to", "Xe dap" };
        int soKm = 50;

        for (int i = 0; i < ds.Count; i++)
        {
            Console.WriteLine($"Phuong tien: {ten[i]}");
            Console.WriteLine($"Toc do: {ds[i].TocDo()} km/h");
            Console.WriteLine(
                $"Chi phi {soKm} km: {ds[i].ChiPhiVanHanh(soKm):N0} VND");
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
