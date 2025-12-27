using AutoMapper;
using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao;

namespace InfraDocs.Application.Mapping
{
    public class RequerimentoSuspensaoRestricaoProfile : Profile
    {
        public RequerimentoSuspensaoRestricaoProfile()
        {
            // Entity -> ReadDto
            CreateMap<RequerimentoSuspensaoRestricao, ReadRequerimentoSuspensaoRestricaoDto>();

            // CreateDto -> Entity
            CreateMap<CreateRequerimentoSuspensaoRestricaoDto, RequerimentoSuspensaoRestricao>();

            // UpdateDto -> Entity
            CreateMap<UpdateRequerimentoSuspensaoRestricaoDto, RequerimentoSuspensaoRestricao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrganizacaoId, opt => opt.Ignore());
        }
    }
}
