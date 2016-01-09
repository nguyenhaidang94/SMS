using SMS.CORE.Data;
using System.Collections.Generic;
using SMS.SERVICE.IService;
using SMS.DATA;
using System.Linq;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service qdkhenthuong
    /// </summary>
    public class QDKhenThuongService: IQDKhenThuongService
    {
        private readonly UnitOfWork _UnitOfWork;
        private GenericRepository<QuyetDinhKhenThuong> _QDKhenThuongRepository;

        public QDKhenThuongService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _QDKhenThuongRepository = unitOfWork.Repository<QuyetDinhKhenThuong>();
        }

        /// <summary>
        /// get all qdkhenthuong
        /// </summary>
        /// <returns>list qdkhenthuong</returns>
        public IEnumerable<QuyetDinhKhenThuong> GetAllQDKhenThuong()
        {
            return _QDKhenThuongRepository.Entities
                .Where(e => e.Active);
        }

        /// <summary>
        /// add ds qdkhenthuong
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        public void AddDsQDKhenThuong(IEnumerable<QuyetDinhKhenThuong> dsQDKhenThuong)
        {
            _QDKhenThuongRepository.Insert(dsQDKhenThuong);
        }

        /// <summary>
        /// update ds qdkhenthuong
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        public void UpdateDsQDKhenThuong(IEnumerable<QuyetDinhKhenThuong> dsQDKhenThuong)
        {
            _QDKhenThuongRepository.Update(dsQDKhenThuong);
        }

        /// <summary>
        /// delete ds qdkhenthuong
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        public void DeleteDsQdKhenThuong(IEnumerable<QuyetDinhKhenThuong> dsQDKhenThuong)
        {
            _QDKhenThuongRepository.FakeDelete(dsQDKhenThuong);
        }
    }
}
