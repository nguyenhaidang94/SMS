using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService kyluat
    /// </summary>
    public interface IKyLuatService
    {
        /// <summary>
        /// get all kyluat
        /// </summary>
        /// <returns>list kyluat</returns>
        IEnumerable<ThongTinKyLuat> GetAllKyLuat();

        /// <summary>
        /// add ds kyluat
        /// </summary>
        /// <param name="dsKyLuat">list kyluat</param>
        void AddDsKyLuat(IEnumerable<ThongTinKyLuat> dsKyLuat);

        /// <summary>
        /// update ds kyluat
        /// </summary>
        /// <param name="dsKyLuat">list khenthuong</param>
        void UpdateDsKyLuat(IEnumerable<ThongTinKyLuat> dsKyLuat);

        /// <summary>
        /// delete ds kyluat
        /// </summary>
        /// <param name="dsKyLuat">list kyluat</param>
        void DeleteDsKyLuat(IEnumerable<ThongTinKyLuat> dsKyLuat);
    }
}
