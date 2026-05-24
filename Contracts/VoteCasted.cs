using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public record VoteCasted
    (
        string TargetId,
        string TargetType,
        int VoteValue
    );
}
