using SMS.DATA;
using System.Linq;
using SMS.SERVICE.IService;
using System.Collections.Generic;
using SMS.CORE.Data;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service kyluat
    /// </summary>
    public class KyLuatService: IKyLuatService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<ThongTinKyLuat> _KyLuatRepository;

        public KyLuatService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _KyLuatRepository = _UnitOfWork.Repository<ThongTinKyLuat>();
        }

        /// <summary>
        /// get all kyluat
        /// </summary>
        /// <returns>list kyluat</returns>
        public IEnumerable<ThongTinKyLuat> GetAllKyLuat()
        {
            return _KyLuatRepository.Entities.Where(e => e.Active);
        }

        /// <summary>
        /// add ds kyluat
        /// </summary>
        /// <param name="dsKyLuat">list kyluat</param>
        public void AddDsKyLuat(IEnumerable<ThongTinKyLuat> dsKyLuat)
        {
            _KyLuatRepository.Insert(dsKyLuat);
        }

        /// <summary>
        /// update ds kyluat
        /// </summary>
        /// <param name="dsKyLuat">list khenthuong</param>
        public void UpdateDsKyLuat(IEnumerable<ThongTinKyLuat> dsKyLuat)
        {
            _KyLuatRepository.Update(dsKyLuat);
        }

        /// <summary>
        /// delete ds kyluat
        /// </summary>
        /// <param name="dsKyLuat">list kyluat</param>
        public void DeleteDsKyLuat(IEnumerable<ThongTinKyLuat> dsKyLuat)
        {
            _KyLuatRepository.FakeDelete(dsKyLuat);
        }
    }
}
