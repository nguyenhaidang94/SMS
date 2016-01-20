using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface IHocKyService
    {
        /// <summary>
        /// get HocKy
        /// </summary>
        /// <returns>list HocKy</returns>
        IEnumerable<HocKy> GetAll();

        /// <summary>
        /// get all HocKy that is inactive
        /// </summary>
        /// <returns>list HocKy inactive</returns>
        IEnumerable<HocKy> GetAllInactive();

        /// <summary>
        /// get HocKy by id
        /// </summary>
        /// <returns>list HocKy</returns>
        HocKy GetByID(int id);

        /// <summary>
        /// Insert HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        void Insert(HocKy entity);

        /// <summary>
        /// Insert list HocKy
        /// </summary>
        /// <param name="entity">List HocKy</param>
        void Insert(IEnumerable<HocKy> entities);

        /// <summary>
        /// update HocKy 
        /// </summary>
        /// <param name="entity">HocKy</param>
        void Update(HocKy entity);

        /// <summary>
        /// update list HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        void Update(IEnumerable<HocKy> entities);

        /// <summary>
        /// delete HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        void Delete(HocKy entity);

        /// <summary>
        /// delete list HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        void Delete(IEnumerable<HocKy> entities);

        /// <summary>
        /// set HocKy to unactive
        /// </summary>
        /// <param name="entity">HocKy</param>
        void FakeDelete(HocKy entity);

        /// <summary>
        ///  set list HocKy to unactive
        /// </summary>
        /// <param name="entity">HocKy</param>
        void FakeDelete(IEnumerable<HocKy> entities);
    }
}
