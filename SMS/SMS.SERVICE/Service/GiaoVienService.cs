using SMS.CORE.Data;
using SMS.DATA;
using System.Linq;
using SMS.SERVICE.IService;
using System.Collections.Generic;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service giaovien
    /// </summary>
    public class GiaoVienService: IGiaoVienService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<GiaoVien> _GiaoVienRepository;
        private readonly GenericRepository<Nguoi> _NguoiRepository;

        public GiaoVienService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _GiaoVienRepository = _UnitOfWork.Repository<GiaoVien>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
        }

        /// <summary>
        /// get all giaovien
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Nguoi> GetAllGiaoVien()
        {
            //giaovien's persontypeid is 1
            return _NguoiRepository.Entities
                .Where(e => e.PersonTypeId == 1 && e.Active == true);
        }
    }
}
