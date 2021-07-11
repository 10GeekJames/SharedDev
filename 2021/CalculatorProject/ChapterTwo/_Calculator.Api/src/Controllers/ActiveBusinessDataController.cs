using System;
using System.Linq;
using AutoMapper;
using Calculator.Models;
using Calculator.Models.ViewModels;
using Calculator.Models.RequestResponse;
using Calculator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Calculator.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveBusinessDataController : ControllerBase
    {
        private CalculatorDbContext _dbContext;
        private IMapper _mapper;
        public ActiveBusinessDataController(CalculatorDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var uri = new Uri(Request.Headers["Referer"]);
            var callerUrl = $"{uri.Scheme}://{uri.Host}";
            var response = new ActiveBusinessDataVM();

            Website site = await CalculatorControllerUtility.GetCurrentWebsite(callerUrl, _dbContext);
            if (site == null)
            {
                throw new Exception("Site Business could not be located");
            }

            if (site != null)
            {
                Business business = await _dbContext.Businesses
                    .FindAsync(site.BusinessId)
                ;

                response.BusinessVM = _mapper.Map<Business, BusinessVM>(business);
                response.WebsiteVM = _mapper.Map<Website, WebsiteVM>(site);

                var categories = await _dbContext
                    .LookupCategories
                    .Include(rs => rs.LookupTypes)
                    .Select(rs =>
                        new LookupCategoryViewModel
                        {
                            Id = rs.Id,
                            LookupText = rs.LookupText,
                            DisplayText = rs.DisplayText,
                            SortOrderValue = rs.SortOrderValue,
                            LookupTypes = rs.LookupTypes.Select(rss => 
                                new LookupTypeViewModel
                                {
                                    Id = rss.Id,
                                    SortOrderValue = rss.SortOrderValue,
                                    LookupText = rss.LookupText,
                                    DisplayText = rss.DisplayText,
                                    TypeBlob = rss.TypeBlob,
                                    TypeJson = rss.TypeJson,
                                    TypeBool = rss.TypeBool,
                                    TypeNumber = rss.TypeNumber,
                                    TypeSpecialA = rss.TypeSpecialA,
                                    TypeSpecialB = rss.TypeSpecialB,
                                    TypeText = rss.TypeText,
                                    Value = rss.Value,
                                    ParentLookupTypeId = rss.ParentLookupTypeId,
                                    LookupCategoryId = rs.Id
                                }).ToList()
                        })
                    .ToListAsync();


                response.LookupCategoriesVM = categories;

                response.Initialized = true;
            }

            // init new Business
            return Ok(response);
        }
    }
}