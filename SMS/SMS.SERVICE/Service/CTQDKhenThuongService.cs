using System;
using System.Collections.Generic;
using System.Linq;
using SMS.SERVICE.IService;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// Service CTQDKhenThuong
    /// </summary>
    public class CTQDKhenThuongService: ICTQDKhenThuongService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<CT_QuyetDinhKhenThuong> _CTKhenThuongRepository;
        private readonly GenericRepository<Nguoi> _NguoiRepository;
        private readonly GenericRepository<LopHoc> _LopRepository;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;

        public CTQDKhenThuongService(UnitOfWork unitOfWork)
        { 
            _UnitOfWork = unitOfWork;
            _CTKhenThuongRepository = _UnitOfWork.Repository<CT_QuyetDinhKhenThuong>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
            _LopRepository = _UnitOfWork.Repository<LopHoc>();
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
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
        /// get all ctkhenthuong viewmodel
        /// </summary>
        /// <returns>list ctkhenthuong viewmodel</returns>
        public IEnumerable<CTKhenThuongViewModel> GetAllCTKhenThuongVM()
        {
            return _CTKhenThuongRepository.Entities.Where(e => e.Active)
                .Join(_HocSinhRepository.Entities,
                a => a.MaHocSinh,
                b => b.PersonId,
                (a, b) => new CTKhenThuongViewModel()
                {
                    Id = a.Id,
                    MaQuyetDinh = a.MaQuyetDinh,
                    MaHocSinh = a.MaHocSinh,
                    HoTen = b.HoTen,
                    LyDoKhenThuong = a.LyDoKhenThuong,
                    HinhThucKhenThuong = a.HinhThucKhenThuong,
                    GiaTriKhenThuong = a.GiaTriKhenThuong,
                    GhiVaoHocBa = a.GhiVaoHocBa,
                    Active = a.Active
                }); 
        }

        /// <summary>
        /// get all ctkhenthuong in qdkhenthuong
        /// </summary>
        /// <returns>list ctkhenthuong viewmodel</returns>
        public IEnumerable<CTKhenThuongViewModel> GetCTKhenThuongInQDKhenThuong(int maqd)
        {
            return _CTKhenThuongRepository.Entities
                .Where(e => e.MaQuyetDinh == maqd && e.Active)
                .Join(_HocSinhRepository.Entities,
                a => a.MaHocSinh,
                b => b.PersonId,
                (a, b) => new CTKhenThuongViewModel()
                {
                    Id = a.Id,
                    MaQuyetDinh = a.MaQuyetDinh,
                    MaHocSinh = a.MaHocSinh,
                    HoTen = b.HoTen,
                    LyDoKhenThuong = a.LyDoKhenThuong,
                    HinhThucKhenThuong = a.HinhThucKhenThuong,
                    GiaTriKhenThuong = a.GiaTriKhenThuong,
                    GhiVaoHocBa = a.GhiVaoHocBa,
                    Active = a.Active
                });
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
        /// update ds ctkhenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong">list ctkhenthuong viewmodel</param>
        public void UpdateDsCTQDKhenThuong(IEnumerable<CTKhenThuongViewModel> dsCTKhenThuong)
        {
            var dsCTQDKhenThuong = dsCTKhenThuong
                .Select(e => new CT_QuyetDinhKhenThuong() 
                { 
                    Id = e.Id,
                    MaQuyetDinh = e.MaQuyetDinh,
                    MaHocSinh = e.MaHocSinh,
                    LyDoKhenThuong = e.LyDoKhenThuong,
                    HinhThucKhenThuong = e.HinhThucKhenThuong,
                    GiaTriKhenThuong = e.GiaTriKhenThuong,
                    GhiVaoHocBa = e.GhiVaoHocBa,
                    Active = e.Active
                });

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

        /// <summary>
        /// delete ds ctkhenthuong
        /// </summary>
        /// <param name="dsCTQDKhenThuong">list ctkhenthuong viewmodel</param>
        public void DeleteDsCTQDKhenThuong(IEnumerable<CTKhenThuongViewModel> dsCTKhenThuong)
        {
             var dsCTQDKhenThuong = dsCTKhenThuong
                .Select(e => new CT_QuyetDinhKhenThuong() 
                { 
                    Id = e.Id,
                    MaQuyetDinh = e.MaQuyetDinh,
                    MaHocSinh = e.MaHocSinh,
                    LyDoKhenThuong = e.LyDoKhenThuong,
                    HinhThucKhenThuong = e.HinhThucKhenThuong,
                    GiaTriKhenThuong = e.GiaTriKhenThuong,
                    GhiVaoHocBa = e.GhiVaoHocBa,
                    Active = e.Active
                });

            _CTKhenThuongRepository.FakeDelete(dsCTQDKhenThuong);
        }
    }
}
