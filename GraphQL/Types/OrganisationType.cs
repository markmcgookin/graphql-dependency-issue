using graphql_dependency_issue.model;
using GraphQL.Types;

namespace graphql_dependency_issue.graphql
{
    public class OrganisationType : ObjectGraphType<Organisation>
    {
        public OrganisationType()
        {
            Name = "Organisation";
            Field(x => x.Name).Description("The name of the Organisation");
            Field(x => x.Employers, type: typeof(ListGraphType<EmployerType>)).Description("Organisation's Employers");
        }
    }
}