using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service hocsinh
    /// </summary>
    public class HocSinhService: IHocSinhService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;
        private readonly GenericRepository<Nguoi> _NguoiRepository;

        public HocSinhService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
        }

        /// <summary>
        /// get all hocsinh
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Nguoi> GetAllHocSinh()
        {
            //giaovien's persontypeid is 2
            return _NguoiRepository.Entities
                .Where(e => e.PersonTypeId == 2 && e.Active);
        }
        
    }
}
