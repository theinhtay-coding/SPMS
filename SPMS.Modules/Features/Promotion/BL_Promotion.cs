using SPMS.Models.Promotion;

namespace SPMS.Modules.Features.Promotion;

public class BL_Promotion
{
    private readonly DA_Promotion _daPromotion;

    public BL_Promotion(DA_Promotion daPromotion)
    {
        _daPromotion = daPromotion;
    }

    public PromotionListResponseModel GetPromotinos()
    {
        var lstPromotion = _daPromotion.GetPromotions();
        return lstPromotion;
    }

    public PromotionResponseModel GetPromotionById(int id)
    {
        var respModel = _daPromotion.GetPromotionById(id);
        return respModel;
    }

    public PromotionResponseModel CreatePromotion(PromotionRequestModel reqModel)
    {
        var respModel = _daPromotion.CreatePromotion(reqModel);
        return respModel;
    }

    public PromotionResponseModel UpdatePromotion(int id, PromotionRequestModel reqModel)
    {
        var respModel = _daPromotion.UpdatePromotion(id, reqModel);
        return respModel;
    }

    public void DeletePromotion(int id)
    {
        _daPromotion.DeletePromotion(id);
    }
}
