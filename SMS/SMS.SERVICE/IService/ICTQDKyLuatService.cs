using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService CTQDKyLuat
    /// </summary>
    public interface ICTQDKyLuatService
    {
        /// <summary>
        /// get all ctqd kyluat
        /// </summary>
        /// <returns>list ctqd kyluat</returns>
        IEnumerable<CT_QuyetDinhKyLuat> GetAllCTQDKyLuat();

        /// <summary>
        /// get all ctKyLuat viewmodel
        /// </summary>
        /// <returns>list ctKyLuat viewmodel</returns>
        IEnumerable<CTKyLuatViewModel> GetAllCTKyLuatVM();

        /// <summary>
        /// get all ctKyLuat in qdKyLuat
        /// </summary>
        /// <returns>list ctKyLuat viewmodel</returns>
        IEnumerable<CTKyLuatViewModel> GetCTKyLuatInQDKyLuat(int maqd);

        /// <summary>
        /// add ds ctqd kyluat
        /// </summary>
        /// <param name="dsCTQDKyLuat"></param>
        void AddDsCTQDKyLuat(IEnumerable<CT_QuyetDinhKyLuat> dsCTQDKyLuat);

         /// <summary>
        /// update ds ctqd kyluat
        /// </summary>
        /// <param name="dsCTQDKyLuat">list ctqd kyluat</param>
        void UpdateDsCTQDKyLuat(IEnumerable<CT_QuyetDinhKyLuat> dsCTQDKyLuat);

        /// <summary>
        /// update ds ctKyLuat
        /// </summary>
        /// <param name="dsCTQDKyLuat">list ctKyLuat viewmodel</param>
        void UpdateDsCTQDKyLuat(IEnumerable<CTKyLuatViewModel> dsCTKyLuat);

        /// <summary>
        /// delete ds ctqd kyluat
        /// </summary>
        /// <param name="dsCTQDKyLuat"></param>
        void DeleteDsCTQDKyLuat(IEnumerable<CT_QuyetDinhKyLuat> dsCTQDKyLuat);

        /// <summary>
        /// delete ds ctKyLuat
        /// </summary>
        /// <param name="dsCTQDKyLuat">list ctKyLuat viewmodel</param>
        void DeleteDsCTQDKyLuat(IEnumerable<CTKyLuatViewModel> dsCTKyLuat);
    }
}
