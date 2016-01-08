using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service giaovien
    /// </summary>
    public class GiaoVienService: IGiaoVienService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<GiaoVien> _GiaoVienRepository;

        public GiaoVienService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _GiaoVienRepository = _UnitOfWork.Repository<GiaoVien>();
        }

    }
}
