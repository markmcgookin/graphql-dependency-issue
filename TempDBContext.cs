using System;
using System.Collections.Generic;

namespace graphql_dependency_issue.model
{
    public class TempDBContext
    {
        public List<Organisation> Organisations()
        {
            return new List<Organisation>() {
                new Organisation("TestUser", DateTime.Now) { Name = "Some company" }
            };
        }

        public List<Employer> Employers()
        {
            return new List<Employer>();
        }
    }
}