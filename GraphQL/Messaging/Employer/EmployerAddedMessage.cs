using System;

namespace graphql_dependency_issue.graphql
{
    public class EmployerAddedMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AddedBy { get; set; }
    }
}