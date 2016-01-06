using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.DATA.IRepository;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service khenthuong
    /// </summary>
    public class KhenThuongService: IKhenThuongService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IKhenThuongRepository _KhenThuongRepository;

        public KhenThuongService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _KhenThuongRepository = _UnitOfWork.KhenThuongRepository;
        }

        /// <summary>
        /// get all khenthuong
        /// </summary>
        /// <returns>list khenthuong</returns>
        public IEnumerable<ThongTinKhenThuong> GetAllKhenThuong()
        {
            return _KhenThuongRepository.GetAllKhenThuong();
        }

        /// <summary>
        /// add ds khenthuong
        /// </summary>
        /// <param name="entity">list thongtinkhenthuon</param>
        public void AddDsKhenThuong(IEnumerable<ThongTinKhenThuong> dsKhenThuong)
        {
            foreach (var khenthuong in dsKhenThuong)
            {
                _KhenThuongRepository.AddKhenThuong(khenthuong);
            }
            _UnitOfWork.SaveChanges();
        }
    }
}
