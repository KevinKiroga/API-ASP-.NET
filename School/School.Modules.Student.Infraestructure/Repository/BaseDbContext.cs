using AutoMapper;
using School.Modules.Student.Infraestructure.Data;

namespace School.Modules.Student.Infraestructure.Repository
{
    public class BaseDbContext
    {
        #region Propiedades
        protected readonly SchoolDbContext _schoolDbContext;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructores
        public BaseDbContext(SchoolDbContext schoolDbContext, IMapper mapper)
        {
            _schoolDbContext = schoolDbContext;
            _mapper = mapper;
        }
        #endregion
    }
}
