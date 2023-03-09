using FullStackApi.Data;
using FullStackApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public StudentController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
            ;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _fullStackDbContext.Students.ToListAsync();
            return Ok(students);

        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student studentRequest)
        {
            studentRequest.Id = Guid.NewGuid();
            await _fullStackDbContext.Students.AddAsync(studentRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(studentRequest);

        }
      
      




        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student =
               await _fullStackDbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, Student updateStudentRequest)
        {
            var student = await _fullStackDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            student.UserName = updateStudentRequest.UserName;
            student.Password = updateStudentRequest.Password;
            student.UserFirstName = updateStudentRequest.UserFirstName;
            student.UserLastName = updateStudentRequest.UserLastName;

            student.UserEmail = updateStudentRequest.UserEmail;
            student.Phone = updateStudentRequest.Phone;
            student.Address = updateStudentRequest.Address;
        

            await _fullStackDbContext.SaveChangesAsync();
            return Ok(student);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id) {
            var student = await _fullStackDbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Students.Remove(student);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(student);

         }

    }
    }




    

