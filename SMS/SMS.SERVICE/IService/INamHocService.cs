using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public partial interface INamHocService
    {
        /// <summary>
        /// get namhoc
        /// </summary>
        /// <returns>list namhoc</returns>
        IEnumerable<NamHoc> GetAllNamHoc();

        /// <summary>
        /// add namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        void AddNamHoc(NamHoc entity);

        /// <summary>
        /// update namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        void UpdateNamHoc(NamHoc entity);

        /// <summary>
        /// delete namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        void DeleteNamHoc(NamHoc entity);
    }
}
