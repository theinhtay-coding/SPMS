using SPMS.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMS.Modules.Features.Payment;

public class BL_Payment
{
    private readonly DA_Payment _daPayment;

    public BL_Payment(DA_Payment daPayment)
    {
        _daPayment = daPayment;
    }

    public PaymentListResponseModel GetPayments()
    {
        var respModel = _daPayment.GetPayments();
        return respModel;
    }

    public PaymentResponseModel GetPaymentById(int id)
    {
        var respModel = _daPayment.GetPaymentById(id);
        return respModel;
    }

    public PaymentResponseModel CreatePayment(PaymentRequestModel reqModel)
    {
        var respModel = _daPayment.CreatePayment(reqModel);
        return respModel;
    }

    public PaymentResponseModel UpdatePayment(int id, PaymentRequestModel reqModel)
    {
        var respModel = _daPayment.UpdatePayment(id, reqModel);
        return respModel;
    }

    public void DeletePayment(int id)
    {
        _daPayment.DeletePayment(id);
    }
}
