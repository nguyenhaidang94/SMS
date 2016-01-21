using SMS.CORE.Data;
using SMS.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.SERVICE.Service
{
    public class ChuongTrinhHocService : IChuongTrinhHocService
    {
        public String maKhoi; // khối học
        public List<MonHoc> chuongTrinhHoc; // danh sách môn học

        public ChuongTrinhHocService(List<MonHoc> ListTietGiangDay, String Khoi)
        {
            chuongTrinhHoc = ListTietGiangDay;
            maKhoi = Khoi;
        }
    }
}
