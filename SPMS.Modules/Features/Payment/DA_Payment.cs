using SPMS.Database.Models;
using SPMS.Models.Payment;

namespace SPMS.Modules.Features.Payment;

public class DA_Payment
{
    private readonly AppDbContext _db;

    public DA_Payment(AppDbContext db)
    {
        _db = db;
    }

    public PaymentListResponseModel GetPayments()
    {
        return new PaymentListResponseModel();
    }

    public PaymentResponseModel GetPaymentById(int id)
    {
        return new PaymentResponseModel();
    }

    public PaymentResponseModel CreatePayment(PaymentRequestModel reqModel)
    {
        return new PaymentResponseModel();
    }

    public PaymentResponseModel UpdatePayment(int id, PaymentRequestModel reqModel)
    {
        return new PaymentResponseModel();
    }

    public void DeletePayment(int id)
    {

    }
}