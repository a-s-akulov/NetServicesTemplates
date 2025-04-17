using KatServices.Common.Services.PartnersService;


namespace $safeprojectname$.DTO.V1.Partners;


public class GetPartnersResponse
{
    /// <summary>
    /// Список найденных магазинов
    /// </summary>
    public ICollection<PartnerOrsInfo> Partners { get; set; } = [];
}
