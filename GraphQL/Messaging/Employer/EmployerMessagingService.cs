using graphql_dependency_issue.model;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace graphql_dependency_issue.graphql
{
    public class EmployerMessagingService
    {
        private readonly ISubject<EmployerAddedMessage> MessageStream = new ReplaySubject<EmployerAddedMessage>(1);

        public EmployerAddedMessage AddEmployerAddedMessage(Employer employer)
        {
            var message = new EmployerAddedMessage
            {
                Name = employer.Name
            };

            MessageStream.OnNext(message);

            return message;
        }

        public IObservable<EmployerAddedMessage> GetMessages()
        {
            return MessageStream.AsObservable();
        }
    }
}
