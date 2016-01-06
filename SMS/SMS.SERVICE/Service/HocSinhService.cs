using System.Collections.Generic;
using SMS.DATA;
using SMS.DATA.IRepository;
using SMS.DATA.Models;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service hocsinh
    /// </summary>
    public class HocSinhService: IHocSinhService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly IHocSinhRepository _HocSinhRepository;

        public HocSinhService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.HocSinhRepository;
        }

        /// <summary>
        /// get hocsinh viewmodel
        /// </summary>
        /// <returns>list PersonViewModel</returns>
        public IEnumerable<PersonViewModel> GetHocSinhViewModels()
        {
            return _HocSinhRepository.GetHocSinhViewModels();
        }
    }
}
