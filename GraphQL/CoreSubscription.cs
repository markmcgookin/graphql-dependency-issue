using GraphQL.Resolvers;
using GraphQL.Types;

namespace graphql_dependency_issue.graphql
{
    public class CoreSubscription: ObjectGraphType
    {
        public CoreSubscription(EmployerMessagingService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "employerAdded",
                Type = typeof(EmployerAddedMessageType),
                Resolver = new FuncFieldResolver<EmployerAddedMessage>(c => c.Source as EmployerAddedMessage),
                Subscriber = new EventStreamResolver<EmployerAddedMessage>(c => messageService.GetMessages())
            });
        }
    }
}
