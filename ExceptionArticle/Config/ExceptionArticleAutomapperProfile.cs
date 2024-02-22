using AutoMapper;
using ExceptionArticle.Models;
using ExceptionArticle.Models.Contracts;

namespace ExceptionArticle.Config;

public class ExceptionArticleAutomapperProfile : Profile
{
    public ExceptionArticleAutomapperProfile()
    {
        CreateMap<CreateYourEntityRequest, YourEntity>()
            .ForMember(d => d.Id, opt => opt.Ignore());

        CreateMap<YourEntity, YourEntityResponse>();
    }
}