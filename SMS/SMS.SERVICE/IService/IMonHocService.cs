using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface IMonHocService
    {
        /// <summary>
        /// get MonHoc
        /// </summary>
        /// <returns>list MonHoc</returns>
        IEnumerable<MonHoc> GetAll();

        /// <summary>
        /// get MonHoc
        /// </summary>
        /// <returns>list MonHoc</returns>
        IEnumerable<MonHoc> GetAllWithChild();

        /// <summary>
        /// get all MonHoc that is inactive
        /// </summary>
        /// <returns>list MonHoc inactive</returns>
        IEnumerable<MonHoc> GetAllInactive();

        /// <summary>
        /// get MonHoc by id
        /// </summary>
        /// <returns>list MonHoc</returns>
        MonHoc GetByID(int id);

        /// <summary>
        /// add MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void Insert(MonHoc entity);

        /// <summary>
        /// add list MonHoc
        /// </summary>
        /// <param name="entity">List MonHoc</param>
        void Insert(IEnumerable<MonHoc> entities);

        /// <summary>
        /// update MonHoc 
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void Update(MonHoc entity);

        /// <summary>
        /// update list MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void Update(IEnumerable<MonHoc> entities);

        /// <summary>
        /// delete MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void Delete(MonHoc entity);

        /// <summary>
        /// delete list MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void Delete(IEnumerable<MonHoc> entities);

        /// <summary>
        /// set MonHoc to unactive
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void FakeDelete(MonHoc entity);

        /// <summary>
        ///  set list MonHoc to unactive
        /// </summary>
        /// <param name="entity">MonHoc</param>
        void FakeDelete(IEnumerable<MonHoc> entities);
    }
}
