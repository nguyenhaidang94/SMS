using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo TietHoc
    /// </summary>
    public interface ITietHocRepository
    {
        /// <summary>
        /// get all tiethoc options
        /// </summary>
        /// <returns>list tiethoc options</returns>
        List<IntOption> GetAllTietHocOptions();
    }
}