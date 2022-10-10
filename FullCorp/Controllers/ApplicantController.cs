//using FullCorp.Interfaces;
//using FullCorp.Models.Dto.Applicant;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FullCorp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ApplicantController : ControllerBase
//    {

//        private readonly IApplicantRepository _applicantRepository;

//        public ApplicantController(IApplicantRepository applicantRepository)
//        {
//            _applicantRepository = applicantRepository;
//        }

//        [HttpGet("GetApplicant")]
//        public async Task<IActionResult> GetApplicant()
//        {
//            var applicant = await _applicantRepository.GetApplicants();
//            if (applicant != null) return Ok(applicant);
//            else
//                return NotFound();
//        }

//        [HttpPost("CreateApplicant")]
//        public async Task<IActionResult> CreateApplicant(CreateApplicantDto param)
//        {
//            var applicant = await _applicantRepository.CreateApplicant(param);
//            if (applicant != null) return Ok(true);
//            else
//                return NotFound();
//        }
//    }
//}
