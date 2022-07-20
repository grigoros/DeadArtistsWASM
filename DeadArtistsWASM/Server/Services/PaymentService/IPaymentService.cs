using Stripe.Checkout;

namespace DeadArtistsWASM.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreatCheckoutSession();
        Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request);
    }
}
