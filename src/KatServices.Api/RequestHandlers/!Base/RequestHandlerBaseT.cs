using AutoMapper;
using MediatR;
using System.Diagnostics;


namespace KatServices.Api.RequestHandlers.Base;


public abstract class RequestHandlerBase<TBaseService, TRequest, TResponse> : RequestHandlerBase, IRequestHandler<HandlerRequest<TRequest, ApiResponse<TResponse>>, ApiResponse<TResponse>>
                                                                where TRequest : ApiRequest
{
    #region Конструкторы

    public RequestHandlerBase(TBaseService baseService, ILogger logger, IMapper mapper, ActivitySource activitySource) : base(logger, mapper, activitySource)
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

    public async Task<ApiResponse<TResponse>> Handle(HandlerRequest<TRequest, ApiResponse<TResponse>> request, CancellationToken cancellationToken)
    {
        var result = await HandleProtectedApiResponse(request.First, cancellationToken)
            .ConfigureAwait(false);

        return result;
    }

    protected virtual async Task<ApiResponse<TResponse>> HandleProtectedApiResponse(TRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = ValidateRequest(request);
            if (validationResult != null)
                return validationResult;

            var result = await HandleCore(request, cancellationToken).ConfigureAwait(false);
            var response = CreateResponse(result);

            return response;
        }
        catch (Exception ex)
        {
            var handleExceptionResult = HandleException(request, ex);
            if (handleExceptionResult == null)
                throw;

            return handleExceptionResult;
        }
    }

    protected abstract Task<TResponse> HandleCore(TRequest request, CancellationToken cancellationToken);


    protected virtual ApiResponse<TResponse>? ValidateRequest(TRequest request)
    {
        return null;
    }

    protected virtual ApiResponse<TResponse> CreateResponse(TResponse response)
    {
        return new ApiResponse<TResponse>(response);
    }

    protected virtual ApiResponse<TResponse>? HandleException(TRequest request, Exception exception)
    {
        return null;
    }

    #endregion Методы
}
