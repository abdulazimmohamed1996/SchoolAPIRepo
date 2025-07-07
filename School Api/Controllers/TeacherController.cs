using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWith.Core.Dtos.Students;
using SchoolWith.Core.Dtos.Teachers;
using SchoolWith.Core.Interfaces;

namespace School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost(Name = "AddTeacher")]
        public async Task<IActionResult> AddTeacher(addteacherDto addteacherDto)
        {
            var result = await _unitOfWork.Teachers.AddTeacher(addteacherDto);
            if (result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Teacher);
        }
        [HttpGet("GetAllTeacher")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var result = await _unitOfWork.Teachers.getAllTeachers();
            return Ok(result);
        }
        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateStudent([FromBody] EditTeacherDto editTeacherDto)
        {
            var result = await _unitOfWork.Teachers.editTeacher(editTeacherDto);
            if (result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Teacher);
        }
        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteStudent(int teacherId)
        {
            var result = await _unitOfWork.Teachers.deleteTeacher(teacherId);
            if (result.Fail != string.Empty)
            {
                return BadRequest(result.Fail);
            }
            return Ok(result.Success);
        }
    }
}
