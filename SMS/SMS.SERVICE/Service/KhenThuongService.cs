using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service khenthuong
    /// </summary>
    public class KhenThuongService: IKhenThuongService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<ThongTinKhenThuong> _KhenThuongRepository;

        public KhenThuongService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _KhenThuongRepository = _UnitOfWork.Repository<ThongTinKhenThuong>();
        }

        /// <summary>
        /// get all khenthuong
        /// </summary>
        /// <returns>list khenthuong</returns>
        public IEnumerable<ThongTinKhenThuong> GetAllKhenThuong()
        {
            return _KhenThuongRepository.Entities.Where(e => e.Active == true);
        }

        /// <summary>
        /// add ds khenthuong
        /// </summary>
        /// <param name="entity">list thongtinkhenthuon</param>
        public void AddDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong)
        {
            _KhenThuongRepository.Insert(dsKhenThuong);
        }

        /// <summary>
        /// update ds khenthuong
        /// </summary>
        /// <param name="dsKhenThuong">list khenthuong</param>
        public void UpdateDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong)
        {
            _KhenThuongRepository.Update(dsKhenThuong);
        }

        /// <summary>
        /// delete dskhenthuong
        /// </summary>
        /// <param name="dsKhenThuong">list khenthuong</param>
        public void DeleteDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong)
        {
            _KhenThuongRepository.FakeDelete(dsKhenThuong);
        }
    }
}
