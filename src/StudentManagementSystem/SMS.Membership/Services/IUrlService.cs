﻿namespace SMS.Membership.Services
{
    public interface IUrlService
    {
        string GenerateAbsoluteUrl(string controller, string action, object parameters);
    }
}