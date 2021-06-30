using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class StatusShopResponseModel
    {
        public List<StatusShopModel> statusShops{ get; set; }
        public List<StatusShopModel> failStatusShops{ get; set; }
        public List<ErrorModel> errors { get; set; }
    }
}
