using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface IMonHocKhoiService
    {
        /// <summary>
        /// get MonHocKhoi
        /// </summary>
        /// <returns>list MonHocKhoi</returns>
        IEnumerable<MonHocKhoi> GetAll();

        /// <summary>
        /// get all MonHocKhoi that is inactive
        /// </summary>
        /// <returns>list MonHocKhoi inactive</returns>
        IEnumerable<MonHocKhoi> GetAllInactive();

        /// <summary>
        /// get MonHocKhoi by id
        /// </summary>
        /// <returns>list MonHocKhoi</returns>
        MonHocKhoi GetByID(int id);

        /// <summary>
        /// add MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void Insert(MonHocKhoi entity);

        /// <summary>
        /// add list MonHocKhoi
        /// </summary>
        /// <param name="entity">List MonHocKhoi</param>
        void Insert(IEnumerable<MonHocKhoi> entities);

        /// <summary>
        /// update MonHocKhoi 
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void Update(MonHocKhoi entity);

        /// <summary>
        /// update list MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void Update(IEnumerable<MonHocKhoi> entities);

        /// <summary>
        /// delete MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void Delete(MonHocKhoi entity);

        /// <summary>
        /// delete list MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void Delete(IEnumerable<MonHocKhoi> entities);

        /// <summary>
        /// set MonHocKhoi to unactive
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void FakeDelete(MonHocKhoi entity);

        /// <summary>
        ///  set list MonHocKhoi to unactive
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        void FakeDelete(IEnumerable<MonHocKhoi> entities);
    }
}
