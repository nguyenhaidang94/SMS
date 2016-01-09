using System;
using System.Collections.Generic;
using System.Linq;
using SMS.SERVICE.IService;
using SMS.CORE.Data;
using SMS.DATA;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// Service CTQDKhenThuong
    /// </summary>
    public class CTQDKhenThuongService: ICTQDKhenThuongService
    {
        private readonly UnitOfWork _UnitOfWork;
        private GenericRepository<CT_QuyetDinhKhenThuong> _CTKhenThuongRepository;

        public CTQDKhenThuongService(UnitOfWork unitOfWork)
        { 
            _UnitOfWork = unitOfWork;
            _CTKhenThuongRepository = _UnitOfWork.Repository<CT_QuyetDinhKhenThuong>();
        }

        /// <summary>
        /// get all ctqd khenthuong
        /// </summary>
        /// <returns>list ctqd khenthuong</returns>
        public IEnumerable<CT_QuyetDinhKhenThuong> GetAllCTQDKhenThuong()
        {
            return _CTKhenThuongRepository.Entities.Where(e => e.Active);
        }

        /// <summary>
        /// add ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong"></param>
        public void AddDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong)
        {
            _CTKhenThuongRepository.Insert(dsCTQDKhenThuong);
        }

        /// <summary>
        /// update ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong">list ctqd khenthuong</param>
        public void UpdateDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong)
        {
            _CTKhenThuongRepository.Update(dsCTQDKhenThuong);
        }

        /// <summary>
        /// delete ds ctqd khenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong"></param>
        public void DeleteDsCTQDKhenThuong(IEnumerable<CT_QuyetDinhKhenThuong> dsCTQDKhenThuong)
        {
            _CTKhenThuongRepository.FakeDelete(dsCTQDKhenThuong);
        }
    }
}
