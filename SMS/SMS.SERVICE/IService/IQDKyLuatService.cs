using SMS.CORE.Data;
using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService QDKyLuat
    /// </summary>
    public interface IQDKyLuatService
    {
        /// <summary>
        /// get all qdkyluat
        /// </summary>
        /// <returns>list qdkyluat</returns>
        IEnumerable<QuyetDinhKyLuat> GetAllQDKyLuat();

        /// <summary>
        /// add ds qdkyluat
        /// </summary>
        /// <param name="dsQDKyLuat">list qdkyluat</param>
        void AddDsQDKyLuat(IEnumerable<QuyetDinhKyLuat> dsQDKyLuat);

        /// <summary>
        /// update ds qdkyluat
        /// </summary>
        /// <param name="dsQDKyLuat">list qdkyluat</param>
        void UpdateDsQDKyLuat(IEnumerable<QuyetDinhKyLuat> dsQDKyLuat);

        /// <summary>
        /// delete ds qdkyluat
        /// </summary>
        /// <param name="dsQDKyLuat">list qdkyluat</param>
        void DeleteDsQdKyLuat(IEnumerable<QuyetDinhKyLuat> dsQDKyLuat);

        /// <summary>
        /// add ds ctkyluat to qdkyluat has id= maqd
        /// </summary>
        /// <param name="maqd">maquyetdinh</param>
        /// <param name="models">list hocsinh</param>
        void AddDsCTKyLuat(int maqd, List<SelectHocSinhViewModel> models);
    }
}
