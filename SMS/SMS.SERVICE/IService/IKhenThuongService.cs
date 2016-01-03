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
        List<ThongTinKhenThuong> GetAllKhenThuong();
    }
}
