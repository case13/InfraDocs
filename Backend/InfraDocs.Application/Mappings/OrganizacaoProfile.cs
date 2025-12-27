using AutoMapper;
using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Dtos.Organizacao;

namespace InfraDocs.Application.Mapping
{
    public class OrganizacaoProfile : Profile
    {
        public OrganizacaoProfile()
        {
            // Entity -> ReadDto
            CreateMap<Organizacao, ReadOrganizacaoDto>();

            // CreateDto -> Entity
            CreateMap<CreateOrganizacaoDto, Organizacao>();

            // UpdateDto -> Entity
            CreateMap<UpdateOrganizacaoDto, Organizacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
