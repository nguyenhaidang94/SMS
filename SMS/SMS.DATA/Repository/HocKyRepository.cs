using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA.IRepository;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo hocky
    /// </summary>
    public class HocKyRepository: BaseRepository<HocKy>, IHocKyRepository
    {
        public HocKyRepository(SMSContext context)
            :base(context)
        { }

         /// <summary>
        /// get hocky
        /// </summary>
        /// <returns>list hocky</returns>
        public List<HocKy> GetAllHocKy()
        {
            try
            {
                return Entities.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
