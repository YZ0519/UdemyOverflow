using Contracts;
using Marten;
using Wolverine.Attributes;

namespace StatsService.MessageHandler
{
    [Transactional]
    public class QuestionCreatedHandler
    {
        public static async Task Handle(QuestionCreated message, IDocumentSession session, CancellationToken ct)
        {
            session.Events.StartStream(message.QuestionId, message);

            await session.SaveChangesAsync(ct);
        }
    }
}
