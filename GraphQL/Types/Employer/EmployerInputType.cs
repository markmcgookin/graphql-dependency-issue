using graphql_dependency_issue.model;
using GraphQL.Types;

namespace graphql_dependency_issue.graphql
{
    public class EmployerInputType : InputObjectGraphType<Employer>
    {
        public EmployerInputType()
        {
            Name = "employerInput";
            Field(x => x.Name).Description("The name of the Employer");
        }
    }
}