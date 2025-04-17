using AutoMapper;
using System.Diagnostics;
using $safeprojectname$.RequestHandlers.Base;
using $safeprojectname$.DTO.V1.MyAwesomeProducts;
using KatServices.Common.Services.KatStorageService;


namespace $safeprojectname$.RequestHandlers.V1.MyAwesomeProducts;


public class GetProductsV1RequestHandler : RequestHandlerBase<IKatStorageService, GetProductsRequest, GetProductsResponse>
{
    #region Конструкторы

    public GetProductsV1RequestHandler(IKatStorageService storageService, ILogger<GetProductsV1RequestHandler> logger, IMapper mapper, ActivitySource activitySource)
                                                : base(storageService, logger, mapper, activitySource)
    {
    }

    #endregion Конструкторы


    #region Методы

    protected override async Task<GetProductsResponse> HandleCore(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var result = await BaseService.GetMyAwesomeProducts(
                idsFilter: request.Filters?.Ids,
                productTypesFilter: request.Filters?.ProductTypes,
                includeReferences: true, cancellationToken: cancellationToken
            )
            .ConfigureAwait(false);

        return new() { Products = result };
    }

    #endregion Методы
}
