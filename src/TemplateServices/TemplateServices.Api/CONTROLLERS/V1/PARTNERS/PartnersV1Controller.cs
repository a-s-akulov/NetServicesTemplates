using MediatR;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Auth;
using $safeprojectname$.Controllers.Base;
using $safeprojectname$.DTO.V1.Partners;


namespace $safeprojectname$.Controllers.V1.Partners;


[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/partners")]
public partial class PartnersV1Controller : ControllerInAppBase
{
    #region Конструктор

    public PartnersV1Controller(ILogger<PartnersV1Controller> logger, IMediator mediator) : base(logger, mediator)
    { }

    #endregion Конструктор


    #region Методы

    [HttpGet]
    [Route("partners")]
    [ApiAuthorize(enAppAction.PartnersRead)]
    [ProducesDefaultResponseType(typeof(ApiResponse<GetPartnersResponse>))]
    [ProducesResponseType(typeof(ApiResponse<GetPartnersResponse>), StatusCodes.Status200OK)]
    public Task<ActionResult<ApiResponse<GetPartnersResponse>>> GetPartners([FromQuery] GetPartnersRequest request, CancellationToken cancellationToken = default) =>
        HandleRequest<GetPartnersRequest, ApiResponse<GetPartnersResponse>>(request, cancellationToken);


    [HttpGet]
    [Route("{id}")]
    [ApiAuthorize(enAppAction.PartnersRead)]
    [ProducesDefaultResponseType(typeof(ApiResponse<GetPartnerResponse>))]
    [ProducesResponseType(typeof(ApiResponse<GetPartnerResponse>), StatusCodes.Status200OK)]
    public Task<ActionResult<ApiResponse<GetPartnerResponse>>> GetPartner(int id, CancellationToken cancellationToken = default) =>
        HandleRequest<GetPartnerRequest, ApiResponse<GetPartnerResponse>>(new GetPartnerRequest() { PartnerId = id }, cancellationToken);

    #endregion Методы
}