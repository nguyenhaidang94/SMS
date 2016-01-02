using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE.Data;
using SMS.CORE;
using SMS.DATA.IRepository;

namespace SMS.DATA.Repository
{
    public partial class HocKyRepository: BaseRepository<HocKy>, IHocKyRepository
    {
        public HocKyRepository(SMSContext context)
            :base(context)
        { }

         /// <summary>
        /// get hocky
        /// </summary>
        /// <returns>list hocky</returns>
        public IEnumerable<HocKy> GetAllHocKy()
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
