using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

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
    }
}