﻿namespace Api.Config.Environments
{
    public static class Env
    {
        public static readonly Func<string, string> Get = (
            env) => Environment.GetEnvironmentVariable(env);
    }
}
