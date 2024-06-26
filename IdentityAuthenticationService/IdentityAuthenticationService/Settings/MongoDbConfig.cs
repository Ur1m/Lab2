﻿using System;

namespace IdentityAuthenticationService.Settings
{
    public class MongoDbConfig
    {
        public string Name { get; init; }
        public string Host { get; init; }
        public int Port { get; init; }
        public string ConnectionString => $"mongodb+srv://{Host}:{Port}";
    }
}
