using System.Collections.Generic;
using SMS.CORE.Data;

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
        /// delete ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong"></param>
        void DeleteDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong);
    }
}
