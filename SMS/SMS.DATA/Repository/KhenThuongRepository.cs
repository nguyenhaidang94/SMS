using System;
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
        public IEnumerable<ThongTinKhenThuong> GetAllKhenThuong()
        {
            return Entities.ToList();
        }

        /// <summary>
        /// add thongtinkhenthuong
        /// </summary>
        /// <param name="entity">thongtinkhenthuong</param>
        public void AddKhenThuong(ThongTinKhenThuong entity)
        {
            Insert(entity);
        }
    }
}
