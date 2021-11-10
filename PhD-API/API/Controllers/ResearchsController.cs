using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Research;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.UnitOfWork;
using System;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using API.Errors;
using Utilities.StaticHelpers;
using Domain.Enums;
using API.IHelpers;
using Microsoft.AspNetCore.Authorization;
using API.DTO.Account;
using API.IService;
using System.Security.Claims;
using System.Linq;
using API.DTO;
using System.IO;
using OfficeOpenXml;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResearchRepository _researchRepository;
        private readonly IResearchService _researchService;
        private readonly IAnswerRadioService _answerRadioService;
        private readonly IAnswerNumberService _answerNumberService;
        private readonly IAnswerCheckboxService _answerCheckboxService;
        private readonly IAnswerMultiAmountService _answerMultiAmountService;
        private readonly IAnswerMultiPercentageService _answerMultiPercentageService;
        private readonly IAnswerMultiCheckboxService _answerMultiCheckboxService;
        private readonly IResearchQuestionService _researchQuestionService;
        private readonly IJWTManager _jwtManager;
        private readonly IAnswerCheckboxRepository _answerCheckboxRepository;
        private readonly IAnswerMultiPercentageRepository _answerMultiPercentageRepository;
        private readonly IAnswerMultiCheckboxRepository _answerMultiCheckboxRepository;

        public ResearchsController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IResearchRepository researchRepository,
            IJWTManager jwtManager,
            IResearchService researchService,
            IAnswerRadioService answerRadioService,
            IAnswerCheckboxService answerCheckboxService,
            IAnswerNumberService answerNumberService,
            IAnswerMultiAmountService answerMultiAmountService,
            IAnswerMultiPercentageService answerMultiPercentageService,
            IAnswerMultiCheckboxService answerMultiCheckboxService,
            IResearchQuestionService researchQuestionService,
            IAnswerCheckboxRepository answerCheckboxRepository,
            IAnswerMultiPercentageRepository answerMultiPercentageRepository,
            IAnswerMultiCheckboxRepository answerMultiCheckboxRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _researchRepository = researchRepository;
            _jwtManager = jwtManager;
            _researchService = researchService;
            _answerRadioService = answerRadioService;
            _answerCheckboxService = answerCheckboxService;
            _answerNumberService = answerNumberService;
            _answerMultiAmountService = answerMultiAmountService;
            _answerMultiPercentageService = answerMultiPercentageService;
            _answerMultiCheckboxService = answerMultiCheckboxService;
            _researchQuestionService = researchQuestionService;
            _answerCheckboxRepository = answerCheckboxRepository;
            _answerMultiPercentageRepository = answerMultiPercentageRepository;
            _answerMultiCheckboxRepository = answerMultiCheckboxRepository;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register(ResearchForRegisterDTO model)
        {
            if (await _researchRepository.IsExist(model.Email).ConfigureAwait(true))
                return Conflict(new ApiResponse(409, StringConsts.EXISTED));

            Research research = _mapper.Map<Research>(model);

            SecurePassword.CreatePasswordHash(SecurePassword.GeneratePassword(8), out byte[] passwordHash, out byte[] passwordSalt);
            research.PasswordSalt = passwordSalt;
            research.PasswordHash = passwordHash;

            await _researchRepository.AddAsync(research).ConfigureAwait(true);

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);


            Email.Send("PhD", research.Email, "Register", _researchService.CreateRegisterMailTemplate(research.Name));

            return Ok();
        }

        [HttpPatch("{id}/ChangePassword")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> ChangePassword(int id, ResearchForChangePasswordDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _researchRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", id)));

            Research research = await _researchRepository.GetAsync(model.Id).ConfigureAwait(true);
            SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            research.PasswordHash = passwordHash;
            research.PasswordSalt = passwordSalt;
            research.IsRandomPassword = false;

            _researchRepository.Edit(research);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(research) });

        }

        [HttpPatch("status")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> PatchStatus(ResearchForStatusDTO model)
        {

            if (!await _researchRepository.IsExist(model.Id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", model.Id)));

            Research research = await _researchRepository.GetAsync(model.Id).ConfigureAwait(true);
            Enum.TryParse(model.Status, out ResearchStatusEnum status);
            research.Status = status;
            _researchRepository.Edit(research);

            switch (status)
            {
                case ResearchStatusEnum.Accepted:
                    string ranadomPassword = SecurePassword.GeneratePassword(8);
                    SecurePassword.CreatePasswordHash(ranadomPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    research.PasswordHash = passwordHash;
                    research.PasswordSalt = passwordSalt;
                    research.IsRandomPassword = true;
                    _researchRepository.Edit(research);

                    await _answerRadioService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerCheckboxService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerNumberService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerMultiAmountService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerMultiPercentageService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerMultiCheckboxService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _researchQuestionService.AddInitResearchQuestions(research.Id).ConfigureAwait(true);

                    Email.Send("PhD", research.Email, "PhD Accepted", _researchService.CreateAcceptMailTemplate(research, _jwtManager.GenerateToken(research), ranadomPassword, Request));
                    break;

                case ResearchStatusEnum.Pending:

                    Email.Send("PhD", research.Email, "PhD Pending", _researchService.CreatePendingMailTemplate(research.Name));
                    break;

                case ResearchStatusEnum.Rejected:

                    Email.Send("PhD", research.Email, "PhD Rejection", _researchService.CreateRejectedMailTemplate(research.Name));
                    break;
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
            return Ok(researchDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForGetDTO>>> Get()
        {
            List<ResearchForGetDTO> researchs = _mapper.Map<List<ResearchForGetDTO>>(await _researchRepository.GetAsync().ConfigureAwait(true));
            return Ok(researchs);
        }

        [HttpGet("results")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForResultsGetDTO>>> GetResults()
        {
            List<ResearchForResultsGetDTO> researchs = _mapper.Map<List<ResearchForResultsGetDTO>>(await _researchRepository.GetAsync().ConfigureAwait(true));
            return Ok(researchs);
        }

        [HttpGet("{status}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForGetDTO>>> Get(string status)
        {
            Enum.TryParse(status, out ResearchStatusEnum myStatus);
            List<ResearchForGetDTO> researchs = _mapper.Map<List<ResearchForGetDTO>>(await _researchRepository.GetAsync(myStatus).ConfigureAwait(true));
            return Ok(researchs);
        }

        [HttpGet("one/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                if (!await _researchRepository.IsExist((int)id).ConfigureAwait(true))
                    return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", (int)id)));

                Research research = await _researchRepository.GetAsync((int)id).ConfigureAwait(true);
                ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
                return Ok(researchDto);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

                Research research = await _researchRepository.GetAsync(Convert.ToInt32(researchId)).ConfigureAwait(true);
                ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
                return Ok(researchDto);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> Delete(int id)
        {
            if (!await _researchRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", id)));

            Research research = await _researchRepository.GetAsync(id).ConfigureAwait(true);

            _researchRepository.Remove(research);

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
            return Ok(researchDto);
        }

        [HttpPost("upload")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Upload([FromForm] FileDTO model)
        {
            FileOperations.WriteFile($"uploadFiles", model.File);
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"Content/uploadFiles", model.File.FileName);
            FileInfo file = new FileInfo(path);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            int totalRows = workSheet.Dimension.Rows;

            SecurePassword.CreatePasswordHash("12341234", out byte[] passwordHash, out byte[] passwordSalt);

            for (int i = 5; i <= totalRows; i++)
            {
                try
                {
                    Research research = new Research
                    {
                        Code = Convert.ToInt32(workSheet.Cells[i, 1].Value),
                        Name = workSheet.Cells[i, 2].Value.ToString().Trim(),
                        Program = workSheet.Cells[i, 3].Value.ToString().Trim(),
                        Field = workSheet.Cells[i, 4].Value.ToString().Trim(),
                        Entity = workSheet.Cells[i, 6].Value.ToString().Trim(),
                        Address = workSheet.Cells[i, 7].Value.ToString().Trim(),
                        Email = workSheet.Cells[i, 8].Value.ToString().Trim(),
                        FullTimeEmployeesNumber = Convert.ToInt32(workSheet.Cells[i, 9].Value),
                        PartTimeEmployeesNumber = Convert.ToInt32(workSheet.Cells[i, 10].Value),
                        PhDResearchersNumber = Convert.ToInt32(workSheet.Cells[i, 11].Value),
                        MastersResearchersNumber = Convert.ToInt32(workSheet.Cells[i, 12].Value),
                        BachelorsResearchersNumber = Convert.ToInt32(workSheet.Cells[i, 13].Value),
                        TechniciansNumber = Convert.ToInt32(workSheet.Cells[i, 14].Value),
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
                    };
                    await _researchRepository.AddAsync(research).ConfigureAwait(true);
                }
                catch (Exception ex)
                {
                    throw new Exception($"row {i}");
                }
            }


            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok();
        }

        [HttpPatch("all/status")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> InitQuestions()
        {
            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);

            foreach (var research in researchs)
            {
                research.Status = ResearchStatusEnum.Accepted;
                _researchRepository.Edit(research);
                await _answerRadioService.AddInitAnswer(research.Id).ConfigureAwait(true);
                await _answerCheckboxService.AddInitAnswer(research.Id).ConfigureAwait(true);
                await _answerNumberService.AddInitAnswer(research.Id).ConfigureAwait(true);
                await _answerMultiAmountService.AddInitAnswer(research.Id).ConfigureAwait(true);
                await _answerMultiPercentageService.AddInitAnswer(research.Id).ConfigureAwait(true);
                await _answerMultiCheckboxService.AddInitAnswer(research.Id).ConfigureAwait(true);
                await _researchQuestionService.AddInitResearchQuestions(research.Id).ConfigureAwait(true);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok();
        }

        [HttpPatch("updateCheckboxes")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateCheckboxes()
        {
            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);
            var checkboxes = await _answerCheckboxRepository.GetAsync().ConfigureAwait(true);

            foreach (var research in researchs)
            {
                var answersQ8 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 8).ToList();
                research.Q8 = answersQ8.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ8.Count();

                var answersQ9 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 9).ToList();
                research.Q9 = answersQ9.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ9.Count();

                var answersQ10 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 10).ToList();
                research.Q10 = answersQ10.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ10.Count();

                var answersQ12 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 12).ToList();
                research.Q12 = answersQ12.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ12.Count();

                var answersQ13 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 13).ToList();
                research.Q13 = answersQ13.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ13.Count();

                var answersQ16 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 16).ToList();
                research.Q16 = answersQ16.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ16.Count();

                var answersQ17 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 17).ToList();
                research.Q17 = answersQ17.Sum(s => Convert.ToDecimal(s.Checked)) / answersQ17.Count();

                _researchRepository.Edit(research);
            }
            await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch("updateMultiPercentages")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateMultiPercentages()
        {
            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);
            var percentages = await _answerMultiPercentageRepository.GetAsync().ConfigureAwait(true);

            foreach (var research in researchs)
            {
                var answersQ14 = percentages.Where(w => w.ResearchId == research.Id && w.QuestionId == 14).ToList();
                research.Q14 = (answersQ14.Sum(s => s.Number1) + answersQ14.Sum(s => s.Number2)) / (answersQ14.Count() * 2);
                _researchRepository.Edit(research);
            }
            await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch("updateMultiCheckboxes")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateMultiCheckboxes()
        {
            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);
            var checkboxes = await _answerMultiCheckboxRepository.GetAsync().ConfigureAwait(true);

            foreach (var research in researchs)
            {
                var answersQ15 = checkboxes.Where(w => w.ResearchId == research.Id && w.QuestionId == 15).ToList();
                research.Q15 = (answersQ15.Sum(s => Convert.ToDecimal(s.Checked1)) + answersQ15.Sum(s => Convert.ToDecimal(s.Checked2))) / (answersQ15.Count() * 2);
                _researchRepository.Edit(research);
            }
            await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return Ok();
        }

        [HttpPatch("updateResults")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateResults()
        {
            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);

            foreach (var research in researchs)
            {
                research.First = (research.Q8 + research.Q9 + research.Q10 + research.Q14 + research.Q15) / 5;
                research.Second = (research.Q12 + research.Q13) / 2;
                research.Third = (research.Q17 + research.Q16) / 2;
                research.Final = (research.Q8 + research.Q9 + research.Q10 + research.Q12 + research.Q13 + research.Q14 + research.Q15 + research.Q16 + research.Q17) / 9;
                _researchRepository.Edit(research);
            }
            await _unitOfWork.CompleteAsync().ConfigureAwait(false);
            return Ok();
        }
    }
}