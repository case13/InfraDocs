using AutoMapper;
using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.Application.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            // Entity -> ReadDto
            CreateMap<Usuario, ReadUsuarioDto>();

            // CreateDto -> Entity
            CreateMap<CreateUsuarioDto, Usuario>();

            // UpdateDto -> Entity
            CreateMap<UpdateUsuarioDto, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrganizacaoId, opt => opt.Ignore());
        }
    }
}
