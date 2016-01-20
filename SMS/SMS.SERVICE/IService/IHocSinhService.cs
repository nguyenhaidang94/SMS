using SMS.CORE.Data;
using SMS.DATA.Models;
using System.Collections.Generic;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService HocSinh
    /// </summary>
    public interface IHocSinhService
    {
        /// <summary>
        /// get HocSinh
        /// </summary>
        /// <returns>list HocSinh</returns>
        IEnumerable<HocSinh> GetAll();

        /// <summary>
        /// get HocSinh with list lop
        /// </summary>
        /// <returns>list HocSinh</returns>
        IEnumerable<HocSinh> GetAllWithChild();

        /// <summary>
        /// get all HocSinh that is inactive
        /// </summary>
        /// <returns>list HocSinh inactive</returns>
        IEnumerable<HocSinh> GetAllInactive();

        /// <summary>
        /// get all SelectHocSinhViewModel
        /// </summary>
        /// <returns>list SelectHocSinhViewModel</returns>
        IEnumerable<SelectHocSinhViewModel> GetAllSelectHocSinhVM();

        /// <summary>
        /// get HocSinh by id
        /// </summary>
        /// <returns>list HocSinh</returns>
        HocSinh GetByID(int id);

        /// <summary>
        /// get HocSinh by id with dsLopHoc
        /// </summary>
        /// <returns>list HocSinh</returns>
        HocSinh GetByIDWithChild(int id);

        /// <summary>
        /// add HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void Insert(HocSinh entity);

        /// <summary>
        /// add list HocSinh
        /// </summary>
        /// <param name="entity">List HocSinh</param>
        void Insert(IEnumerable<HocSinh> entities);

        /// <summary>
        /// update HocSinh 
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void Update(HocSinh entity);

        /// <summary>
        /// update list HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void Update(IEnumerable<HocSinh> entities);

        /// <summary>
        /// delete HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void Delete(HocSinh entity);

        /// <summary>
        /// delete list HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void Delete(IEnumerable<HocSinh> entities);

        /// <summary>
        /// set HocSinh to unactive
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void FakeDelete(HocSinh entity);

        /// <summary>
        ///  set list HocSinh to unactive
        /// </summary>
        /// <param name="entity">HocSinh</param>
        void FakeDelete(IEnumerable<HocSinh> entities);
      
    }
}
