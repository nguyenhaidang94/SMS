﻿using SMS.CORE.Data;
using System.Collections.Generic;
using SMS.SERVICE.IService;
using SMS.DATA;
using System.Linq;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    class HocSinhEqualityComparer : IEqualityComparer<HocSinh>
    {
        public bool Equals(HocSinh x, HocSinh y)
        {
            return x.PersonId == y.PersonId;
        }

        public int GetHashCode(HocSinh obj)
        {
            return obj.PersonId.GetHashCode();
        }
    }

    /// <summary>
    /// service qdkhenthuong
    /// </summary>
    public class QDKhenThuongService: IQDKhenThuongService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<QuyetDinhKhenThuong> _QDKhenThuongRepository;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        private readonly GenericRepository<LopHoc> _LopHocRepository;

        public QDKhenThuongService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _QDKhenThuongRepository = unitOfWork.Repository<QuyetDinhKhenThuong>();
            _HocSinhRepository = unitOfWork.Repository<HocSinh>();
            _NamHocRepository = unitOfWork.Repository<NamHoc>();
            _LopHocRepository = unitOfWork.Repository<LopHoc>();
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

        /// <summary>
        /// get all SelectHocSinhViewModel
        /// </summary>
        /// <returns>list SelectHocSinhViewModel</returns>
        public IEnumerable<SelectHocSinhViewModel> GetAllSelectHocSinhVM()
        {
            List<SelectHocSinhViewModel> dsHocSinh = new List<SelectHocSinhViewModel>();
            
            var dsNamHoc = _NamHocRepository.Entities.Where(e => e.Active);
            foreach (var namhoc in dsNamHoc)
            {
                var dsLopHoc = _LopHocRepository.Entities.Where(e => e.Active && e.MaNamHoc == namhoc.MaNamHoc);
                foreach (var lophoc in dsLopHoc)
                { 
                    var dshs = _LopHocRepository.Entities
                        .SelectMany(e => e.dsHocSinh.Where(o => o.Active))
                        .Select(e => new SelectHocSinhViewModel() 
                        { 
                            MaHocSinh = e.PersonId,
                            MaNamHoc = namhoc.MaNamHoc,
                            MaLop = lophoc.MaLopHoc,
                            HoTen = e.HoTen,
                            NgaySinh = e.NgaySinh,
                            GioiTinh = e.GioiTinh,
                            Checked = false
                        });
                    dsHocSinh.AddRange(dshs);
                }
            }

            return dsHocSinh;
        }

        /// <summary>
        /// get hocsinh not in qdkhenthuong has id= maqd
        /// </summary>
        /// <param name="maqd">qdkhenthuong's id</param>
        /// <returns>list SelectHocSinhViewModel</returns>
        public IEnumerable<SelectHocSinhViewModel> GetHocSinhNotInQDKhenThuong(int maqd)
        {
            var qd = _QDKhenThuongRepository.GetEntityById(maqd);
            if (qd != null)
            {
                var dsHocSinh = _QDKhenThuongRepository.Entities
                    .SelectMany(e => e.dsCTQDKhenThuong.Select(o => o.HocSinh)).ToArray();
                var dsAllHocSinh = _HocSinhRepository.Entities.Where(e => e.Active).ToArray();

                return dsAllHocSinh.Except(dsHocSinh, new HocSinhEqualityComparer())
                    .Select(e => new SelectHocSinhViewModel()
                    {
                        MaHocSinh = e.PersonId,
                        HoTen = e.HoTen,
                        NgaySinh = e.NgaySinh,
                        GioiTinh = e.GioiTinh,
                        Checked = false
                    });
            }
            else
                return GetAllSelectHocSinhVM();
        }

        /// <summary>
        /// add ds ctkhenthuong to qdkhenthuong has id= maqd
        /// </summary>
        /// <param name="maqd">maquyetdinh</param>
        /// <param name="models">list hocsinh</param>
        public void AddDsCTKhenThuong(int maqd, List<SelectHocSinhViewModel> models)
        {
            var qdkhenthuong = _QDKhenThuongRepository.GetEntityById(maqd);
            if (qdkhenthuong != null)
            {
                _QDKhenThuongRepository.DbContext.Entry(qdkhenthuong).Collection(e => e.dsCTQDKhenThuong).Load();
                foreach (var model in models)
                {
                    CT_QuyetDinhKhenThuong ctkhenthuong = new CT_QuyetDinhKhenThuong() 
                    { 
                        Id = 0,
                        MaQuyetDinh = maqd,
                        MaHocSinh = model.MaHocSinh,
                        LyDoKhenThuong = "",
                        HinhThucKhenThuong = "",
                        GiaTriKhenThuong = null,
                        GhiVaoHocBa = true,
                        Active = true
                    };
                    qdkhenthuong.dsCTQDKhenThuong.Add(ctkhenthuong);
                    model.Checked = false;
                }
                _QDKhenThuongRepository.Update(qdkhenthuong);
            }
        }
    }
}
