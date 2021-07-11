using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Calculator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Calculator.Models;

namespace Calculator.Api.Services
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
        public static async Task<Individual> GetLoggedInIndividual(long BusinessId, string LoggedInUserEmail, CalculatorDbContext DbContext)
        {
            return await DbContext.Individuals
                .Include(rs => rs.Calculator2Characters)
                .FirstOrDefaultAsync (rs => rs.EmailAddress.ToLower() == LoggedInUserEmail && (rs.IndividualsInBusinesses.Count(rs => rs.BusinessId == BusinessId) > 0));
        }

        public static async Task<Individual> GetLoggedInIndividualFull(long BusinessId, string LoggedInUserEmail, CalculatorDbContext DbContext)
        {
            var individual = await DbContext.Individuals
                .Include(r => r.Chats)
                .Include(r => r.IndividualsInBusinesses)
                .FirstOrDefaultAsync (rs => rs.EmailAddress.ToLower() == LoggedInUserEmail);

            if (individual == null)
            {
                individual = new Individual() { EmailAddress = LoggedInUserEmail, FirstName = "Awesome", LastName = "Sauce" };
                var individualInBusiness = new IndividualInBusiness()
                {
                    Individual = individual,
                    BusinessId = BusinessId
                    /* ,
                    RoleLookupTypeId = (long) Calculator.Models.Enums.BusinessRole.Visitor */
                };
                DbContext.Individuals.Add(individual);
                DbContext.IndividualInBusinesses.Add(individualInBusiness);
                await DbContext.SaveChangesAsync();
            }
            return individual;
        }

        public static async Task<Website> GetCurrentWebsite(string CallerUrl, CalculatorDbContext DbContext)
        {
            var site = await DbContext.Websites
                            .FirstOrDefaultAsync (rs => rs.DefaultUrl == CallerUrl)
                        ;

            /* if (site == null && CallerUrl.Contains("localhost"))
            {
                var callerUrlSub = CallerUrl.Split(".")[0];
                site = DbContext.Websites.FirstOrDefault(rs => rs.DefaultSubweb == callerUrlSub);
            } */
            if (site == null)
            {
                var alias = await DbContext.WebsiteAliases
                    .Include(rs => rs.Website)
                    .FirstOrDefaultAsync (rs => rs.Url == CallerUrl)
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

        public static Individual GetCreateIndividualFromEmailAddress(CalculatorDbContext dbContext, string emailAddress, string firstName, string lastName, long businessId)
        {
            var individual = dbContext
            .Individuals
            .Include(rs => rs.IndividualsInBusinesses)
            .ThenInclude(rs => rs.Business)
            .FirstOrDefault(rs => rs.EmailAddress == emailAddress);
            if (individual == null)
            {
                individual = new Individual { EmailAddress = emailAddress, FirstName = firstName, LastName = lastName };
                dbContext.Individuals.Add(individual);
                //var individualInBusiness = new IndividualInBusiness { BusinessId = businessId, RoleLookupTypeId = (long)Models.Enums.BusinessRole.Customer, Individual = individual, IsActive = true };
                //dbContext.IndividualInBusinesses.Add(individualInBusiness);
                //dbContext.SaveChanges();
            }
            return individual;
        }
        public static string GetLoggedInUserClaimEmail(IEnumerable<System.Security.Claims.Claim> claims)
        {
            var claimEmail = claims.FirstOrDefault(rs => rs.Type == "preferred_username");
            if (claimEmail == null)
            {
                claimEmail = claims.FirstOrDefault(rs => rs.Type == "email");
            }
            if (claimEmail == null)
            {
                claimEmail = claims.FirstOrDefault(rs => rs.Type == "name");
            }
            if (claimEmail != null)
            {
                return claimEmail.Value;
            }
            else
            {
                return null;
            }
        }
    }
}