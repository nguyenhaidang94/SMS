using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    public interface ILopHocService
    {
        /// <summary>
        /// get LopHoc
        /// </summary>
        /// <returns>list LopHoc</returns>
        IEnumerable<LopHoc> GetAll();

        /// <summary>
        /// get LopHoc
        /// </summary>
        /// <returns>list LopHoc</returns>
        IEnumerable<LopHoc> GetAllWithChild();

        /// <summary>
        /// get all LopHoc that is inactive
        /// </summary>
        /// <returns>list LopHoc inactive</returns>
        IEnumerable<LopHoc> GetAllInactive();

        /// <summary>
        /// get all lophocviewmodel
        /// </summary>
        /// <returns>list lophocviewmodel</returns>
        IEnumerable<LopHocViewModel> GetAllLopHocViewModel();

        /// <summary>
        /// get LopHoc by id
        /// </summary>
        /// <returns>list LopHoc</returns>
        LopHoc GetByID(int id);

        /// <summary>
        /// get LopHoc by id
        /// </summary>
        /// <returns>list LopHoc with list dsHocSinh</returns>
        LopHoc GetByIDWithChild(int id);

        /// <summary>
        /// Insert LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void Insert(LopHoc entity);

        /// <summary>
        /// Insert list LopHoc
        /// </summary>
        /// <param name="entity">List LopHoc</param>
        void Insert(IEnumerable<LopHoc> entities);

        /// <summary>
        /// update LopHoc 
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void Update(LopHoc entity);

        /// <summary>
        /// update list LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void Update(IEnumerable<LopHoc> entities);

        /// <summary>
        /// delete LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void Delete(LopHoc entity);

        /// <summary>
        /// delete list LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void Delete(IEnumerable<LopHoc> entities);

        /// <summary>
        /// set LopHoc to unactive
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void FakeDelete(LopHoc entity);

        /// <summary>
        ///  set list LopHoc to unactive
        /// </summary>
        /// <param name="entity">LopHoc</param>
        void FakeDelete(IEnumerable<LopHoc> entities);
    }
}
