﻿using FDSA.Domain.HUB;

namespace FDSA.Application.Interfaces.WebServices.Shared
{
    public interface IProviderService
    {
        Task<HubResponse> SearchDataAsync(HubRequest request);
    }
}
