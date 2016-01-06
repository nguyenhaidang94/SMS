using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo HocSinh
    /// </summary>
    public interface IHocSinhRepository
    {
        /// <summary>
        /// get hocsinh viewmodel
        /// </summary>
        /// <returns>list PersonViewModel</returns>
        IEnumerable<PersonViewModel> GetHocSinhViewModels();
    }
}
