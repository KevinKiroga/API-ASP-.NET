using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Modules.Student.BO.Contracts;
using School.Modules.Student.Infraestructure.Data;

namespace School.Modules.Student.Infraestructure.Repository
{
    public class GenericRepository<T> : BaseDbContext, IGenericRepository<T> where T : class
    {
        protected readonly SchoolDbContext _schoolDbContext;
        protected readonly IMapper _mapper;

        public GenericRepository(SchoolDbContext schoolDbContext, IMapper mapper)
            :base(schoolDbContext, mapper)
        {
            _schoolDbContext = schoolDbContext;
            _mapper = mapper;
        }

        public async Task<T> Add(T entity) => 
            (await _schoolDbContext.Set<T>().AddAsync(entity))?.Entity;

        public void Delete(T entity) => _schoolDbContext.Set<T>().Remove(entity);

        public async Task<T> Get(int id) => await _schoolDbContext.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() =>
            await _schoolDbContext.Set<T>().ToListAsync();

        public async Task Update(T entity) =>
            await Task.FromResult(_schoolDbContext.Set<T>().Update(entity));
    }
}
