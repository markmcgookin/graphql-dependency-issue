using System;
using System.Linq;
using graphql_dependency_issue.model;
using GraphQL;
using GraphQL.Types;

namespace graphql_dependency_issue.graphql
{
    public class CoreQuery : ObjectGraphType
    {
        public CoreQuery(TempDBContext database)
        {
            Field<ListGraphType<OrganisationType>>(
                   "organisations",
                   resolve: context => database.Organisations()
               );

            Field<OrganisationType>(
                "organisation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = new Guid(context.GetArgument<string>("id"));
                    return database.Organisations();
                });

            Field<ListGraphType<EmployerType>>(
                "employers",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "organisationId" }),
                resolve: context =>
                {
                    var id = new Guid(context.GetArgument<string>("organisationId"));
                    return database.Employers().Where(x => x.OrganisationId == id);
                });
        }
    }
}