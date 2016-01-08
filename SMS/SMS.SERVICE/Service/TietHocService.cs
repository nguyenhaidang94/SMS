using SMS.CORE.Data;
using SMS.DATA;
using System.Linq;
using SMS.SERVICE.IService;
using System.Collections.Generic;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// Service TietHoc
    /// </summary>
    public class TietHocService: ITietHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<TietHoc> _TietHocRepository;

        public TietHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _TietHocRepository = _UnitOfWork.Repository<TietHoc>();
        }

        /// <summary>
        /// get all tiethoc
        /// </summary>
        /// <returns>list tiethoc</returns>
        public IEnumerable<TietHoc> GetAllTietHoc()
        {
            return _TietHocRepository.Entities.Where(e => e.Active);
        }
    }
}