using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Micro.CommandsService.Data;
using Micro.CommandsService.Dtos;
using Micro.CommandsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Micro.CommandsService.Controllers
{
    [Route("api/cmd/[controller]")] //"cmd" refers to this is CommandsService's PlatformsController.
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting platforms from CommandsService");
            var platformItems = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems)) ;
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST at Commands Service");

            return Ok("Inobund test of from Platforms Controller");
        }
    }
}