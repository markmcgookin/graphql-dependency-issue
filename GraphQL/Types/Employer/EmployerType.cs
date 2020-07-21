using graphql_dependency_issue.model;
using GraphQL.Types;

namespace graphql_dependency_issue.graphql
{
    public class EmployerType : ObjectGraphType<Employer>
    {
        public EmployerType()
        {
            Name = "employer";
            Field(x => x.Name).Description("The name of the Employer");
        }
    }
}