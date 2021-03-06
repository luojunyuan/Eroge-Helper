﻿using System.Threading.Tasks;
using ErogeHelper.Model.Entity.Payload;
using ErogeHelper.Model.Entity.Response;
using Refit;

namespace ErogeHelper.Model.Service.Interface
{
    public interface IEhServerApiService
    {
        [Get("/v1/Game/Setting?md5={md5}")]
        Task<ApiResponse<GameSettingResponse>> GetGameSetting(string md5);

        [Post("/v1/Game/Setting")]
        Task<ApiResponse<SubmitSettingResponse>> SendGameSetting(GameSettingPayload payload);
    }
}