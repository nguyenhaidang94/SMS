using SMS.CORE.Data;
using SMS.DATA.IRepository;

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


    }
}
