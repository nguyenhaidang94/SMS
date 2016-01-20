using SMS.CORE.Data;
using System.Collections.Generic;
using SMS.SERVICE.IService;
using SMS.DATA;
using System.Linq;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    public class QDKyLuatService: IQDKyLuatService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        private readonly GenericRepository<LopHoc> _LopHocRepository;
        private readonly GenericRepository<QuyetDinhKyLuat> _QDKyLuatRepository;

        public QDKyLuatService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
            _NamHocRepository = _UnitOfWork.Repository<NamHoc>();
            _LopHocRepository = _UnitOfWork.Repository<LopHoc>();
            _QDKyLuatRepository = _UnitOfWork.Repository<QuyetDinhKyLuat>();
        }

        /// <summary>
        /// get all qdkyluat
        /// </summary>
        /// <returns>list qdkyluat</returns>
        public IEnumerable<QuyetDinhKyLuat> GetAllQDKyLuat()
        {
            return _QDKyLuatRepository.Entities
                .Where(e => e.Active);
        }

        /// <summary>
        /// add ds qdkyluat
        /// </summary>
        /// <param name="dsQDKyLuat">list qdkyluat</param>
        public void AddDsQDKyLuat(IEnumerable<QuyetDinhKyLuat> dsQDKyLuat)
        {
            _QDKyLuatRepository.Insert(dsQDKyLuat);
        }

        /// <summary>
        /// update ds qdkyluat
        /// </summary>
        /// <param name="dsQDKyLuat">list qdkyluat</param>
        public void UpdateDsQDKyLuat(IEnumerable<QuyetDinhKyLuat> dsQDKyLuat)
        {
            _QDKyLuatRepository.Update(dsQDKyLuat);
        }

        /// <summary>
        /// delete ds qdkyluat
        /// </summary>
        /// <param name="dsQDKyLuat">list qdkyluat</param>
        public void DeleteDsQdKyLuat(IEnumerable<QuyetDinhKyLuat> dsQDKyLuat)
        {
            _QDKyLuatRepository.FakeDelete(dsQDKyLuat);
        }

        /// <summary>
        /// add ds ctkyluat to qdkyluat has id= maqd
        /// </summary>
        /// <param name="maqd">maquyetdinh</param>
        /// <param name="models">list hocsinh</param>
        public void AddDsCTKyLuat(int maqd, List<SelectHocSinhViewModel> models)
        {
            var qdkyluat = _QDKyLuatRepository.GetEntityById(maqd);
            if (qdkyluat != null)
            {
                _QDKyLuatRepository.DbContext.Entry(qdkyluat).Collection(e => e.dsCTQDKyLuat).Load();
                foreach (var model in models)
                {
                    CT_QuyetDinhKyLuat ctkyluat = new CT_QuyetDinhKyLuat() 
                    { 
                        Id = 0,
                        MaQuyetDinh = maqd,
                        MaHocSinh = model.MaHocSinh,
                        LyDoKyLuat = "",
                        HinhThucKyLuat = "",
                        GhiVaoHocBa = true,
                        Active = true
                    };
                    qdkyluat.dsCTQDKyLuat.Add(ctkyluat);
                    model.Checked = false;
                }
                _QDKyLuatRepository.Update(qdkyluat);
            }
        }
    }
}
