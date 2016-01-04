using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService HocSinh
    /// </summary>
    public interface IHocSinhService
    {
        /// <summary>
        /// get all hocsinh options
        /// </summary>
        /// <returns>list hocsinh options</returns>
        List<StringOption> GetAllHocSinhOptions();
    }
}
