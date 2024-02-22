using AutoMapper;
using ExceptionArticle.Config;

namespace ExceptionArticle.Config;

internal static class AutoMapperConfiguration
{
    public static MapperConfiguration Configure()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ExceptionArticleAutomapperProfile>();
        });
    }
}