
using SMS.CORE.Data;
using SMS.DATA.IRepository;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo TietHoc
    /// </summary>
    public class TietHocRepository: BaseRepository<TietHoc>, ITietHocRepository
    {
        public TietHocRepository(SMSContext context)
            : base(context)
        { }

    }
}