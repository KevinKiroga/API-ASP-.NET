using AutoMapper;
using School.Modules.Student.BO.Contracts.Student;
using School.Modules.Student.Infraestructure.Data;
using School.Modules.Student.Infraestructure.Repository.Student;

namespace School.Modules.Student.Infraestructure.Repository
{
    public class UnitOfWorkConfig : IUoWConfig
    {
        protected readonly SchoolDbContext _context;
        protected readonly IMapper _mapper;

        public UnitOfWorkConfig(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Repositories
        IStudentRepository _studentRepository;
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context, _mapper);
                }
                return _studentRepository;
            }
        }
            #endregion

            #region Methods
            public void Commit() => _context.SaveChanges();
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public async Task ContextClear()
        {
            _context.ChangeTracker.Clear();
            _context?.ChangeTracker?.Clear();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
                _context?.Dispose();
            }
        }
        #endregion
    }
}
