using System;
using System.Text.Json.Serialization;

namespace graphql_dependency_issue.model
{
    public class Employer
    {
        public Employer() : base() { }
        public Employer(string createdBy, DateTime created)
        {
        }

        public Guid OrganisationId { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public Organisation Organisation { get; set; }
    }
}