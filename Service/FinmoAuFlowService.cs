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
    public class FinmoAuFlowService : IFinmoAuFlow
    {
        private readonly HttpClient apiClient;
        public IConfiguration Configuration { get; }
        private string baseUrl;
        private string apiKey;
        private string secret;
    
        public FinmoAuFlowService(IConfiguration configuration)
        { 
            Configuration = configuration;
            this.baseUrl = Configuration.GetSection("Finmo:baseUrl").Value;
            this.apiKey = Configuration.GetSection("Finmo:key").Value;
            this.secret = Configuration.GetSection("Finmo:secret").Value;

            //var signature = this.GenerateSignature().Result;

            apiClient = new HttpClient();

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(apiKey + ":" + secret));

            apiClient.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);
        }

        private async Task<string> GenerateSignature()
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

        public async Task<CustomerResponseObject> CreateCustomer(FinmoCustomerObj request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = this.baseUrl + "/v1/customer";

                HttpResponseMessage responseMsg = null;
                responseMsg = await apiClient.PostAsync(url, data);

                var responseStr = await responseMsg.Content.ReadAsStringAsync();
                if (responseMsg.IsSuccessStatusCode)
                {
                     var response = JsonConvert.DeserializeObject<CustomerResponseObject>(responseStr);
                    
                    return response;
                }
                else
                    throw new Exception($"Error while creating the user: Response message is: {responseStr}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<WalletResponseObj> CreateWallet(WalletRequestObj request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = this.baseUrl + "/v1/wallet";

                HttpResponseMessage responseMsg = null;
                responseMsg = await apiClient.PostAsync(url, data);

                var responseStr = await responseMsg.Content.ReadAsStringAsync();
                if (responseMsg.IsSuccessStatusCode)
                {
                     var response = JsonConvert.DeserializeObject<WalletResponseObj>(responseStr);
                    
                    return response;
                }
                else
                    throw new Exception($"Error while creating the wallet: Response message is: {responseStr}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
