﻿using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    public class HocTapService : IHocTapService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<BangDiemHKMH> _BangDiemRepository;

        public HocTapService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _BangDiemRepository = _UnitOfWork.Repository<BangDiemHKMH>();
        }

        /// <summary>
        /// get all bangdiem
        /// </summary>
        /// <returns>list bangdiem</returns>
        public IEnumerable<BangDiemHKMH> GetAllBangDiem()
        {
            var listBangDiem = _BangDiemRepository.Entities.Where(m => m.Active == true);
            foreach (BangDiemHKMH bangdiem in listBangDiem)
            {
                _BangDiemRepository.DbContext.Entry(bangdiem).Collection(m => m.dsCotDiem).Load();
            }
            return listBangDiem;
        }

        /// <summary>
        /// get BangDiem by id
        /// </summary>
        /// <returns>list BangDiem</returns>
        public BangDiemHKMH GetBangDiemByID(int id)
        {
            BangDiemHKMH bangDiem = _BangDiemRepository.Entities.Find(id);
            _BangDiemRepository.DbContext.Entry(bangDiem).Collection(m => m.dsCotDiem).Load();
            return bangDiem;
        }

        /// <summary>
        /// add BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        public void InsertBangDiem(BangDiemHKMH entity)
        {
            _BangDiemRepository.Insert(entity);
        }

        /// <summary>
        /// add list BangDiem
        /// </summary>
        /// <param name="entity">List BangDiem</param>
        public void InsertBangDiem(IEnumerable<BangDiemHKMH> entities)
        {
            _BangDiemRepository.Insert(entities);
        }

        /// <summary>
        /// update BangDiem 
        /// </summary>
        /// <param name="entity">BangDiem</param>
        public void UpdateBangDiem(BangDiemHKMH entity)
        {
            _BangDiemRepository.Update(entity);
        }

        /// <summary>
        /// update list BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        public void UpdateBangDiem(IEnumerable<BangDiemHKMH> entities)
        {
            _BangDiemRepository.Update(entities);
        }

        /// <summary>
        /// delete BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        public void DeleteBangDiem(BangDiemHKMH entity)
        {
            _BangDiemRepository.Delete(entity);
        }

        /// <summary>
        /// delete list BangDiem
        /// </summary>
        /// <param name="entity">BangDiem</param>
        public void DeleteBangDiem(IEnumerable<BangDiemHKMH> entities)
        {
            _BangDiemRepository.Delete(entities);
        }
    }
}