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
        List<ThongTinKhenThuong> GetAllKhenThuong();
    }
}
