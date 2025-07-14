using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWith.Core.Dtos.Subjects;
using SchoolWith.Core.Interfaces;

namespace School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupjectController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("AddSupject")]
        public async Task<IActionResult> AddSupject(AddSubjectDto addSubjectDto)
        {
            var result = await _unitOfWork.Supjects.AddSubject(addSubjectDto);
            if(result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Subject);
        }
        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> getAllSupjects()
        {
            var AllSupjects = await _unitOfWork.Supjects.getAllSubjects();
            return Ok(AllSupjects);
        }
        [HttpPut("EditSubject")]
        public async Task<IActionResult> UpdateSupject(EditSupjectDto editSupjectDto)
        {
            var result = await _unitOfWork.Supjects.EditSupject(editSupjectDto);
            if(result.Message != string.Empty)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Subject);
        }
        [HttpDelete("DeleteSupject")]
        public async Task<IActionResult> DeleteSupject(int supjectId)
        {
            var result = await _unitOfWork.Supjects.DeletSupject(supjectId);
            if(result.Fail != string.Empty)
            {
                return BadRequest(result.Fail);
            }
            return Ok(result.Success);
        }
    }
}
