using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    public interface IHocTapService
    {
        /// <summary>
        /// get all bangdiem
        /// </summary>
        /// <returns>list bangdiem</returns>
        IEnumerable<BangDiemHKMH> GetAllBangDiem();

        /// <summary>
        /// get BangDiem by id
        /// </summary>
        /// <returns>list BangDiem</returns>
        BangDiemHKMH GetBangDiemByID(int id);

        /// <summary>
        /// add BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        void InsertBangDiem(BangDiemHKMH entity);

        /// <summary>
        /// add list BangDiem
        /// </summary>
        /// <param name="entity">List BangDiem</param>
        void InsertBangDiem(IEnumerable<BangDiemHKMH> entities);

        /// <summary>
        /// update BangDiem 
        /// </summary>
        /// <param name="entity">BangDiem</param>
        void UpdateBangDiem(BangDiemHKMH entity);

        /// <summary>
        /// update list BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        void UpdateBangDiem(IEnumerable<BangDiemHKMH> entities);

        /// <summary>
        /// delete BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        void DeleteBangDiem(BangDiemHKMH entity);

        /// <summary>
        /// delete list BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        void DeleteBangDiem(IEnumerable<BangDiemHKMH> entities);
    }
}
