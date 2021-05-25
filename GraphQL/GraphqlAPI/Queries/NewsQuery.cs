using System;
using NewsProject.DAL.Repo.NewsRepo;
using GraphQL.Types;
using NewsProject.GraphqlAPI.Types;

namespace NewsProject.GraphqlAPI.Queries
{
    public class NewsQuery : ObjectGraphType
    {
        public NewsQuery(INewsRepository newsRepository)
        {
            Field<ListGraphType<NewsType>>(
                "news",
                resolve: context => newsRepository.Get());

            Field<NewsType>(
               "newsById",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
               resolve: context =>
               {
                   var news = newsRepository.Get(context.GetArgument<string>("id"));
                   if (news == null)
                       throw new System.Exception("Invalid id");
                   return news;
               });
            Field<ListGraphType<NewsType>>(
                "newsByUser",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
                resolve: context =>
                {

                    var news = newsRepository.GetNewsByUser(context.GetArgument<string>("userId"));
                    return news;
                });
            Field<ListGraphType<NewsType>>(
                "GetNotReadsNews",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
               resolve: context =>
                {

                    var news = newsRepository.GetNotReadsNews(context.GetArgument<string>("userId"));
                    return news;
                });
        }
    }
}
