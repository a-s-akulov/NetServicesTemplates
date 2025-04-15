using AutoMapper;
using MediatR;
using System.Diagnostics;


namespace KatServices.Api.RequestHandlers.Base;


public abstract class RequestHandlerBasePaged<TBaseService, TRequest, TResponse> : RequestHandlerBase, IRequestHandler<HandlerRequest<TRequest, ApiPagedResponse<TResponse>>, ApiPagedResponse<TResponse>>
                                                                        where TRequest : ApiPagedRequest
                                                                        where TResponse : class
{
    #region Конструкторы

    public RequestHandlerBasePaged(TBaseService baseService, ILogger logger, IMapper mapper, ActivitySource activitySource) : base(logger, mapper, activitySource)
    {
        BaseService = baseService;
    }

    #endregion Конструкторы


    #region Свойства

    /// <summary>
    /// Базовый сервис обработчика
    /// </summary>
    protected TBaseService BaseService { get; }

    #endregion Свойства


    #region Методы

    public async Task<ApiPagedResponse<TResponse>> Handle(HandlerRequest<TRequest, ApiPagedResponse<TResponse>> request, CancellationToken cancellationToken)
    {
        var result = await HandleProtectedApiResponse(request.First, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    protected virtual async Task<ApiPagedResponse<TResponse>> HandleProtectedApiResponse(TRequest request, CancellationToken cancellationToken)
    {
        return new ApiPagedResponse<TResponse>(await HandleProtected(request, cancellationToken).ConfigureAwait(false));
    }

    protected abstract Task<TResponse> HandleProtected(TRequest request, CancellationToken cancellationToken);

    #endregion Методы
}
