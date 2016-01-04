using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.DATA;
using SMS.DATA.IRepository;
using SMS.DATA.Models;
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

        /// <summary>
        /// get all giaovien options
        /// </summary>
        /// <returns>list giaovien options</returns>
        public List<StringOption> GetAllGiaoVienOptions()
        {
            try
            {
                return _GiaoVienRepository.GetAllGiaoVienOptions();
            }
            catch
            {
                throw;
            }
        }
    }
}
