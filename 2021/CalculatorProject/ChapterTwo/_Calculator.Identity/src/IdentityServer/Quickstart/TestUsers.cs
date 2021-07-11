// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace Calculator.IdentityHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "12345 North-Western Way",
                    locality = "Sunny California",
                    postal_code = 11223,
                    country = "USA"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "123456",
                        Username = "tiff",
                        Password = "tiff",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Tiffany K"),
                            new Claim(JwtClaimTypes.GivenName, "Tiffany"),
                            new Claim(JwtClaimTypes.FamilyName, "K"),
                            new Claim(JwtClaimTypes.Email, "TiffanyKies@Gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, ""),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "Editor"),                            
                            new Claim(JwtClaimTypes.Role, "Participant"),
                            new Claim(JwtClaimTypes.Role, "Contributor")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "33445566",
                        Username = "james",
                        Password = "james",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "James K"),
                            new Claim(JwtClaimTypes.GivenName, "James"),
                            new Claim(JwtClaimTypes.FamilyName, "K"),
                            new Claim(JwtClaimTypes.Email, "10geekjames@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://jameskies.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "Editor"),
                            new Claim(JwtClaimTypes.Role, "Admin"),
                            new Claim(JwtClaimTypes.Role, "Participant"),
                            new Claim(JwtClaimTypes.Role, "Contributor")
                        }
                    }
                };
            }
        }
    }
}