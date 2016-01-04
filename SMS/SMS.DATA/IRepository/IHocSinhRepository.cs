using SMS.DATA.Models;
using System.Collections.Generic;


namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo HocSinh
    /// </summary>
    public interface IHocSinhRepository
    {
        /// <summary>
        /// get all hocsinh options
        /// </summary>
        /// <returns>list hocsinh options</returns>
        List<StringOption> GetAllHocSinhOptions();
    }
}
