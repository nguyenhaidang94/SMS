using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo namhoc
    /// </summary>
    public interface INamHocRepository
    {
        /// <summary>
        /// get namhoc
        /// </summary>
        /// <returns>list namhoc</returns>
        List<NamHoc> GetAllNamHoc();

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
