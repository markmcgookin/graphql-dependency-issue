using System;
using System.Collections.Generic;

namespace graphql_dependency_issue.model
{
    public class Organisation
    {
        public Organisation(string createdBy, DateTime created)
        {
            Employers = new List<Employer>();
        }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        
        public List<Employer> Employers { get; set; }
    }
}