using Contracts;
using Marten;
using Wolverine.Attributes;

namespace StatsService.MessageHandler
{
    [Transactional]
    public class UserReputationChangeHandler
    {
        public static async Task Handle(UserReputationChanged message, IDocumentSession session, CancellationToken ct)
        {
            session.Events.Append(message.UserId, message);
            await session.SaveChangesAsync();
        }
    }
}
