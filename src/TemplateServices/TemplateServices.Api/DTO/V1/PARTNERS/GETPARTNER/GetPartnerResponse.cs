using KatServices.Common.Services.PartnersService;


namespace $safeprojectname$.DTO.V1.Partners;


public class GetPartnerResponse
{
    /// <summary>
    /// Найденный магазин
    /// </summary>
    public PartnerOrsInfo? Partner { get; set; }
}
