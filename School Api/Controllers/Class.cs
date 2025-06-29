using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWith.Core.Dtos.Classes;
using SchoolWith.Core.Interfaces;

namespace School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Class : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Class(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("AddClass")]
        public async Task<IActionResult> addClass(AddClassDto addClassDto) { 
            var result = await _unitOfWork.Classes.addClass(addClassDto);
            if (result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Class);
        }
        [HttpGet("GetAllClasses")]
        public async Task<IActionResult> getAllClasses()
        {
            var result = await _unitOfWork.Classes.getAllClasses();
            return Ok(result);
        }
        [HttpPut("UpdateClass")]
        public async Task<IActionResult> EditClass([FromBody] EditClassDto dto)
        {
            var result = await _unitOfWork.Classes.updateClass(dto);
            if (result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpDelete("DeleteClass")]
        public async Task<IActionResult> DeleteClass(int ClassId)
        {
            var result = await _unitOfWork.Classes.deleteClass(ClassId);
            if (result.Fail != string.Empty)
            {
                return BadRequest(result.Fail);
            }
            return Ok(result.Success);
        }
    }
}
