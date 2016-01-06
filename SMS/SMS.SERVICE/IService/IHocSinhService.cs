
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
        /// get hocsinh viewmodel
        /// </summary>
        /// <returns>list PersonViewModel</returns>
        IEnumerable<PersonViewModel> GetHocSinhViewModels();
    }
}
