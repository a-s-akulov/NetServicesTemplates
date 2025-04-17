using AutoMapper;
using System.Diagnostics;
using $safeprojectname$.RequestHandlers.Base;
using $safeprojectname$.DTO.V1.Partners;
using KatServices.Common.Services.PartnersService;


namespace $safeprojectname$.RequestHandlers.V1.Partners;


public class GetPartnerV1RequestHandler : RequestHandlerBase<IPartnersService, GetPartnerRequest, GetPartnerResponse>
{
    #region Конструкторы

    public GetPartnerV1RequestHandler(IPartnersService partnersService, ILogger<GetPartnerV1RequestHandler> logger, IMapper mapper, ActivitySource activitySource)
                                                            : base(partnersService, logger, mapper, activitySource)
    { }

    #endregion Конструкторы


    #region Методы

    protected override async Task<GetPartnerResponse> HandleCore(GetPartnerRequest request, CancellationToken cancellationToken)
    {
        var result = await BaseService
            .GetPartnerInfo(request.PartnerId)
            .ConfigureAwait(false);

        return new GetPartnerResponse() { Partner = result };
    }

    #endregion Методы
}
