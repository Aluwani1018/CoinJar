using AutoMapper;
using CoinJar.Core.Interfaces;
using CoinJar.Service.Services;
using Microsoft.AspNetCore.Mvc;
using CoinJar.Api.Model.Requests;
using CoinJar.Api.Model.Response;
using Swashbuckle.AspNetCore.Annotations;
using CoinJar.Core.Domain;

namespace CoinJar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICoinService _coinService;

        public CoinController
           (
                IMapper mapper,
                ICoinService coinService
           )
        {
            this._mapper = mapper;
            this._coinService = coinService;
        }

        [HttpPost("Add")]
        [SwaggerOperation("Add Coin")]
        public IActionResult AddCoin([FromBody] CoinRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Coin coin = _mapper.Map<CoinRequest, Coin>(request);
            
            _coinService.AddCoin(coin);
            return Ok();
        }

        [HttpGet("TotalAmount")]
        [SwaggerOperation("Get Coins Total Amount")]
        [SwaggerResponse(statusCode: 200, type: typeof(CoinResponse), description: "Success Request")]
        public IActionResult GetTotalAmount()
        {
            decimal totalAmount = _coinService.GetTotalAmount();

            return Ok(new CoinResponse()
            {
                TotalAmount = totalAmount
            });
        }

        [HttpDelete("Reset")]
        [SwaggerOperation("Reset")]
        public IActionResult Reset()
        {
            _coinService.Reset();
            
            return Ok();
        }
    }
}
