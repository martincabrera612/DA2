﻿namespace Domain
{
    public class Session
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
