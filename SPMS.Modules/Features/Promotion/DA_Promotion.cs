using SPMS.Database.Models;
using SPMS.Models.Promotion;
using SPMS.Models;

namespace SPMS.Modules.Features.Promotion;

public class DA_Promotion
{
    private readonly AppDbContext _db;

    public DA_Promotion(AppDbContext db)
    {
        _db = db;
    }

    public PromotionListResponseModel GetPromotions()
    {
        return new PromotionListResponseModel();
    }

    public PromotionResponseModel GetPromotionById(int id)
    {
        return new PromotionResponseModel();
    }

    public PromotionResponseModel CreatePromotion(PromotionRequestModel reqModel)
    {
        return new PromotionResponseModel();
    }

    public PromotionResponseModel UpdatePromotion(int id, PromotionRequestModel reqModel)
    {
        return new PromotionResponseModel();
    }

    public Result<object> DeletePromotion(int id)
    {
        Result<object> model = new Result<object>();
        model = Result<object>.Error("Delete failed");
        return model;
    }
}
