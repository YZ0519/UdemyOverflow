using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public record UserReputationChanged
    (
        string UserId,
        int Delta,
        ReputationReason Reason,
        string ActorUserId,
        DateTime Occured
    );
}
