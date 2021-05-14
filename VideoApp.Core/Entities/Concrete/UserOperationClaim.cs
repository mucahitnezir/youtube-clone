using System;

namespace VideoApp.Core.Entities.Concrete
{
    public class UserOperationClaim : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}