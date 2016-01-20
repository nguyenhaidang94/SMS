using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE.Data;

namespace SMS.DATA.Models
{
    public class BangDiemViewModel
    {
        public int MaBangDiem { get; set; }

        public int MaHocSinh { get; set; }

        public string TenHocSinh { get; set; }

        public int MaLop{ get; set; }

        public int MaMonHoc { get; set; }

        public int MaDiemMieng_1 { get; set; }

        public float? DiemMieng_1 { get; set; }

        public int MaDiemMieng_2 { get; set; }

        public float? DiemMieng_2 { get; set; }

        public int MaDiem15_1 { get; set; }

        public float? Diem15_1 { get; set; }

        public int MaDiem15_2 { get; set; }

        public float? Diem15_2 { get; set; }

        public int MaDiem1T_1 { get; set; }

        public float? Diem1T_1 { get; set; }

        public int MaDiem1T_2 { get; set; }

        public float? Diem1T_2 { get; set; }

        public int MaDiemHK { get; set; }

        public float? DiemHK { get; set; }

        public float? DiemTrungBinh { get; set; }

        public BangDiemViewModel(int maBangDiem, int maHocSinh, string tenHocSinh, int maMonHoc, int maLop) 
        {
            MaBangDiem = -maBangDiem;   //am de danh dau bang diem moi, maBangDiem se do controller giu va bat dau tu 0
            TenHocSinh = tenHocSinh;
            MaHocSinh = maHocSinh;
            MaMonHoc = maMonHoc;
            MaLop = maLop;
            //danh dau ma diem -1 de biet diem moi
            MaDiemMieng_1 = -1;
            MaDiemMieng_2 = -1;
            MaDiem15_1 = -1;
            MaDiem15_2 = -1;
            MaDiem1T_1 = -1;
            MaDiem1T_2 = -1;
            MaDiemHK = -1;
        }

        public BangDiemViewModel(BangDiemHKMH bangDiem, string tenHocSinh, int maLop)
        {
            MaBangDiem = bangDiem.MaBangDiem;
            MaHocSinh = bangDiem.MaHocSinh;
            TenHocSinh = tenHocSinh;
            MaMonHoc = bangDiem.MaMonHoc;
            MaLop = maLop;
            //count variable to fill in when student dont have diem
            int countMieng = 0;
            int count15 = 0;
            int count1T = 0;
            int countHK = 0;
            foreach (CotDiem cotDiem in bangDiem.dsCotDiem)
            {
                //Diem mieng id = 1
                if (cotDiem.LoaiDiem.MaLoaiDiem == 1 && countMieng < 2)
                {
                    if (countMieng == 0)
                    {
                        MaDiemMieng_1 = cotDiem.MaCotDiem;
                        DiemMieng_1 = cotDiem.GiaTri;
                    }
                    else
                    {
                        MaDiemMieng_2 = cotDiem.MaCotDiem;
                        DiemMieng_2 = cotDiem.GiaTri;
                    }
                    countMieng++;
                }

                //fill fake ViewModel for table
                for (int i = 0; i < 2 - countMieng; i++)
                {
                    if (i == 0)
                    {
                        MaDiemMieng_2 = -1;
                        DiemMieng_2 = cotDiem.GiaTri;
                    }
                    else
                    {
                        MaDiemMieng_1 = cotDiem.MaCotDiem;
                        DiemMieng_1 = cotDiem.GiaTri;
                    }
                }

                //Diem 15' id = 3
                if (cotDiem.LoaiDiem.MaLoaiDiem == 2 && count15 < 2)
                {
                    if (count15 == 0)
                    {
                        MaDiem15_1 = cotDiem.MaCotDiem;
                        Diem15_1 = cotDiem.GiaTri;
                    }
                    else
                    {
                        MaDiem15_2 = cotDiem.MaCotDiem;
                        Diem15_2 = cotDiem.GiaTri;
                    }
                    count15++;
                }

                //Diem 1t id = 3
                if (cotDiem.LoaiDiem.MaLoaiDiem == 3 && countMieng < 2)
                {
                    if (count1T == 0)
                    {
                        MaDiem1T_1 = cotDiem.MaCotDiem;
                        Diem1T_1 = cotDiem.GiaTri;
                    }
                    else
                    {
                        MaDiem1T_2 = cotDiem.MaCotDiem;
                        Diem1T_2 = cotDiem.GiaTri;
                    }
                    count1T++;
                }

                //Diem HK id = 4
                if (cotDiem.LoaiDiem.MaLoaiDiem == 6 && countHK < 1)
                {
                    MaDiemHK = cotDiem.MaCotDiem;
                    DiemHK = cotDiem.GiaTri;
                }
            }

            DiemTrungBinh = (Diem15_1 + Diem15_2 + DiemMieng_1 + DiemMieng_2 + Diem1T_1*2 + Diem1T_2*2  + DiemHK * 3) / 
                (1 + 1 + 1 + 1 + 2 + 2 + 3);
        }
    }
}
