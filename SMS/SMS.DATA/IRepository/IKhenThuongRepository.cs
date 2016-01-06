using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.DATA.IRepository
{
    /// <summary>
    /// IRepo khenthuong
    /// </summary>
    public interface IKhenThuongRepository
    {
        /// <summary>
        /// get all khenthuong
        /// </summary>
        /// <returns>list khenthuong</returns>
        IEnumerable<ThongTinKhenThuong> GetAllKhenThuong();

        /// <summary>
        /// add thongtinkhenthuong
        /// </summary>
        /// <param name="entity">thongtinkhenthuong</param>
        void AddKhenThuong(ThongTinKhenThuong entity);
    }
}
