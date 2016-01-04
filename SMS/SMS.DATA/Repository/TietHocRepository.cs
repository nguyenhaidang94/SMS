using System;
using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA.IRepository;
using SMS.DATA.Models;

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

        /// <summary>
        /// get all tiethoc options
        /// </summary>
        /// <returns>list tiethoc options</returns>
        public List<IntOption> GetAllTietHocOptions()
        {
            try
            {
                return Entities.Select(e => new IntOption()
                {
                    Value = e.MaTietHoc,
                    DisplayText = e.MaTietHoc.ToString()
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}