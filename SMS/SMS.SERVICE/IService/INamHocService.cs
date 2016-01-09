using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface INamHocService
    {
        /// <summary>
        /// get NamHoc
        /// </summary>
        /// <returns>list NamHoc</returns>
        IEnumerable<NamHoc> GetAll();

        /// <summary>
        /// get all NamHoc that is inactive
        /// </summary>
        /// <returns>list NamHoc inactive</returns>
        IEnumerable<NamHoc> GetAllInactive();

        /// <summary>
        /// get NamHoc by id
        /// </summary>
        /// <returns>list NamHoc</returns>
        NamHoc GetByID(int id);

        /// <summary>
        /// Insert NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void Insert(NamHoc entity);

        /// <summary>
        /// Insert list NamHoc
        /// </summary>
        /// <param name="entity">List NamHoc</param>
        void Insert(IEnumerable<NamHoc> entities);

        /// <summary>
        /// update NamHoc 
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void Update(NamHoc entity);

        /// <summary>
        /// update list NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void Update(IEnumerable<NamHoc> entities);

        /// <summary>
        /// delete NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void Delete(NamHoc entity);

        /// <summary>
        /// delete list NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void Delete(IEnumerable<NamHoc> entities);

        /// <summary>
        /// set NamHoc to unactive
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void FakeDelete(NamHoc entity);

        /// <summary>
        ///  set list NamHoc to unactive
        /// </summary>
        /// <param name="entity">NamHoc</param>
        void FakeDelete(IEnumerable<NamHoc> entities);
    }
}
