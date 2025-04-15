using KatServices.Common.Services.PartnersService;


namespace KatServices.Api.DTO.V1.Partners;


public class GetPartnersResponse
{
    /// <summary>
    /// Список найденных магазинов
    /// </summary>
    public ICollection<PartnerOrsInfo> Partners { get; set; } = [];
}
