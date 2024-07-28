using Microsoft.AspNetCore.Mvc;
using paymob_integration.Controllers;
using paymob_integration.Models;
using System.Collections;
using System.Text;
using System.Text.Json;

namespace WebApi.Controllers
{

    public class PaymobController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> CreateOrUpdatePaymentIntent(PaymobDto paymobDto)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accept.paymob.com/v1/intention/");
            request.Headers.Add("Authorization", "Token Secret Key" /* Secret Key */);

            var jsonBody = new
            {
                amount = paymobDto.GetAmount(),
                currency = "EGP",
                payment_methods = new ArrayList() { "card" /* integration name*/, 4326403 /* integration id*/, 4619036/* integration id*/ } /* you can use name or id you get it from developers/payment integration*/,
                items = paymobDto.items,
                billing_data = new
                {
                    apartment = "6",
                    first_name = "Ammar",
                    last_name = "Sadek",
                    street = "938, Al-Jadeed Bldg",
                    building = "939",
                    phone_number = "+96824480228",
                    country = "OMN",
                    email = "AmmarSadek@gmail.com",
                    floor = "1",
                    state = "Alkhuwair"
                },
                customer =paymobDto.Customer
            };

            var content = new StringContent(JsonSerializer.Serialize(jsonBody), Encoding.UTF8, "application/json");
            request.Content = content;

            try
            {
                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    
                    return Ok(responseContent);
                }
                return BadRequest(responseContent);
              
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as necessary
                return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
            }
        }
    }
}
