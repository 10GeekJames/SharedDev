// This file is now under code-gen control, do not touch, will be regenerated frequenly
    using System;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Kendo.DynamicLinqCore;
    using Calculator.Api.Services;
    using System.IO;
    using Calculator.Infrastructure;
    using Calculator.Models;
    using Calculator.Models.ViewModels;

    namespace Api.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class IndividualController : ControllerBase
        {
            private CalculatorDbContext _dbContext;
            private IMapper _mapper;
            public IndividualController(CalculatorDbContext dbContext, IMapper mapper)
            {
                this._dbContext = dbContext;
                this._mapper = mapper;
            }

            [HttpGet, Authorize(policy: "read-access")]
            public async Task<IActionResult> Get(long id)
            {
                var uri = new Uri(Request.Headers["Referer"]);
                var callerUrl = $"{uri.Scheme}://{uri.Host}";
                var response = new IndividualVM();

                long businessId = 0;
                var loggedInUserEmail = "";
                var claimEmail = HttpContext.User.Claims.FirstOrDefault(rs => rs.Type == "name");
                if (claimEmail != null)
                {
                    loggedInUserEmail = claimEmail.Value;
                }


                Website site = await CalculatorControllerUtility.GetCurrentWebsite(callerUrl, _dbContext);
                if (site == null)
                {
                    throw new Exception("Site Business could not be located");
                }

                businessId = site.BusinessId;

                if (claimEmail != null)
                {
                    Individual individual = await CalculatorControllerUtility.GetLoggedInIndividual(businessId, loggedInUserEmail, _dbContext);

                    if (individual == null)
                    {
                        throw new Exception("Individual could not be located");
                    }

                    var isOwner = CalculatorControllerUtility.IsSiteOwner(site, individual, _dbContext);
                    if (!isOwner)
                    {
                        throw new Exception("Not an owner/admin of this site.");
                    }
                }
                var Individual = _dbContext.Individuals.Find(id);

                response = _mapper.Map<IndividualVM>(Individual);
                return Ok(response);
            }

            [HttpPut, Authorize(policy: "read-access")]
            public async Task<IActionResult> Put(IndividualVM IndividualVM)
            {
                var uri = new Uri(Request.Headers["Referer"]);
                var callerUrl = $"{uri.Scheme}://{uri.Host}";
                var response = new HashSet<IndividualVM>();

                long businessId = 0;
                var loggedInUserEmail = "";
                var claimEmail = HttpContext.User.Claims.FirstOrDefault(rs => rs.Type == "name");
                if (claimEmail != null)
                {
                    loggedInUserEmail = claimEmail.Value;
                }


                Website site = await CalculatorControllerUtility.GetCurrentWebsite(callerUrl, _dbContext);
                if (site == null)
                {
                    throw new Exception("Site Business could not be located");
                }

                businessId = site.BusinessId;

                if (claimEmail != null)
                {
                    Individual individual = await CalculatorControllerUtility.GetLoggedInIndividual(businessId, loggedInUserEmail, _dbContext);

                    if (individual == null)
                    {
                        throw new Exception("Individual could not be located");
                    }

                    var isOwner = CalculatorControllerUtility.IsSiteOwner(site, individual, _dbContext);
                    if (!isOwner)
                    {
                        throw new Exception("Not an owner/admin of this site.");
                    }
                }
                var Individual = _dbContext.Individuals
                .Find(IndividualVM.Id);

                if (Individual == null)
                {
                    throw new Exception("Individual could not be located");
                }

                _dbContext.Attach(Individual).CurrentValues.SetValues(IndividualVM);

                try
                {
                    _dbContext.SaveChanges();
                    return Ok();
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            [HttpPost, Authorize(policy: "read-access")]
            public async Task<IActionResult> Post(IndividualVM IndividualVM)
            {
                var uri = new Uri(Request.Headers["Referer"]);
                var callerUrl = $"{uri.Scheme}://{uri.Host}";
                var response = new HashSet<IndividualVM>();

                long businessId = 0;
                var loggedInUserEmail = "";
                var claimEmail = HttpContext.User.Claims.FirstOrDefault(rs => rs.Type == "name");
                if (claimEmail != null)
                {
                    loggedInUserEmail = claimEmail.Value;
                }


                Website site = await CalculatorControllerUtility.GetCurrentWebsite(callerUrl, _dbContext);
                if (site == null)
                {
                    throw new Exception("Site Business could not be located");
                }

                businessId = site.BusinessId;

                Individual individual = await CalculatorControllerUtility.GetLoggedInIndividual(businessId, loggedInUserEmail, _dbContext);
                if (claimEmail != null)
                {

                    if (individual == null)
                    {
                        throw new Exception("Individual could not be located");
                    }

                    var isOwner = CalculatorControllerUtility.IsSiteOwner(site, individual, _dbContext);
                    if (!isOwner)
                    {
                        throw new Exception("Not an owner/admin of this site.");
                    }
                }
                var businessIdProperty = typeof(IndividualVM).GetProperty("BusinessId");
                if( businessIdProperty != null)
                {
                    businessIdProperty.SetValue(IndividualVM, businessId);
                }
                var individualIdProperty = typeof(IndividualVM).GetProperty("IndividualId");
                if( individualIdProperty != null)
                {
                    individualIdProperty.SetValue(IndividualVM, individual.Id);
                }
                var _Individual= _mapper.Map<Individual>(IndividualVM);
                _dbContext.Individuals.Add(_Individual);

                try
                {
                    _dbContext.SaveChanges();
                    return Ok( _mapper.Map<IndividualVM>(_Individual));
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            [HttpPost, Authorize(policy: "read-access"), Route("search")]
            public async Task<DataSourceResult> Search(DataSourceRequestWithSearchParam request)
            {
                // JsonSerializerOptions jsonSerializerOptions = CustomJsonSerializerOptions.DefaultOptions;
                var uri = new Uri(Request.Headers["Referer"]);
                var callerUrl = $"{uri.Scheme}://{uri.Host}";
                var response = new HashSet<IndividualVM>();

                long businessId = 0;
                var loggedInUserEmail ="";
                var claimEmail = HttpContext.User.Claims.FirstOrDefault(rs => rs.Type == "name");
                if (claimEmail != null)
                {
                    loggedInUserEmail = claimEmail.Value;
                }


                Website site = await CalculatorControllerUtility.GetCurrentWebsite(callerUrl, _dbContext);
                if (site == null)
                {
                    throw new Exception("Site Business could not be located");
                }

                businessId = site.BusinessId;

                if (claimEmail != null)
                {
                    Individual individual = await CalculatorControllerUtility.GetLoggedInIndividual(businessId, loggedInUserEmail, _dbContext);

                    if (individual == null)
                    {
                        throw new Exception("Individual could not be located");
                    }

                    var isOwner = CalculatorControllerUtility.IsSiteOwner(site, individual, _dbContext);
                    if (!isOwner)
                    {
                        throw new Exception("Not an owner/admin of this site.");
                    }
                }

                var content = "";
                using (var contentStream = this.Request.BodyReader.AsStream())
                {
                    using (var sr = new StreamReader(contentStream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

                // var request = JsonSerializer.Deserialize<DataSourceRequestWithSearchParam>(content, jsonSerializerOptions);
                IQueryable<IndividualVM> Individuals;
                if (request.StringToSearchFor == null || request.StringToSearchFor.Length == 0)
                {
                    Individuals = _dbContext.Individuals
//                    .Include(rs => rs.OrderState)
                    .Take(int.MaxValue)
                    .Select(rs => _mapper.Map<IndividualVM>(rs));
                }
                else
                {
                    Individuals = _dbContext.Individuals
//                        .Include(rs => rs.OrderState)
//                        .Where(rs => rs.Business.Name.Contains(request.StringToSearchFor) ||
//                                    rs.ExternalNotes.Contains(request.StringToSearchFor) ||
//                                    rs.CreditFileNumber.ToString().Contains(request.StringToSearchFor) ||
//                                    rs.ReferenceNumber.ToString().Contains(request.StringToSearchFor) ||
//                                    rs.CompanyName.Contains(request.StringToSearchFor) ||
//                                    rs.RequestorEmailAddress.Contains(request.StringToSearchFor))
                        .OrderBy(rs => rs.Id)
                        .Select(rs => _mapper.Map<IndividualVM>(rs));
                }
                if (request.Filter != null)
                {
                    for (var x = 0; x < request.Filter.Filters.Count(); x++)
                    {
                        request.Filter.Filters.ElementAt(x).Field = request.Filter.Filters.ElementAt(x).Field[0].ToString().ToUpper() + request.Filter.Filters.ElementAt(x).Field.Substring(1);
                    }
                }
                var rs = Individuals.ToList().AsQueryable().ToDataSourceResult(request.Take, request.Skip, request.Sort, request.Filter, request.Aggregate, request.Group);
                return rs;
            }
        }
    }
