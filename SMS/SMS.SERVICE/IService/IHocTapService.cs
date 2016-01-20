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

        /// <summary>
        /// get all CotDiem
        /// </summary>
        /// <returns>list CotDiem</returns>
        IEnumerable<CotDiem> GetAllCotDiem();

        /// <summary>
        /// get CotDiem by id
        /// </summary>
        /// <returns>CotDiem</returns>
        CotDiem GetCotDiemByID(int id);

        /// <summary>
        /// add CotDiem
        /// </summary>
        /// <param name="entity">CotDiem</param>
        void InsertCotDiem(CotDiem entity);

        /// <summary>
        /// add list CotDiem
        /// </summary>
        /// <param name="entity">List CotDiem</param>
        void InsertCotDiem(IEnumerable<CotDiem> entities);

        /// <summary>
        /// update CotDiem 
        /// </summary>
        /// <param name="entity">CotDiem</param>
        void UpdateCotDiem(CotDiem entity);

        /// <summary>
        /// update list CotDiem
        /// </summary>
        /// <param name="entity">CotDiem</param>
        void UpdateCotDiem(IEnumerable<CotDiem> entities);

        /// <summary>
        /// delete CotDiem
        /// </summary>
        /// <param name="entity">CotDiem</param>
        void DeleteCotDiem(CotDiem entity);

        /// <summary>
        /// delete list CotDiem
        /// </summary>
        /// <param name="entity">CotDiem</param>
        void DeleteCotDiem(IEnumerable<CotDiem> entities);
    }
}
