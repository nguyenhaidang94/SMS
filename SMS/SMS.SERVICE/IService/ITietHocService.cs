
using SMS.CORE.Data;
using System.Collections.Generic;
namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService TietHoc
    /// </summary>
    public interface ITietHocService
    {
        /// <summary>
        /// get all tiethoc
        /// </summary>
        /// <returns>list tiethoc</returns>
        IEnumerable<TietHoc> GetAllTietHoc();
    }
}