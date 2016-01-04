using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo giaovien
    /// </summary>
    public interface IGiaoVienRepository
    {
        /// <summary>
        /// get all giaovien options
        /// </summary>
        /// <returns>list giaovien options</returns>
        List<StringOption> GetAllGiaoVienOptions();
    }
}
