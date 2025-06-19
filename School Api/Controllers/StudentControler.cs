using Microsoft.AspNetCore.Mvc;
using SchoolWith.Core.Dtos.Students;
using SchoolWith.Core.Interfaces;
using SchoolWith.Core.Models;

namespace School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentControler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(AddStudentDto studentDto)
        {
            var result = await _unitOfWork.Students.AddStudent(studentDto);
            if (result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Student);
        }
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> getAllStudents()
        {
            var result = await _unitOfWork.Students.GetAllStudents();
            return Ok(result);
        }
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] EditStudentDto student)
        {
            var result = await _unitOfWork.Students.UpdateDtudent(student);
            if (result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Student);
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int StudentId)
        {
            var result = await _unitOfWork.Students.DeleteStudent(StudentId);
            return Ok(result);
        }
    }
}
