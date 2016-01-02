using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.DATA.IRepository;
using SMS.CORE.Data;

namespace SMS.DATA.Repository
{
    public partial class NamHocRepository: BaseRepository<NamHoc>, INamHocRepository
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
            try
            {
                var namhoc = Entities.ToList();
                return namhoc;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// add namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void AddNamHoc(NamHoc entity)
        {
            try
            {
                Insert(entity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// update namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void UpdateNamHoc(NamHoc entity)
        {
            try
            {
                Update(entity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// delete namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void DeleteNamHoc(NamHoc entity)
        {
            try
            {
                Delete(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
