using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;

        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDto>>> GetPlatforms([FromQuery] int? skip = null, [FromQuery] int? take = null)
        {
            Console.WriteLine("--> Getting Platforms from CommandService");

            var platformItems = await _repository.GetAllPlatformsAsync(skip, take);
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }
        
        [HttpPost]
        public ActionResult TestInboundConnection() 
        {
            Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test ok from Platforms Controller");
        }     
    }
}