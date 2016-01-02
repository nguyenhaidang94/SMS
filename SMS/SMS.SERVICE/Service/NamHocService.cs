using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.SERVICE.IService;
using SMS.DATA.Repository;
using SMS.DATA;
using SMS.CORE.Data;
using SMS.DATA.IRepository;

namespace SMS.SERVICE.Service
{
    public partial class NamHocService: INamHocService
    {
        private UnitOfWork _UnitOfWork;
        private INamHocRepository _NamHocRepository;
        
        public NamHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _NamHocRepository = _UnitOfWork.NamHocRepository;
        }

        /// <summary>
        /// get namhoc
        /// </summary>
        /// <returns>list namhoc</returns>
        public IEnumerable<NamHoc> GetAllNamHoc()
        {
            return _NamHocRepository.GetAllNamHoc();
        }

        /// <summary>
        /// add namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void AddNamHoc(NamHoc entity)
        {
            _NamHocRepository.AddNamHoc(entity);
            _UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// update namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void UpdateNamHoc(NamHoc entity)
        {
            _NamHocRepository.UpdateNamHoc(entity);
            _UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// delete namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void DeleteNamHoc(NamHoc entity)
        {
            _NamHocRepository.DeleteNamHoc(entity);
            _UnitOfWork.SaveChanges();
        }
    }
}
