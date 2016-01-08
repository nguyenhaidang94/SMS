using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
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
        private readonly GenericRepository<HocSinh> _HocSinhRepository;

        public HocSinhService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
        }

        /// <summary>
        /// get hocsinh viewmodel
        /// </summary>
        /// <returns>list PersonViewModel</returns>
        public IEnumerable<PersonViewModel> GetHocSinhViewModels()
        {
            return _HocSinhRepository.Entities.Select(e => new PersonViewModel()
            {
                MaHocSinh = e.PersonId,
                HoTen = e.HoTen
            }).ToList(); 
        }
    }
}
