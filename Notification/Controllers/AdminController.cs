using AutoMapper;
using Confluent.Kafka;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Dtos.Template;
using NotificationService.Extensions;

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
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<List<TemplateResponse>> GetList()
        {
            var res = await _template.GetList();
            var list = _mapper.Map<List<TemplateResponse>>(res);
            return list;
        }

        // GET api/<AdminController>/5
        [HttpGet("Get/{id}")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TemplateResponse>> Get(Guid id)
        {
            try
            {
                var template = await _template.Get(id);
                var templateDto = _mapper.Map<TemplateResponse>(template);
                return templateDto;
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST api/<AdminController>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add(AddTemplateRequest templateCreateRequest)
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
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(Guid id, AddTemplateRequest value)
        {
            try
            {
                var updateModel = _mapper.Map<TemplateDto>(value);
                await _template.Update(id, updateModel);
                return Ok();
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _template.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<AdminController>/setenabled/5        
        [HttpGet("SetEnabled/{id}")]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SetEnabled(Guid id)
        {
            try
            {
                await _template.SetEnabled(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
