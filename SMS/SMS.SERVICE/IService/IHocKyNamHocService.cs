using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    public interface IHocKyNamHocService
    {
        /// <summary>
        /// get HocKyNamHoc
        /// </summary>
        /// <returns>list HocKyNamHoc</returns>
        IEnumerable<HocKyNamHoc> GetAll();

        /// <summary>
        /// get all HocKyNamHoc that is inactive
        /// </summary>
        /// <returns>list HocKyNamHoc inactive</returns>
        IEnumerable<HocKyNamHoc> GetAllInactive();

        /// <summary>
        /// get HocKyNamHoc by id
        /// </summary>
        /// <returns>list HocKyNamHoc</returns>
        HocKyNamHoc GetByID(int id);

        /// <summary>
        /// Insert HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void Insert(HocKyNamHoc entity);

        /// <summary>
        /// Insert list HocKyNamHoc
        /// </summary>
        /// <param name="entity">List HocKyNamHoc</param>
        void Insert(IEnumerable<HocKyNamHoc> entities);

        /// <summary>
        /// update HocKyNamHoc 
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void Update(HocKyNamHoc entity);

        /// <summary>
        /// update list HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void Update(IEnumerable<HocKyNamHoc> entities);

        /// <summary>
        /// delete HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void Delete(HocKyNamHoc entity);

        /// <summary>
        /// delete list HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void Delete(IEnumerable<HocKyNamHoc> entities);

        /// <summary>
        /// set HocKyNamHoc to unactive
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void FakeDelete(HocKyNamHoc entity);

        /// <summary>
        ///  set list HocKyNamHoc to unactive
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        void FakeDelete(IEnumerable<HocKyNamHoc> entities);
    }
}
