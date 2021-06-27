namespace CarRentalSystem.Common.Messages
{
    using CarRentalSystem.Common.Data;
    using Hangfire;
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager recuringJobManager;
        private readonly IBus publisher;
        private readonly DbContext context;

        public MessagesHostedService(IRecurringJobManager recuringJobManager, IBus publisher, DbContext context)
        {
            this.recuringJobManager = recuringJobManager;
            this.publisher = publisher;
            this.context = context;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.recuringJobManager.AddOrUpdate(
                nameof(MessagesHostedService),
                () => this.ProcessPendingMessages(),
                "*/5 * * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public void ProcessPendingMessages()
        {
            var messages = this.context
                .Set<Message>()
                .Where(m => !m.Published)
                .OrderBy(m => m.Id)
                .ToList();

            foreach (var message in messages)
            {
                this.publisher.Publish(message.Data, message.Type);

                message.MarkAsPublished();

                this.context.SaveChanges();
            }
        }
    }
}
