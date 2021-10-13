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
    [Route("api/cmd/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId)
        {
            Console.WriteLine($"--> Getting commands for platform: {platformId} ");
            if (_repository.PlatformExists(platformId))
            {
                var commandsItem = _repository.GetCommandsForPlatform(platformId);
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandsItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
        public ActionResult<CommandReadDto> GetCommandForPlatform(int platformId, int commandId)
        {
            Console.WriteLine($"--> Getting command for platform: {platformId} ");
            if (_repository.PlatformExists(platformId))
            {
                var commandItem = _repository.GetCommand(platformId, commandId);
                if (commandItem == null)
                    return NotFound();
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto command)
        {
            Console.WriteLine($"--> Creating command for platform: {platformId} ");
            if (_repository.PlatformExists(platformId))
            {
                var commandModel = _mapper.Map<Command>(command);
                _repository.CreateCommand(platformId, commandModel);
                var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
                return CreatedAtRoute(nameof(CreateCommandForPlatform), new { Id = commandReadDto.Id, PlatformID = platformId }, commandReadDto);
            }
            else
            {
                return NotFound();
            }
        }
    }
}