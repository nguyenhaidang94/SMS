using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA.Models;


namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService BaoCao
    /// </summary>
    public interface IBaoCaoService
    {
        /// <summary>
        /// report group point
        /// </summary>
        /// <returns>list BaoCaoNhomDiemViewModel</returns>
        ICollection<BaoCaoNhomDiemViewModel> BaoCaoNhomDiem();
    }
}
