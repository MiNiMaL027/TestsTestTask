using AutoMapper;
using Domain.CreateModels;
using Domain.Models;
using Domain.ViewModel;

namespace Services.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateProjection<Question, ViewQuestion>().ForMember(x => x.QuestionText, x => x.MapFrom(x => x.Name));

            CreateProjection<Test, ViewTest>();

            CreateProjection<Answer, ViewAnswer>().ForMember(x => x.AnswerText, x => x.MapFrom(x => x.Name));

            CreateMap<CreateTestModel, Test>().ReverseMap();

            CreateMap<CreateQuestionModel, Question>().ForMember(x => x.Name, x => x.MapFrom(x => x.QuestionText)).ReverseMap();

            CreateMap<CreateAnswerModel, Answer>().ForMember(x => x.Name, x => x.MapFrom(x => x.AnswerText)).ReverseMap();

            CreateMap<ViewTest, Test>().ReverseMap();

            CreateMap<ViewQuestion, Question>().ForMember(x => x.Name, x => x.MapFrom(x => x.QuestionText)).ReverseMap();

            CreateMap<ViewAnswer, Answer>().ForMember(x => x.Name, x => x.MapFrom(x => x.AnswerText)).ReverseMap();
        }
    }
}
