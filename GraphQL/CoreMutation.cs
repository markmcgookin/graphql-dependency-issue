using graphql_dependency_issue.model;
using GraphQL.Types;
using System;
using GraphQL;

namespace graphql_dependency_issue.graphql
{
    public class CoreMutation : ObjectGraphType
    {
        public CoreMutation(TempDBContext database, 
                            EmployerMessagingService employerMessageService)
        {
            FieldAsync<EmployerType>(
                "createEmployer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployerInputType>> { Name = "employer" }),
                resolve: async context =>   
                {
                    var employer = context.GetArgument<Employer>("employer");
                    database.Employers().Add(employer);
                    employerMessageService.AddEmployerAddedMessage(employer);
                    
                    return employer;
                });
        }
    }
}
