using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace Services.MappingProfiles
{ //https://localhost:7133/{Src.PictureUrl}
    internal class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDTo, string>
    {
        public string Resolve(Product source, ProductDTo destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
                return string.Empty;
            else
            {
               // var Url = $"https://localhost:7133/{source.PictureUrl}";
                var Url = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
                return Url;
            }
        }
    }
}
