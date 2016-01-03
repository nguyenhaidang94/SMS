using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo hocky
    /// </summary>
    public interface IHocKyRepository
    {
        /// <summary>
        /// get hocky
        /// </summary>
        /// <returns>list hocky</returns>
        List<HocKy> GetAllHocKy();
    }
}
