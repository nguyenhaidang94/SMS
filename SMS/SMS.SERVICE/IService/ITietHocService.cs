using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService TietHoc
    /// </summary>
    public interface ITietHocService
    {
        /// <summary>
        /// get all tiethoc options
        /// </summary>
        /// <returns>list tiethoc options</returns>
         List<IntOption> GetAllTietHocOptions();
    }
}