using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA.Models;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService ctqd khenthuong
    /// </summary>
    public interface ICTQDKhenThuongService
    {
        /// <summary>
        /// get all ctqd khenthuong
        /// </summary>
        /// <returns>list ctqd khenthuong</returns>
        IEnumerable<CT_QuyetDinhKhenThuong> GetAllCTQDKhenThuong();

        /// <summary>
        /// get all ctkhenthuong viewmodel
        /// </summary>
        /// <returns>list ctkhenthuong viewmodel</returns>
        IEnumerable<CTKhenThuongViewModel> GetAllCTKhenThuongVM();

        /// <summary>
        /// get all ctkhenthuong in qdkhenthuong
        /// </summary>
        /// <returns>list ctkhenthuong viewmodel</returns>
        IEnumerable<CTKhenThuongViewModel> GetCTKhenThuongInQDKhenThuong(int maqd);

        /// <summary>
        /// add ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong"></param>
        void AddDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong);

        /// <summary>
        /// update ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong">list ctqd khenthuong</param>
        void UpdateDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong);

        /// <summary>
        /// update ds ctkhenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong">list ctkhenthuong viewmodel</param>
        void UpdateDsCTQDKhenThuong(IEnumerable<CTKhenThuongViewModel> dsCTKhenThuong);

        /// <summary>
        /// delete ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong"></param>
        void DeleteDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong);

        /// <summary>
        /// delete ds ctkhenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong">list ctkhenthuong viewmodel</param>
        void DeleteDsCTQDKhenThuong(IEnumerable<CTKhenThuongViewModel> dsCTKhenThuong);
    }
}
