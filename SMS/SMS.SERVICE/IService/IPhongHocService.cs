using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface IPhongHocService
    {
        /// <summary>
        /// get PhongHoc
        /// </summary>
        /// <returns>list PhongHoc</returns>
        IEnumerable<PhongHoc> GetAll();

        /// <summary>
        /// get all PhongHoc that is inactive
        /// </summary>
        /// <returns>list PhongHoc inactive</returns>
        IEnumerable<PhongHoc> GetAllInactive();

        /// <summary>
        /// get PhongHoc by id
        /// </summary>
        /// <returns>list PhongHoc</returns>
        PhongHoc GetByID(int id);

        /// <summary>
        /// add PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void Insert(PhongHoc entity);

        /// <summary>
        /// add list PhongHoc
        /// </summary>
        /// <param name="entity">List PhongHoc</param>
        void Insert(IEnumerable<PhongHoc> entities);

        /// <summary>
        /// update PhongHoc 
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void Update(PhongHoc entity);

        /// <summary>
        /// update list PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void Update(IEnumerable<PhongHoc> entities);

        /// <summary>
        /// delete PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void Delete(PhongHoc entity);

        /// <summary>
        /// delete list PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void Delete(IEnumerable<PhongHoc> entities);

        /// <summary>
        /// set PhongHoc to unactive
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void FakeDelete(PhongHoc entity);

        /// <summary>
        ///  set list PhongHoc to unactive
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        void FakeDelete(IEnumerable<PhongHoc> entities);
    }
}
