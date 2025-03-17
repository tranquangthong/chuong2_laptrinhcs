using System;
using System.Collections.Generic;
using System.Linq;

class NhanVien
{
    public int id { get; set; }
    public string ten { get; set; }
    public int tuoi { get; set; }
    public decimal luong { get; set; }
    public int phong_ban_id { get; set; }
}

class PhongBan
{
    public int id { get; set; }
    public string ten_phong_ban { get; set; }
}

class Program
{
    static void Main()
    {
        List<PhongBan> danh_sach_phong_ban = new List<PhongBan>();
        List<NhanVien> danh_sach_nhan_vien = new List<NhanVien>();

        Console.WriteLine("Ho va ten: Tran Quang Thong - MSSV:23115053122141");
        Console.WriteLine("------------------------------\n");
        Console.Write("Nhap so luong phong ban: ");
        int so_phong_ban = int.Parse(Console.ReadLine());

        for (int i = 0; i < so_phong_ban; i++)
        {
            Console.WriteLine($"Nhap thong tin phong ban {i + 1}:");
            Console.Write("ID phong ban: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Ten phong ban: ");
            string ten_phong_ban = Console.ReadLine();

            danh_sach_phong_ban.Add(new PhongBan { id = id, ten_phong_ban = ten_phong_ban });
        }
        Console.Write("\nNhap so luong nhan vien: ");
        int so_nhan_vien = int.Parse(Console.ReadLine());

        for (int i = 0; i < so_nhan_vien; i++)
        {
            Console.WriteLine($"\nNhap thong tin nhan vien {i + 1}:");
            Console.Write("ID nhan vien: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Ten nhan vien: ");
            string ten = Console.ReadLine();
            Console.Write("Tuoi: ");
            int tuoi = int.Parse(Console.ReadLine());
            Console.Write("Luong: ");
            decimal luong = decimal.Parse(Console.ReadLine());
            Console.Write("ID phong ban: ");
            int phong_ban_id = int.Parse(Console.ReadLine());

            danh_sach_nhan_vien.Add(new NhanVien { id = id, ten = ten, tuoi = tuoi, luong = luong, phong_ban_id = phong_ban_id });
        }
        var danh_sach_join = from nv in danh_sach_nhan_vien
                             join pb in danh_sach_phong_ban on nv.phong_ban_id equals pb.id
                             select new { nv.ten, pb.ten_phong_ban, nv.tuoi, nv.luong };

        Console.WriteLine("\nDanh sach nhan vien va phong ban:");
        foreach (var nv in danh_sach_join)
        {
            Console.WriteLine($"Ten: {nv.ten}, Phong Ban: {nv.ten_phong_ban}, Tuoi: {nv.tuoi}, Luong: {nv.luong}");
        }
        var thong_141 = danh_sach_nhan_vien
            .GroupBy(nv => nv.phong_ban_id)
            .Select(g =>
            {
                var ten_phong_ban = danh_sach_phong_ban.First(pb => pb.id == g.Key).ten_phong_ban;
                var min_tuoi = g.Min(nv => nv.tuoi);
                var max_tuoi = g.Max(nv => nv.tuoi);
                var tre_nhat = g.Where(nv => nv.tuoi == min_tuoi).ToList();
                var gia_nhat = g.Where(nv => nv.tuoi == max_tuoi).ToList();
                var tuoi_trung_binh = g.Average(nv => nv.tuoi);

                return new { ten_phong_ban, tre_nhat, gia_nhat, tuoi_trung_binh };
            });

        Console.WriteLine("\nThong tin nhan vien theo phong:");
        foreach (var pb in thong_141)
        {
            Console.WriteLine($"Phong Ban: {pb.ten_phong_ban}");

            Console.Write("- Tre nhat: ");
            foreach (var nv in pb.tre_nhat)
            {
                Console.Write($"{nv.ten} ({nv.tuoi} tuoi), ");
            }
            Console.WriteLine();

            Console.Write("- Gia nhat: ");
            foreach (var nv in pb.gia_nhat)
            {
                Console.Write($"{nv.ten} ({nv.tuoi} tuoi), ");
            }
            Console.WriteLine();

            Console.WriteLine($"- Tuoi trung binh: {pb.tuoi_trung_binh:F1}");
        }
        var luong_trung_binh = danh_sach_nhan_vien.Average(nv => nv.luong);
        Console.WriteLine($"\nLuong trung binh cua cong ty: {luong_trung_binh:N0} VND");

    }
}
