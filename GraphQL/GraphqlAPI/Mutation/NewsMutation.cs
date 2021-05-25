using System;
using NewsProject.DAL.Repo.NewsRepo;
using GraphQL.Types;
using NewsProject.GraphqlAPI.Types;

namespace NewsProject.GraphqlAPI.Mutation
{
    public class NewsMutation : ObjectGraphType
    {
        public NewsMutation(INewsRepository newsRepository)
        {
            Name = "NewsMutation";
            Field<NewsType>(
             "addLikes",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "newsID" }, new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userID" }),
             resolve: context =>
             {
                 return newsRepository.AddLikes(context.GetArgument<string>("newsID"), context.GetArgument<string>("userID"));

             });
            Field<NewsType>(
             "removeLikes",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "newsID" }, new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userID" }),
             resolve: context =>
             {
                 return newsRepository.RemoveLikes(context.GetArgument<string>("newsID"), context.GetArgument<string>("userID"));

             });

            Field<NewsType>(
 "readNews",
 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "newsID" }, new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userID" }),
 resolve: context =>
 {
     return newsRepository.ReadNews(context.GetArgument<string>("newsID"), context.GetArgument<string>("userID"));

 });

        }
    }
}
