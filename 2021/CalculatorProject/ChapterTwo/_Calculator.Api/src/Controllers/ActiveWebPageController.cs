using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Models;
using Calculator.Models.ViewModels;
using Calculator.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Api.Controllers.Services
{
    public static class CalculatorControllerUtility
    {
        public static bool IsSiteOwner(Website Website, Individual Individual, CalculatorDbContext DbContext)
        {
            bool isOwner = DbContext.IndividualInBusinesses.Count(rs => rs.BusinessId == Website.BusinessId &&
                            rs.IndividualId == Individual.Id &&
                            (rs.RoleLookupTypeId == 1
                                || rs.RoleLookupTypeId == 20)) >= 1;

            return isOwner;
        }

        public static Individual GetLoggedInIndividual(long BusinessId, string LoggedInUserEmail, CalculatorDbContext DbContext)
        {
            return DbContext.Individuals
                .Include(rs => rs.Calculator2Characters)
                .FirstOrDefault(rs => rs.EmailAddress.ToLower() == LoggedInUserEmail && (rs.IndividualsInBusinesses.Count(rs => rs.BusinessId == BusinessId) > 0));
        }
        public static Individual GetLoggedInIndividualFull(long BusinessId, string LoggedInUserEmail, CalculatorDbContext DbContext)
        {
            var individual = DbContext.Individuals
                .Include(r => r.Chats)
                .Include(r => r.IndividualsInBusinesses)
                .FirstOrDefault(rs => rs.EmailAddress.ToLower() == LoggedInUserEmail);

            if (individual == null)
            {
                individual = new Individual() { EmailAddress = LoggedInUserEmail, FirstName = "Awesome", LastName = "Sauce" };
                var individualInBusiness = new IndividualInBusiness()
                {
                    Individual = individual,
                    BusinessId = BusinessId,
                    RoleLookupTypeId = 23
                };
                DbContext.Individuals.Add(individual);
                DbContext.IndividualInBusinesses.Add(individualInBusiness);
                DbContext.SaveChanges();
            }
            return individual;
        }

        public static Website GetCurrentWebsite(string CallerUrl, CalculatorDbContext DbContext)
        {
            var site = DbContext.Websites
                            .FirstOrDefault(rs => rs.DefaultUrl == CallerUrl)
                        ;

            /* if (site == null && CallerUrl.Contains("localhost"))
            {
                var callerUrlSub = CallerUrl.Split(".")[0];
                site = DbContext.Websites.FirstOrDefault(rs => rs.DefaultSubweb == callerUrlSub);
            } */
            if (site == null)
            {
                var alias = DbContext.WebsiteAliases
                    .Include(rs => rs.Website)
                    .FirstOrDefault(rs => rs.Url == CallerUrl)
                ;

                if (alias != null)
                {
                    site = alias.Website;
                }
            }

            return site;
        }

        public static string GetExceptionText(Exception e)
        {
            var rsp = "";
            rsp += e.Message + Environment.NewLine;
            if (e.InnerException != null)
                rsp += e.InnerException.Message + Environment.NewLine;
            rsp += e.StackTrace + Environment.NewLine;
            rsp += e.Source + Environment.NewLine;
            return rsp;
        }        
    }
}