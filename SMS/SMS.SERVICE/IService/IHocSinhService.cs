using SMS.CORE.Data;
using System.Collections.Generic;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService HocSinh
    /// </summary>
    public interface IHocSinhService
    {
        /// <summary>
        /// get all hocsinh
        /// </summary>
        /// <returns>list nguoi as hocsinh</returns>
        IEnumerable<Nguoi> GetAllHocSinh();
    }
}
