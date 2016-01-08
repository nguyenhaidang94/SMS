using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService khenthuong
    /// </summary>
    public interface IKhenThuongService
    {
        /// <summary>
        /// get all khenthuong
        /// </summary>
        /// <returns>list khenthuong</returns>
        IEnumerable<ThongTinKhenThuong> GetAllKhenThuong();

        /// <summary>
        /// add ds khenthuong
        /// </summary>
        /// <param name="entity">list thongtinkhenthuon</param>
        void AddDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong);

        /// <summary>
        /// update ds khenthuong
        /// </summary>
        /// <param name="dsKhenThuong">list khenthuong</param>
        void UpdateDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong);

        /// <summary>
        /// delete ds khenthuong
        /// </summary>
        /// <param name="dsKhenThuong">list khenthuong</param>
        void DeleteDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong);
    }
}
