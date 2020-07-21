using GraphQL.Types;

namespace graphql_dependency_issue.graphql
{
    public class EmployerAddedMessageType : ObjectGraphType<EmployerAddedMessage>
    {
        public EmployerAddedMessageType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of the Employer");
            Field(t => t.Name);
            Field(t => t.AddedBy);
        }
    }
}