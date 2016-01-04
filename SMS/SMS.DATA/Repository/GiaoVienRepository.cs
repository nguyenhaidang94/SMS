using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA.IRepository;
using SMS.DATA.Models;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo giaovien
    /// </summary>
    public class GiaoVienRepository : BaseRepository<GiaoVien>, IGiaoVienRepository
    {
        public GiaoVienRepository(SMSContext context)
            : base(context)
        { }

        /// <summary>
        /// get all giaovien options
        /// </summary>
        /// <returns>list giaovien options</returns>
        public List<StringOption> GetAllGiaoVienOptions()
        {
            try
            {
                return Entities.Select(e => new StringOption()
                {
                    DisplayText = e.HoTen,
                    Value = e.PersonId
                }).ToList();
            }
            catch
            {           
                throw;
            }
        }
    }
}
