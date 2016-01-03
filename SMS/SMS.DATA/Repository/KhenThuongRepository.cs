using SMS.CORE.Data;
using SMS.DATA.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo khenthuong
    /// </summary>
    public class KhenThuongRepository : BaseRepository<ThongTinKhenThuong>, IKhenThuongRepository
    {
        public KhenThuongRepository(SMSContext context)
            :base(context)
        { }

        /// <summary>
        /// get all khenthuong
        /// </summary>
        /// <returns>list khenthuong</returns>
        public List<ThongTinKhenThuong> GetAllKhenThuong()
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
