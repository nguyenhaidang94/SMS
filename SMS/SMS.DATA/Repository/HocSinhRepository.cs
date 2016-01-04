using System;
using SMS.CORE.Data;
using SMS.DATA.IRepository;
using System.Collections.Generic;
using System.Linq;
using SMS.DATA.Models;

namespace SMS.DATA.Repository
{
    /// <summary>
    /// Repo HocSinh
    /// </summary>
    public class HocSinhRepository: BaseRepository<HocSinh>, IHocSinhRepository
    {
        public HocSinhRepository(SMSContext context)
            : base(context)
        { }

        /// <summary>
        /// get all hocsinh options
        /// </summary>
        /// <returns>list hocsinh options</returns>
        public List<StringOption> GetAllHocSinhOptions()
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
