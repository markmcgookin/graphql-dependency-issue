using System;
using GraphQL.Types;
using GraphQL.Utilities;

namespace graphql_dependency_issue.graphql
{
    public class CoreSchema : Schema
    {
        public CoreSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<CoreQuery>();
            Mutation = provider.GetRequiredService<CoreMutation>();
        }
    }
}
