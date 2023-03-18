using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zaipay.Configurations;
using Zaipay.Models;
using Zaipay.Models.WebHooks;
using Zaipay.Requests;
using Zaipay.Responses;
using Zaipay.ViewModels;

namespace Zaipay.Service
{
    public class CanadaEftPaymentService : ICanadaEftPaymentService
    {
        private readonly HttpClient apiClient;
        public IConfiguration Configuration { get; }
        private string baseUrl ;
    
        public CanadaEftPaymentService(IConfiguration configuration)
        { 
            Configuration = configuration;
            this.baseUrl = Configuration.GetSection("Apaylo:baseUrl").Value;

            var signature = this.GenerateSignature().Result;

            apiClient = new HttpClient();

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("pre_request_signature", signature);
        }

        public async Task<string> GenerateSignature()
        {
            try
            {
                var apiKey = Configuration.GetSection("Apaylo:key").Value;
                var secret = Configuration.GetSection("Apaylo:secret").Value;

                string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string concatedString = apiKey + secret + currentDate;

                byte[] concatedBytes = Encoding.UTF8.GetBytes(concatedString);
                byte[] hashBytes = new SHA512Managed().ComputeHash(concatedBytes);

                string signature = Convert.ToBase64String(hashBytes);
                return signature;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateCustomer(CreateCustomerObj request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = this.baseUrl + "/EFT/CreateCustomer";

                HttpResponseMessage responseMsg = null;
                responseMsg = await apiClient.PostAsync(url, data);

                var responseStr = await responseMsg.Content.ReadAsStringAsync();

                if (responseMsg.IsSuccessStatusCode)
                {
                    //var walletId = await this.GetDigitalWalletAccountId(request.TopRateId);
                    //var message = await this.CreateVirtualAccount(walletId);
                    
                    return "Success";
                }
                else
                    throw new Exception($"Error while creating the user(Zai pay): Response message is: {responseStr}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
