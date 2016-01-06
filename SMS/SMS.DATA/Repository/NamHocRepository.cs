using System.Collections.Generic;
using System.Linq;
using SMS.DATA.IRepository;
using SMS.CORE.Data;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo namhoc
    /// </summary>
    public class NamHocRepository: BaseRepository<NamHoc>, INamHocRepository
    {
        public NamHocRepository(SMSContext context)
            : base(context)
        { }

        /// <summary>
        /// get namhoc
        /// </summary>
        /// <returns>list namhoc</returns>
        public IEnumerable<NamHoc> GetAllNamHoc()
        {
            var namhoc = Entities.ToList();
            return namhoc;
        }

        /// <summary>
        /// add namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void AddNamHoc(NamHoc entity)
        {
            Insert(entity);
        }

        /// <summary>
        /// update namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void UpdateNamHoc(NamHoc entity)
        {
            Update(entity);
        }

        /// <summary>
        /// delete namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void DeleteNamHoc(NamHoc entity)
        {
            Delete(entity);
        }

        /// <summary>
        /// set entity to inactive
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void FakeDeleteNamHoc(NamHoc entity)
        {
            FakeDelete(entity);
        }
    }
}
