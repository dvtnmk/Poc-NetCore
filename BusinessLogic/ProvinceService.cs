using Microsoft.EntityFrameworkCore;
using NetCore.DataLayer;
using NetCore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public interface IProvinceService : IService<Province>
    {
        IQueryable<Province> AdvanceSearch();

    }

    public class ProvinceService : IProvinceService
    {
        private readonly MyContext _context;
        private readonly Repository<Province> _repository;

        public ProvinceService()
        {
            _context = new MyContext();
            _repository = new Repository<Province>(_context);
        }

        public IQueryable<Province> AdvanceSearch()
        {
            throw new NotImplementedException();
        }

        public void Add(Province entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            _repository.Add(entity);
        }

        public Province get(object id)
        {
            return _repository.GetQuery().Where(t=> t.ProvinceCode == id.ToString())
                .Include(t=>t.AumphurList).SingleOrDefault();
        }

        public IQueryable<Province> Get()
        {
            return _repository.GetQuery();
        }

        public int Save()
        {
            return _repository.SaveChange();
        }

        public void Update(object id, Province entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            var result = _repository.GetQuery().Where(t => t.ProvinceCode == id.ToString());
            if (result == null)
                throw new KeyNotFoundException("ID is not found.");
            _repository.SaveChange();
        }
    }
}
