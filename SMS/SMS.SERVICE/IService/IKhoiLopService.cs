using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface IKhoiLopService
    {
        /// <summary>
        /// get KhoiLop
        /// </summary>
        /// <returns>list KhoiLop</returns>
        IEnumerable<KhoiLop> GetAll();

        /// <summary>
        /// get all KhoiLop that is inactive
        /// </summary>
        /// <returns>list KhoiLop inactive</returns>
        IEnumerable<KhoiLop> GetAllInactive();

        /// <summary>
        /// get KhoiLop by id
        /// </summary>
        /// <returns>list KhoiLop</returns>
        KhoiLop GetByID(int id);

        /// <summary>
        /// Insert KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void Insert(KhoiLop entity);

        /// <summary>
        /// Insert list KhoiLop
        /// </summary>
        /// <param name="entity">List KhoiLop</param>
        void Insert(IEnumerable<KhoiLop> entities);

        /// <summary>
        /// update KhoiLop 
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void Update(KhoiLop entity);

        /// <summary>
        /// update list KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void Update(IEnumerable<KhoiLop> entities);

        /// <summary>
        /// delete KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void Delete(KhoiLop entity);

        /// <summary>
        /// delete list KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void Delete(IEnumerable<KhoiLop> entities);

        /// <summary>
        /// set KhoiLop to unactive
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void FakeDelete(KhoiLop entity);

        /// <summary>
        ///  set list KhoiLop to unactive
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        void FakeDelete(IEnumerable<KhoiLop> entities);
    }
}
