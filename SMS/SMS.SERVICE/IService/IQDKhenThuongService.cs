using SMS.CORE.Data;
using System.Collections.Generic;
using SMS.DATA.Models;

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

        /// <summary>
        /// add ds ctkhenthuong to qdkhenthuong has id= maqd
        /// </summary>
        /// <param name="maqd">maquyetdinh</param>
        /// <param name="models">list hocsinh</param>
        void AddDsCTKhenThuong(int maqd, List<SelectHocSinhViewModel> models);
    }
}
