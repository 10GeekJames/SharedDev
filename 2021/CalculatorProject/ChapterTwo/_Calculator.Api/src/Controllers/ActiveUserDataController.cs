using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Calculator.Models;
using Calculator.Models.ViewModels;
using Calculator.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Calculator.Api.Services;

namespace Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveUserDataController : ControllerBase
    {
        private CalculatorDbContext _dbContext;
        private IMapper _mapper;
        public ActiveUserDataController(CalculatorDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {

            var uri = new Uri(Request.Headers["Referer"]);
            var callerUrl = $"{uri.Scheme}://{uri.Host}";
            var claimEmail = CalculatorControllerUtility.GetLoggedInUserClaimEmail(HttpContext.User.Claims);
            var response = new ActiveUserDataVM();

            Website site = await CalculatorControllerUtility.GetCurrentWebsite(callerUrl, _dbContext);
            if (site == null)
            {
                throw new Exception("Site Business could not be located");
            }

            var individual = await CalculatorControllerUtility.GetLoggedInIndividualFull(site.BusinessId, claimEmail, _dbContext);

            if (individual != null)
            {
                response.IndividualVM = _mapper.Map<IndividualVM>(individual);
                response.ChatsVM = _mapper.Map<ICollection<Chat>, ICollection<ChatVM>>(individual.Chats);
                if (individual.IndividualsInBusinesses != null)
                {
                    response.IndividualVM.IndividualsInBusinessesVM = _mapper.Map<ICollection<IndividualInBusinessVM>>(individual.IndividualsInBusinesses);
                }
            }
            // var deposit = _dbContext.Payments.Where(rs=>rs.ProductIndividualSubscriptions)

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            response.cEmailAddress = userEmail;
            response.cUserName = userName;
            response.cUserId = userEmail;


            response.Validated = true;
            response.Initialized = true;

            //var initPayment = _dbContext.Payments.Count(rs=>rs.IndividualId == individual.Id && rs.BusinessId == 1 && rs.PaymentTypeId.ToString() == LookupTypes.PaymentType_BasePayment.ToString());
            //response.Initialized = initPayment > 0;

            // init new user
            return Ok(response);
        }
    }
}

