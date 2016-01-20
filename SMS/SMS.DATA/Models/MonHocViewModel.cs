using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE.Data;

namespace SMS.DATA.Models
{
    public class PairKhoiLop
    {
        public int value { get; set; }

        public string text { get; set; }

        public PairKhoiLop() { }

        public PairKhoiLop(int MaKhoi, string TenKhoi)
        {
            value = MaKhoi;
            text = TenKhoi;
        }

        public PairKhoiLop(KhoiLop khoiLop)
        {
            value = khoiLop.MaKhoi;
            text = khoiLop.TenKhoi;
        }
    }

    public class MonHocViewModel
    {
        public int MaMonHoc { get; set; }

        public string TenMonHoc { get; set; }

        public float HeSo { get; set; }

        public int? SoTiet { get; set; }

        public List<PairKhoiLop> KhoiLops;

        public MonHocViewModel() { }

        public MonHocViewModel(MonHoc monHoc)
        {
            MaMonHoc = monHoc.MaMonHoc;
            TenMonHoc = monHoc.TenMonHoc;
            HeSo = monHoc.HeSo;
            SoTiet = monHoc.SoTiet;
            foreach (KhoiLop khoiLop in monHoc.dsKhoi)
            {
                KhoiLops.Add(new PairKhoiLop(khoiLop));
            }
        }
    }
}
