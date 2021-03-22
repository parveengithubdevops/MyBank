﻿using System;
using System.Runtime.Serialization;

namespace MyBank.Domain
{
    [DataContract]
    public class AccountOpeningRequest
    {
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public Guid ClientId { get; private set; }
        [DataMember]
        public AccountOpeningRequestStatus Status { get; private set; }
        [DataMember]
        public DateTime RequestedAt { get; private set; }

        public AccountOpeningRequest(Guid clientId)
        {
            this.Id = Guid.NewGuid();
            this.ClientId = clientId;
            this.Status = AccountOpeningRequestStatus.Initial;
            this.RequestedAt = DateTime.UtcNow;
        }

        public void Approve()
        {
            this.Status = AccountOpeningRequestStatus.Approved;
        }

        public void Decline()
        {
            this.Status = AccountOpeningRequestStatus.Decline;
        }
    }
}
