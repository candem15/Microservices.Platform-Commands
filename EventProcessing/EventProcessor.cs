using System;
using System.Text.Json;
using AutoMapper;
using Micro.CommandsService.Data;
using Micro.CommandsService.Dtos;
using Micro.CommandsService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType=DetermineEvent(message);

            switch(eventType)
            {
                case EventType.PlatformPublished:
                    addPlatform(message);
                    break;
                default:
                    break;
            }
        }
        private EventType DetermineEvent(string notification)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notification);

            switch(eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform Published Event dedected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Event type could not determined");
                    return EventType.Undetermined;
            }
        }
        private void addPlatform(string platformPublishedMessage)
        {
            using(var scope=_scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                var platformPublished = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

                try
                {
                     var platform = _mapper.Map<Platform>(platformPublished);

                     if(!repo.ExternalPlatformExists(platform.ExternalId))
                     {
                         Console.WriteLine("--> Platform added");
                         repo.CreatePlatform(platform);
                     }
                     else
                     {
                         Console.WriteLine("--> Platform already exists");
                     }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Platform to DB could not added: {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}