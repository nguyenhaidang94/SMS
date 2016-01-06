using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA.IRepository;
using SMS.DATA.Models;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo HocSinh
    /// </summary>
    public class HocSinhRepository: BaseRepository<HocSinh>, IHocSinhRepository
    {
        public HocSinhRepository(SMSContext context)
            : base(context)
        { }

        /// <summary>
        /// get hocsinh viewmodel
        /// </summary>
        /// <returns>list PersonViewModel</returns>
        public IEnumerable<PersonViewModel> GetHocSinhViewModels()
        {
            return Entities.Select(e => new PersonViewModel()
            {
                MaHocSinh = e.PersonId,
                HoTen = e.HoTen
            }).ToList();
        }
    }
}
