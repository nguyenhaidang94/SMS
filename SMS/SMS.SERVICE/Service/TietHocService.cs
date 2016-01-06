using SMS.DATA;
using SMS.DATA.IRepository;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// Service TietHoc
    /// </summary>
    public class TietHocService: ITietHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly ITietHocRepository _TietHocRepository;

        public TietHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _TietHocRepository = _UnitOfWork.TietHocRepository;
        }
    }
}