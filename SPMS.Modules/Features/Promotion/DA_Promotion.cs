using SPMS.Database.Models;
using SPMS.Models.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void DeletePromotion(int id)
    {
    }
}
