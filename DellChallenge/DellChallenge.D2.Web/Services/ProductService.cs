﻿using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);

            return apiResponse.Data;
        }

        public void Delete(string id)
        {
            var apiClient = new RestClient("http://localhost:2534/api");

            var apiRequest = new RestRequest(string.Format("products/{0}", id), Method.DELETE, DataFormat.None);

            var apiResponse = apiClient.Execute(apiRequest);
        }

        

        public IEnumerable<ProductModel> GetAll()
        {
            
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);

            return apiResponse.Data;
        }

        public ProductModel Get(string Id)
        {

            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest(string.Format("products/{0}",Id), Method.GET, DataFormat.Json);

            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);

            return apiResponse.Data;
        }

        public void Update(string id, ProductModel product)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest(string.Format("products/{0}", id), Method.PUT, DataFormat.Json);

            apiRequest.AddJsonBody(product);

            var apiResponse = apiClient.Execute(apiRequest);
        }
    }
}
