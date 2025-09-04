using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Dtos;
using NotificationService.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly INotificationTemplateService _template;
        private readonly ILogger<AdminController> _logger;
        private readonly IValidator<AddTemplateRequest> _validator;

        private readonly IMapper _mapper;
        public AdminController(INotificationTemplateService templateService, ILogger<AdminController> logger, IMapper mapper, IValidator<AddTemplateRequest> validator)
        {
            _template = templateService;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
        }


        // GET: api/<AdminController>
        [HttpGet("GetList")]
        public async Task<List<TemplateResponseDto>> GetList()
        {
            var res = await _template.GetList();
            var list = _mapper.Map<List<TemplateResponseDto>>(res);
            return list;
        }

        // GET api/<AdminController>/5
        [HttpGet("Get/{id}")]
        public async Task<TemplateResponseDto> Get(Guid id)
        {
            var template = await _template.Get(id);
            var templateDto = _mapper.Map<TemplateResponseDto>(template);
            return templateDto;
        }

        // POST api/<AdminController>
        [HttpPost("Add")]
        public async Task<IActionResult> Post(AddTemplateRequest templateCreateRequest)
        {

            var result = await _validator.ValidateAsync(templateCreateRequest);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return BadRequest(ModelState);
            }

            var create = _mapper.Map<TemplateDto>(templateCreateRequest);
            create.CreatedDate = DateTime.Now;
            await _template.Add(create);
            return Ok();
        }

        // PUT api/<AdminController>/5
        [HttpPut("Update/{id}")]
        public void Put(Guid id, AddTemplateRequest value)
        {
            var updateModel = new TemplateDto();
            _template.Update(id, updateModel);

        }

        // DELETE api/<AdminController>/5
        [HttpDelete("Delete/{id}")]
        public void Delete(Guid id)
        {
            _template.Delete(id);
        }

        // DELETE api/<AdminController>/setenabled/5        
        [HttpGet("SetEnabled/{id}")]
        public void SetEnabled(Guid id)
        {
            _template.Delete(id);
        }

    }
}
