using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class StatusShopResponseModel
    {
        public List<StatusShopModel> statusShopModels { get; set; }
        public List<StatusShopModel> failStatusShopModels { get; set; }
    }
}
