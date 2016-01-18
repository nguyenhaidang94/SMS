
using SMS.CORE.Data;
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
        IEnumerable<Nguoi> GetAllGiaoVien();
        void AddDsGiaoVien(IEnumerable<GiaoVien> dsGiaoVien);
        void UpdateDsGiaoVien(IEnumerable<GiaoVien> dsGiaoVien);
        void DeleteDsGiaoVien(IEnumerable<GiaoVien> dsGiaoVien);
    }
}
