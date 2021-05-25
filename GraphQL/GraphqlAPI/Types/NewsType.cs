using System;
using NewsProject.DAL;
using NewsProject.DAL.DTO;
using GraphQL.Types;
using MongoDB.Bson;

namespace NewsProject.GraphqlAPI.Types
{
    public class NewsType : ObjectGraphType<NewsDTO>
    {
        public NewsType()
        {
            Field(x => x.Id );
            Field(x => x.Title);
            Field(x => x.Url);
            Field(x => x.Author, nullable: true);
            Field(x => x.DateOfPublication, nullable: true);
            Field(x => x.Description);
            Field(x => x.Likes);
            Field("likesCount", x => x.Likes != null ? x.Likes.Count : 0);
            Field(x => x.Keywords);}
    }
}
