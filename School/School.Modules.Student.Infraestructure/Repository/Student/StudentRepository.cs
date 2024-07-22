using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Modules.Student.BO.Contracts.Student;
using School.Modules.Student.BO.Dtos.Student.Request;
using School.Modules.Student.BO.Dtos.Student.Response;
using School.Modules.Student.BO.Models;
using School.Modules.Student.Infraestructure.Data;
using School.Modules.Student.Infraestructure.Entity;

namespace School.Modules.Student.Infraestructure.Repository.Student
{
    public class StudentRepository: GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(SchoolDbContext schoolDbContext, IMapper mapper)
            : base(schoolDbContext, mapper)
        {
        }

        public async Task<StudentModel> AddStudent(StudentModel student)
        {
            var studentEntity = _mapper.Map<StudentEntity>(student);
            var studentResult = await base.Add(studentEntity);

            return _mapper.Map<StudentModel>(studentEntity);
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            var studentEntities = await _schoolDbContext.Students.ToListAsync();
            return _mapper.Map<IEnumerable<StudentModel>>(studentEntities);
        }

        public async Task<StudentModel> GetById(int id)
        {
            var studentEntity = await _schoolDbContext.Students.FindAsync(id);
            return _mapper.Map<StudentModel>(studentEntity);
        }

        public async Task<StudentModel> UpdateStudent(StudentModel student)
        {
            var studentEntity = _mapper.Map<StudentEntity>(student);

            _schoolDbContext.ChangeTracker.Clear();
            _schoolDbContext.Students.Update(studentEntity);
            await _schoolDbContext.SaveChangesAsync();

            return _mapper.Map<StudentModel>(studentEntity);
        }

        public async Task DeleteStudent(StudentModel student)
        {
            var studentEntity = _mapper.Map<StudentEntity>(student);

            _schoolDbContext.ChangeTracker.Clear();
            _schoolDbContext.Students.Remove(studentEntity);
            await _schoolDbContext.SaveChangesAsync();
        }
    }
}
