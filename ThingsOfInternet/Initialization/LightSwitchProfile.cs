using System;
using AutoMapper;
using ThingsOfInternet.Models;
using ThingsOfInternet.ViewModels;

namespace ThingsOfInternet.Initialization
{
    public class LightSwitchProfile : Profile
    {
        protected override void Configure()
        {
            // Set settings on Light Switch
            Mapper.CreateMap<ThingViewModel, SwitchConfig>();

            // Retrieve settings from Light Swtich
            Mapper.CreateMap<LightSwitchQuery, ThingViewModel>()
                .ForMember(dest => dest.IsToggled, opts => opts.MapFrom(x => x.CurrentSwitchState));
        }
    }
}

