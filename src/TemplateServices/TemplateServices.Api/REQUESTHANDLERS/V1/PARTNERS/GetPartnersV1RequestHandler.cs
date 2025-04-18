using AutoMapper;
using System.Diagnostics;
using $safeprojectname$.RequestHandlers.Base;
using $safeprojectname$.DTO.V1.Partners;
using $ext_safeprojectname$Services.Common.Services.PartnersService;


namespace $safeprojectname$.RequestHandlers.V1.Partners;


public class GetPartnersV1RequestHandler : RequestHandlerBase<IPartnersService, GetPartnersRequest, GetPartnersResponse>
{
    #region Конструкторы

    public GetPartnersV1RequestHandler(IPartnersService partnersService, ILogger<GetPartnersV1RequestHandler> logger, IMapper mapper, ActivitySource activitySource)
                                                : base(partnersService, logger, mapper, activitySource)
    { }

    #endregion Конструкторы


    #region Методы
    
    protected override async Task<GetPartnersResponse> HandleCore(GetPartnersRequest request, CancellationToken cancellationToken)
    {
        var result = await BaseService
            .GetPartnersInfo(partnersIdsFilter: request.Filters?.PartnersIds)
            .ConfigureAwait(false);

        return new GetPartnersResponse() { Partners = result };
    }

    #endregion Методы
}
