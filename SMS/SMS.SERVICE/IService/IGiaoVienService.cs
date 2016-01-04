using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService giaovien
    /// </summary>
    public interface IGiaoVienService
    {
        /// <summary>
        /// get all giaovien options
        /// </summary>
        /// <returns>list giaovien options</returns>
        List<StringOption> GetAllGiaoVienOptions();
    }
}
