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
    /// Service CTKyLuat
    /// </summary>
    public class CTQDKyLuatService : ICTQDKyLuatService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<CT_QuyetDinhKyLuat> _CTKyLuatRepository;
        private readonly GenericRepository<Nguoi> _NguoiRepository;
        private readonly GenericRepository<LopHoc> _LopRepository;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;

        public CTQDKyLuatService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _CTKyLuatRepository = _UnitOfWork.Repository<CT_QuyetDinhKyLuat>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
            _LopRepository = _UnitOfWork.Repository<LopHoc>();
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
        }

        /// <summary>
        /// get all ctqd kyluat
        /// </summary>
        /// <returns>list ctqd kyluat</returns>
        public IEnumerable<CT_QuyetDinhKyLuat> GetAllCTQDKyLuat()
        {
            return _CTKyLuatRepository.Entities.Where(e => e.Active);
        }

        /// <summary>
        /// get all ctKyLuat viewmodel
        /// </summary>
        /// <returns>list ctKyLuat viewmodel</returns>
        public IEnumerable<CTKyLuatViewModel> GetAllCTKyLuatVM()
        {
            return _CTKyLuatRepository.Entities.Where(e => e.Active)
                .Join(_HocSinhRepository.Entities,
                a => a.MaHocSinh,
                b => b.PersonId,
                (a, b) => new CTKyLuatViewModel()
                {
                    Id = a.Id,
                    MaQuyetDinh = a.MaQuyetDinh,
                    MaHocSinh = a.MaHocSinh,
                    HoTen = b.HoTen,
                    LyDoKyLuat = a.LyDoKyLuat,
                    HinhThucKyLuat = a.HinhThucKyLuat,
                    GhiVaoHocBa = a.GhiVaoHocBa,
                    Active = a.Active
                });
        }

        /// <summary>
        /// get all ctKyLuat in qdKyLuat
        /// </summary>
        /// <returns>list ctKyLuat viewmodel</returns>
        public IEnumerable<CTKyLuatViewModel> GetCTKyLuatInQDKyLuat(int maqd)
        {
            return _CTKyLuatRepository.Entities
                .Where(e => e.MaQuyetDinh == maqd && e.Active)
                .Join(_HocSinhRepository.Entities,
                a => a.MaHocSinh,
                b => b.PersonId,
                (a, b) => new CTKyLuatViewModel()
                {
                    Id = a.Id,
                    MaQuyetDinh = a.MaQuyetDinh,
                    MaHocSinh = a.MaHocSinh,
                    HoTen = b.HoTen,
                    LyDoKyLuat = a.LyDoKyLuat,
                    HinhThucKyLuat = a.HinhThucKyLuat,
                    GhiVaoHocBa = a.GhiVaoHocBa,
                    Active = a.Active
                });
        }

        /// <summary>
        /// add ds ctqd kyluat
        /// </summary>
        /// <param name="dsCTQDKyLuat"></param>
        public void AddDsCTQDKyLuat(IEnumerable<CT_QuyetDinhKyLuat> dsCTQDKyLuat)
        {
            _CTKyLuatRepository.Insert(dsCTQDKyLuat);
        }

        /// <summary>
        /// update ds ctqd kyluat
        /// </summary>
        /// <param name="dsCTQDKyLuat">list ctqd kyluat</param>
        public void UpdateDsCTQDKyLuat(IEnumerable<CT_QuyetDinhKyLuat> dsCTQDKyLuat)
        {
            _CTKyLuatRepository.Update(dsCTQDKyLuat);
        }

        /// <summary>
        /// update ds ctKyLuat
        /// </summary>
        /// <param name="dsCTQDKyLuat">list ctKyLuat viewmodel</param>
        public void UpdateDsCTQDKyLuat(IEnumerable<CTKyLuatViewModel> dsCTKyLuat)
        {
            var dsCTQDKyLuat = dsCTKyLuat
                .Select(e => new CT_QuyetDinhKyLuat()
                {
                    Id = e.Id,
                    MaQuyetDinh = e.MaQuyetDinh,
                    MaHocSinh = e.MaHocSinh,
                    LyDoKyLuat = e.LyDoKyLuat,
                    HinhThucKyLuat = e.HinhThucKyLuat,
                    GhiVaoHocBa = e.GhiVaoHocBa,
                    Active = e.Active
                });

            _CTKyLuatRepository.Update(dsCTQDKyLuat);
        }

        /// <summary>
        /// delete ds ctqd kyluat
        /// </summary>
        /// <param name="dsCTQDKyLuat"></param>
        public void DeleteDsCTQDKyLuat(IEnumerable<CT_QuyetDinhKyLuat> dsCTQDKyLuat)
        {
            _CTKyLuatRepository.FakeDelete(dsCTQDKyLuat);
        }

        /// <summary>
        /// delete ds ctKyLuat
        /// </summary>
        /// <param name="dsCTQDKyLuat">list ctKyLuat viewmodel</param>
        public void DeleteDsCTQDKyLuat(IEnumerable<CTKyLuatViewModel> dsCTKyLuat)
        {
            var dsCTQDKyLuat = dsCTKyLuat
               .Select(e => new CT_QuyetDinhKyLuat()
               {
                   Id = e.Id,
                   MaQuyetDinh = e.MaQuyetDinh,
                   MaHocSinh = e.MaHocSinh,
                   LyDoKyLuat = e.LyDoKyLuat,
                   HinhThucKyLuat = e.HinhThucKyLuat,
                   GhiVaoHocBa = e.GhiVaoHocBa,
                   Active = e.Active
               });

            _CTKyLuatRepository.FakeDelete(dsCTQDKyLuat);
        }
    }
}
