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
        private readonly IValidator<AddTemplateDto> _validator;

        private readonly IMapper _mapper;
        public AdminController(INotificationTemplateService templateService, ILogger<AdminController> logger, IMapper mapper, IValidator<AddTemplateDto> validator)
        {
            _template = templateService;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
        }


        // GET: api/<AdminController>
        [HttpGet]
        public  async Task<List<TemplateResponseDto>> GetList()
        {
            var res = await _template.GetList();
            var list = _mapper.Map<List<TemplateResponseDto>>(res);
            return list;
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<TemplateResponseDto> Get(Guid id)
        {
            var template = await _template.Get(id);
            var templateDto = _mapper.Map<TemplateResponseDto>(template);
            return templateDto;
        }

        // POST api/<AdminController>
        [HttpPost]
        public async Task<IActionResult> Post(AddTemplateDto templateCreateRequest)
        {

            var result = await _validator.ValidateAsync(templateCreateRequest);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return BadRequest(ModelState);
            }

            var create = _mapper.Map<TemplateDto>(templateCreateRequest);

            await _template.Add(create);
            return Ok();
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(Guid id,  AddTemplateDto value)
        {
            var updateModel = new TemplateDto();
            _template.Update(id, updateModel);

        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _template.Delete(id);
        }


    }
}
