using AutoMapper;
using Control_Escolar.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_Escolar
{
    public class MappingProfile
    {
        public static MapperConfiguration InitialzeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                // Domain to API ViewModels
                cfg.CreateMap<Personal, PersonalDto>()
                    .ForMember(dest => dest.PersonalTipo, opt =>
                    opt.MapFrom(src => new PersonalTipoDto
                    {
                        IdPersonalTipo = src.IdPersonalTipo,
                        PersonalTipoDescripcion = src.PersonalTipos.PersonalTipoDescripcion
                    }))
                    .ForMember(dest => dest.PersonalSueldo, opt => 
                    opt.MapFrom(src => src.PersonalSueldos.Sueldo));

                cfg.CreateMap<PersonalTipos, PersonalTipoBaseDto>();                    

                // API ViewModels to Domain
                cfg.CreateMap<PersonalDto, Personal>()
                    .ForMember(p => p.IdPersonal, opt => opt.Ignore())
                    .ForMember(dest => dest.IdPersonalTipo, opt =>
                    opt.MapFrom(src => src.PersonalTipo.IdPersonalTipo));
                
                cfg.CreateMap<PersonalUpdateDto, Personal>()
                    .ForMember(dest => dest.IdPersonalTipo, opt =>
                    opt.MapFrom(src => src.PersonalTipo.IdPersonalTipo));

                cfg.CreateMap<PersonalTipoBaseDto, PersonalTipos>()
                    .ForMember(p => p.IdPersonalTipo, opt => opt.Ignore());

                cfg.CreateMap<PersonalTipoBaseUpdateDto, PersonalTipos>();

            });

            return config;
        }
    }
}