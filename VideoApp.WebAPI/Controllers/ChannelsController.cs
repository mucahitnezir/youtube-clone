using System;
using Microsoft.AspNetCore.Mvc;
using VideoApp.Business.Abstract;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelsController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _channelService.GetList();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var channel = _channelService.GetById(id);
            return Ok(channel);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ChannelDto channelDto)
        {
            var result = _channelService.Add(channelDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ChannelUpdateDto channelUpdateDto)
        {
            var result = _channelService.Update(id, channelUpdateDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message); 
        }
    }
}