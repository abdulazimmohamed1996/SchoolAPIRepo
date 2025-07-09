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
    }
}
