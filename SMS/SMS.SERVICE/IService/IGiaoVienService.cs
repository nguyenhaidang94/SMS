
using SMS.CORE.Data;
using SMS.DATA.Models;
using System.Collections.Generic;
namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService giaovien
    /// </summary>
    public interface IGiaoVienService
    {
        /// <summary>
        /// get all giaovien
        /// </summary>
        /// <returns>list nguoi as giaovien</returns>
        IEnumerable<GiaoVien> GetAllGiaoVien();
        IEnumerable<GiaoVienViewModel> KhoiTaoModel();
        void AddDsGiaoVien(IEnumerable<GiaoVienViewModel> dsGiaoVien);
        void UpdateDsGiaoVien(IEnumerable<GiaoVienViewModel> dsGiaoVien);
        void DeleteDsGiaoVien(IEnumerable<GiaoVienViewModel> dsGiaoVien);
        List<GiaoVien> LayDanhSachGiaoVienTheoMon(int id);
        int GetLastPersonId();

    }
}
