using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.GoogleRecaptcha
{
    public interface IGoogleRecaptcha
    {
        Task<bool> IsSatisfy();
    }

    public class GoogleRecaptcha : IGoogleRecaptcha
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        public GoogleRecaptcha(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _configuration = configuration;
            _accessor = accessor;
        }
        public async Task<bool> IsSatisfy()
        {
            var secretKey = _configuration.GetSection("GoogleRecaptcha")["SecretKey"];
            var response = _accessor.HttpContext.Request.Form["g-recaptcha-response"];
            var http = new HttpClient();
            var result = await http.PostAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={response}", null);
            if (result.IsSuccessStatusCode)
            {
                var googleResponse = JsonConvert.DeserializeObject<RecaptchaResponse>
                    (await result.Content.ReadAsStringAsync());
                if (googleResponse == null)
                    return false;

                return googleResponse.Success;
            }
            return false;
        }
    }
}

public class RecaptchaResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("challenge_ts")]
    public DateTimeOffset ChallengeTs { get; set; }

    [JsonProperty("apk_package_name")]
    public string HostName { get; set; }
}
