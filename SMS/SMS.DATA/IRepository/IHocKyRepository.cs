using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE.Data;

namespace SMS.DATA.IRepository
{
    public partial interface IHocKyRepository
    {
        /// <summary>
        /// get hocky
        /// </summary>
        /// <returns>list hocky</returns>
        IEnumerable<HocKy> GetAllHocKy();
    }
}
