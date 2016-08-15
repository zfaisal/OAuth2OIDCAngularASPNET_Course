﻿using AutoMapper;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripGallery.API.Helpers;
using System.Web.Http.Cors;
using IdentityServer3.AccessTokenValidation;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace TripGallery.API
{
    public class Startup
    { 

        public void Configuration(IAppBuilder app)
        {
            BypassCertificateError(); 
            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority= Constants.TripGallerySTS,
                    RequiredScopes = new [] { "gallerymanagement" }
                }
                );
            var config = WebApiConfig.Register();
            
            app.UseWebApi(config);

            InitAutoMapper();
        }

        private void InitAutoMapper()
        {
            Mapper.CreateMap<Repository.Entities.Trip,
                DTO.Trip>().ForMember(dest => dest.MainPictureUri,
                op => op.ResolveUsing(typeof(InjectImageBaseForTripResolver)));

            Mapper.CreateMap<Repository.Entities.Picture,
                DTO.Picture>()
                .ForMember(dest => dest.Uri,
                op => op.ResolveUsing(typeof(InjectImageBaseForPictureResolver)));

            Mapper.CreateMap<DTO.Picture,
              Repository.Entities.Picture>();
        

            Mapper.CreateMap<DTO.Trip,
                Repository.Entities.Trip>().ForMember(dest => dest.MainPictureUri,
                op => op.ResolveUsing(typeof(RemoveImageBaseForTripResolver))); ;

            Mapper.CreateMap<DTO.PictureForCreation,
                Repository.Entities.Picture>()
                .ForMember(o => o.Id, o => o.Ignore())
                .ForMember(o => o.TripId, o => o.Ignore())
                .ForMember(o => o.OwnerId, o => o.Ignore())
                .ForMember(o => o.Uri, o => o.Ignore());


            Mapper.CreateMap<DTO.TripForCreation,
         Repository.Entities.Trip>()
            .ForMember(o => o.Id, o => o.Ignore())
            .ForMember(o => o.MainPictureUri, o => o.Ignore())
            .ForMember(o => o.Pictures, o => o.Ignore())
            .ForMember(o => o.OwnerId, o => o.Ignore());


            Mapper.AssertConfigurationIsValid();
        }

        public void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback +=

                delegate (
                    Object sender1,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }
    }
}
