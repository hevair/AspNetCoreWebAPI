using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile: Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
            .ForMember(
                alunoDto => alunoDto.Nome,
                aluno =>  aluno.MapFrom(src => $"{src.Nome} {src.SobreNome}")
            )
            .ForMember(
                alunoDto => alunoDto.Idade,
                aluno =>  aluno.MapFrom(src => src.DataNasc.GetCurrentAge())
            );

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDTO>().ReverseMap();

            CreateMap<Professor, ProfessorDTO>()
            .ForMember(
                professorDTO => professorDTO.Nome,
                professor => professor.MapFrom(src => $"{src.Nome} {src.SobreNome}")
            );

            CreateMap<ProfessorDTO, Professor>();
            CreateMap<Professor, ProfessorRegistrarDTO>().ReverseMap();
        }
    }
}