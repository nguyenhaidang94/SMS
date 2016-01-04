using System.Collections.Generic;
using SMS.DATA;
using SMS.DATA.IRepository;
using SMS.DATA.Models;
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

        public List<IntOption> GetAllTietHocOptions()
        {
            try
            {
                return _TietHocRepository.GetAllTietHocOptions();
            }
            catch
            {
                throw;
            }
        }
    }
}