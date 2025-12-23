using AutoMapper;
using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao;

namespace InfraDocs.Application.Mappings
{
    public class RequerimentoSuspensaoRestricaoProfile : Profile
    {
        public RequerimentoSuspensaoRestricaoProfile()
        {
            CreateMap<CreateRequerimentoSuspensaoRestricaoDto, RequerimentoSuspensaoRestricao>();

            CreateMap<UpdateRequerimentoSuspensaoRestricaoDto, RequerimentoSuspensaoRestricao>();

            CreateMap<RequerimentoSuspensaoRestricao, ReadRequerimentoSuspensaoRestricaoDto>();
        }
    }
}
