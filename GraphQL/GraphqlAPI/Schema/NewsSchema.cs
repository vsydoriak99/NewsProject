using System;
using GraphQL;
using NewsProject.GraphqlAPI.Mutation;
using NewsProject.GraphqlAPI.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace NewsProject.GraphqlAPI.Schema
{
    public class NewsSchema : GraphQL.Types.Schema
    {
        public NewsSchema(IDependencyResolver serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.Resolve<NewsQuery>();
            Mutation = serviceProvider.Resolve<NewsMutation>();
        }
    }
}
