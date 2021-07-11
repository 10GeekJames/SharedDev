using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Calculator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Calculator.Models;

namespace Calculator.Api
{
    public interface ISeedData
    {
        void Seed(IServiceProvider serviceProvider);
    }
    public partial class SeedData : ISeedData
    {
        private readonly CalculatorDbContext _dbContext;
        public SeedData(CalculatorDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void Seed(IServiceProvider serviceProvider)
        {
            this._dbContext.Database.Migrate();
            ApplySeedData();
        }
        public void ApplySeedData()
        {
            var CalculatorRootBiz = _dbContext.Businesses.FirstOrDefault(rs => rs.Name == "Calculator");
            if (CalculatorRootBiz == null)
            {

                /* +----------------------------------------------------+
                   | add known-individuals                             |
                   +----------------------------------------------------+ */
                var james = new Individual { EmailAddress = "james@10-geek.com", FirstName = "James", LastName = "K" };
                var john = new Individual { EmailAddress = "john@10-geek.com", FirstName = "John", LastName = "Smith" };

                var rootGuest = new Individual { EmailAddress = "jamesG@10-geek.com", FirstName = "Guest James", LastName = "G" };
                var johnGuest = new Individual { EmailAddress = "johnG@10-geek.com", FirstName = "Guest John", LastName = "G" };

                this._dbContext.Individuals.AddRange(james, john, rootGuest, johnGuest);


                CalculatorRootBiz = _dbContext.Businesses.FirstOrDefault(rs => rs.Name == "Calculator");
                if (CalculatorRootBiz == null)
                {
                    CalculatorRootBiz = new Business { Name = "Calculator", FileKey = "Calculator" };
                    var johnCo = new Business { Name = "JohnCo", FileKey = "johnco" };

                    _dbContext.Businesses.AddRange(CalculatorRootBiz, johnCo);
                    this._dbContext.SaveChanges();


                    /* +----------------------------------------------------+
                                      | add a website entry for the CalculatorRoot business       |
                                      +----------------------------------------------------+ */


                    var rootWebsite = new Website()
                    {
                        BusinessId = CalculatorRootBiz.Id,
                        DefaultSubweb = "Calculator.com",
                        DefaultUrl = "https://Calculator.com",
                        Individual = james,
                        Name = "Calculator",
                        WebsiteTitle = "Calculator"
                    };

                    var johnCoWebsite = new Website()
                    {
                        BusinessId = johnCo.Id,
                        DefaultSubweb = "johnco.Calculator.com",
                        DefaultUrl = "https://johnco.Calculator.com",
                        Individual = james,
                        Name = "John Co",
                        WebsiteTitle = "John Co"
                    };

                    _dbContext.Websites.AddRange(rootWebsite, johnCoWebsite);
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = rootWebsite, Subweb = "", Url = "https://localhost" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = rootWebsite, Subweb = "", Url = "https://localhost:5015" });
                    this._dbContext.SaveChanges();




                    /* +----------------------------------------------------+
                       | Add roles to the business                          |
                       +----------------------------------------------------+ */
                    var lookupBusinessRolesCat = new LookupCategory { DisplayText = "Business Roles", LookupText = "BusinessRole", Business = CalculatorRootBiz };
                    var lookupOwner = new LookupType { Business = CalculatorRootBiz, DisplayText = "Owner", LookupText = "Owner", LookupCategory = lookupBusinessRolesCat };
                    var lookupAdmin = new LookupType { Business = CalculatorRootBiz, DisplayText = "Admin", LookupText = "Admin", LookupCategory = lookupBusinessRolesCat };
                    var lookupStaff = new LookupType { Business = CalculatorRootBiz, DisplayText = "Staff", LookupText = "Staff", LookupCategory = lookupBusinessRolesCat };
                    var lookupCustomer = new LookupType { Business = CalculatorRootBiz, DisplayText = "Customer", LookupText = "Customer", LookupCategory = lookupBusinessRolesCat };
                    var lookupClient = new LookupType { Business = CalculatorRootBiz, DisplayText = "Client", LookupText = "Client", LookupCategory = lookupBusinessRolesCat };
                    var lookupVisitor = new LookupType { Business = CalculatorRootBiz, DisplayText = "Visitor", LookupText = "Visitor", LookupCategory = lookupBusinessRolesCat };
                    var lookupSubscriber = new LookupType { Business = CalculatorRootBiz, DisplayText = "Subscriber", LookupText = "Subscriber", LookupCategory = lookupBusinessRolesCat };
                    this._dbContext.AddRange(
                      lookupBusinessRolesCat, lookupOwner, lookupAdmin, lookupStaff, lookupCustomer, lookupClient, lookupVisitor, lookupSubscriber);
                    this._dbContext.SaveChanges();

                    /* +----------------------------------------------------+
                       | give staff/owner roles in the Calculator root business          |
                       +----------------------------------------------------+ */
                    var individualInRootBusiness = new IndividualInBusiness() { Business = CalculatorRootBiz, Individual = james, RoleLookupType = lookupOwner };
                    var individualGuestInRootBusiness = new IndividualInBusiness() { Business = CalculatorRootBiz, Individual = rootGuest, RoleLookupType = lookupVisitor };

                    this._dbContext.IndividualInBusinesses.AddRange(individualInRootBusiness, individualGuestInRootBusiness);

                    this._dbContext.SaveChanges();

                    /* +----------------------------------------------------+
                       | give staff/owner roles in the johnco business      |
                       +----------------------------------------------------+ */
                    var individualInJohnCoBusiness = new IndividualInBusiness() { Business = johnCo, Individual = john, RoleLookupType = lookupOwner };
                    var individualGuestInJohnCoBusiness = new IndividualInBusiness() { Business = johnCo, Individual = johnGuest, RoleLookupType = lookupVisitor };

                    this._dbContext.IndividualInBusinesses.AddRange(individualInJohnCoBusiness, individualGuestInJohnCoBusiness);
                    this._dbContext.SaveChanges();

                    /* +----------------------------------------------------+
                       | add some intial configurations and settings        |
                       +----------------------------------------------------+ */




                    /* +----------------------------------------------------+
                       | add a website entry for the Root business       |
                       +----------------------------------------------------+ */
                    var website = new Website()
                    {
                        BusinessId = CalculatorRootBiz.Id,
                        DefaultSubweb = "sidekick",
                        DefaultUrl = "http://Calculator.com",
                        Individual = james,
                        Name = "Calculator",
                        WebsiteTitle = "Calculator"
                    };
                    _dbContext.Websites.Add(website);
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "app", Url = "http://Calculator.com" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "app", Url = "https://Calculator.com" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "app", Url = "https://Calculator.com:5001" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "", Url = "http://localhost:5000" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "", Url = "http://localhost:5000" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "", Url = "http://localhost" });
                    _dbContext.WebsiteAliases.Add(new WebsiteAlias { Website = website, Subweb = "", Url = "http://sidekick.Calculator.com:5000" });

                    this._dbContext.SaveChanges();






                    /*  +-----------------------------------------------------+
                        > Create Registered Individual
                        +-----------------------------------------------------+ */
                    var individual1 = new Individual
                    {
                        EmailAddress = "James@10-geek.com",
                        FirstName = "James"
                    };
                    /*  +-----------------------------------------------------+
                        > Create Business Website
                        +-----------------------------------------------------+ */
                    var site1 = new Website
                    {
                        DefaultSubweb = "JohnCo",
                        DefaultUrl = "http://johnco.Calculator.com",
                        Individual = individual1,
                        WebsiteTitle = "John Co"
                    };

                    /*  +-----------------------------------------------------+
                        > Create Business
                        +-----------------------------------------------------+ */
                    var biz1 = new Business
                    {
                        Individual = individual1,
                        Name = "JohnCo",
                        Websites = new List<Website> { site1 }
                    };
                    _dbContext.Businesses.Add(biz1);

                    /*  +-----------------------------------------------------+
                        > Add Individual to role in business
                        +-----------------------------------------------------+ */
                    var roleInBusiness = new IndividualInBusiness
                    {
                        Business = biz1,
                        Individual = individual1
                        /* ,
                        RoleLookupTypeId = (long)Calculator.Models.Enums.BusinessRole.Owner */
                    };
                    _dbContext.IndividualInBusinesses.Add(roleInBusiness);
                    _dbContext.SaveChanges();



                }
            }
        }
    }
}