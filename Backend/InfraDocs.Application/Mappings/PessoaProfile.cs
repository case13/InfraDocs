using AutoMapper;
using InfraDocs.Domain.Entities;
using InfraDocs.Shared.Dtos.Pessoa;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InfraDocs.Application.Mappings
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<CreatePessoaDto, Pessoa>();

            CreateMap<UpdatePessoaDto, Pessoa>();

            CreateMap<Pessoa, ReadPessoaDto>();
        }
    }
}
