using SMS.DATA;
using SMS.DATA.IRepository;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service giaovien
    /// </summary>
    public class GiaoVienService: IGiaoVienService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IGiaoVienRepository _GiaoVienRepository;

        public GiaoVienService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _GiaoVienRepository = _UnitOfWork.GiaoVienRepository;
        }

    }
}
