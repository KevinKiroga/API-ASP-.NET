using School.Modules.Student.BO.Contracts;
using School.Modules.Student.BO.Dtos.Student.Request;
using School.Modules.Student.BO.Dtos.Student.Response;
using School.Modules.Student.BO.Models;
using School.Modules.Student.Infraestructure.Repository;
using School.Modules.Student.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Modules.Student.Logic.Services
{
    public class StudentService: IStudentService
    {
        protected readonly IUoWConfig _uoWConfig;

        public StudentService(IUoWConfig uoWConfig)
        {
            _uoWConfig = uoWConfig;
        }

        public async Task<StudentResponse> Create(StudentRequest request)
        {
            var student = await _uoWConfig.StudentRepository.AddStudent(
                new StudentModel
                {
                    FullName = request.FullName,
                    Age = request.Age,
                    DateOfBirth = request.DateOfBirth,
                }
            );

            await _uoWConfig.CommitAsync();
            return new StudentResponse(student.Id, student.FullName, student.Age, student.DateOfBirth);
        }

        public async Task<IEnumerable<StudentResponse>> GetAll()
        {
            var students = await _uoWConfig.StudentRepository.GetAllStudents();
            return students.Select(s => new StudentResponse(s.Id, s.FullName, s.Age, s.DateOfBirth)); 
        }

        public async Task<StudentResponse> GetById(int id)
        {
            var student = await _uoWConfig.StudentRepository.GetById(id);
            return new StudentResponse(student.Id, student.FullName, student.Age, student.DateOfBirth);
        }

        public async Task<StudentResponse> Update(int id, StudentRequest request)
        {
            var student = await _uoWConfig.StudentRepository.GetById(id);
            
            student.FullName = request.FullName;
            student.Age = request.Age;
            student.DateOfBirth = request.DateOfBirth;

            var studentUpdate = await _uoWConfig.StudentRepository.UpdateStudent(student);
            return new StudentResponse(student.Id, student.FullName, student.Age, student.DateOfBirth);

        }

        public async Task Delete(int id)
        {
            var student = await _uoWConfig.StudentRepository.GetById(id);
            await _uoWConfig.StudentRepository.DeleteStudent(student);
        }

    }
}
