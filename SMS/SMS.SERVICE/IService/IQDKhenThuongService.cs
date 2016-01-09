using SMS.CORE.Data;
using System.Collections.Generic;

namespace SMS.SERVICE.IService
{
    /// <summary>
    /// IService QDKhenThuong
    /// </summary>
    public interface IQDKhenThuongService
    {
        /// <summary>
        /// get all qdkhenthuong
        /// </summary>
        /// <returns>list qdkhenthuong</returns>
        IEnumerable<QuyetDinhKhenThuong> GetAllQDKhenThuong();

        /// <summary>
        /// add ds qdkhenthuong
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        void AddDsQDKhenThuong(IEnumerable<QuyetDinhKhenThuong> dsQDKhenThuong);

        /// <summary>
        /// update ds qdkhenthuong
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        void UpdateDsQDKhenThuong(IEnumerable<QuyetDinhKhenThuong> dsQDKhenThuong);

        /// <summary>
        /// delete ds qdkhenthuong
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        void DeleteDsQdKhenThuong(IEnumerable<QuyetDinhKhenThuong> dsQDKhenThuong);
    }
}
