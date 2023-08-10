using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.API.Data;
using CurrencyConverter.API.Services;
using CurrencyConverter.API.Operations.Deserialization;

namespace CurrencyConverter.API.Controllers
{
    [Route("api/exchangerate")]
    [ApiController]
    public class ExchangeRateController : Controller
    {
        private readonly ExchangeRateDbContext _dbContext;

        public ExchangeRateController(ExchangeRateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //get all the ResponseStatuses from the database
        [HttpGet]
        public IActionResult GetExchangeRates()
        {
            var responseStatuses = _dbContext.ResponseStatus;
            return Ok(responseStatuses);
        }

        //get rates by response status id
        [HttpGet("rates/{id}")]
        public IActionResult GetRatesByResponseStatusId(int id)
        {
            var rates = _dbContext.Rates.Where(r => r.ResponseStatusId == id);
            return Ok(rates);
        }

        //get all errors
        [HttpGet("errors")]
        public IActionResult GetErrors()
        {
            var errors = _dbContext.Errors;
            return Ok(errors);
        }

        [HttpPost]
        public async Task<IActionResult> GetExchangeRate()
        {
            try
            {
                var response = await ExchangeServices.GetExchange("latest");
                var responseStatus = CreateResponseStatusObject.CreateObject(response);
                _dbContext.ResponseStatus.Add(responseStatus);
                await _dbContext.SaveChangesAsync();

                if (!response.Success)
                {
                    var errorObject = CreateErrorObject.CreateObject(response, responseStatus.Id);
                    _dbContext.Errors.Add(errorObject);
                    await _dbContext.SaveChangesAsync();
                }
                else if (response.Success)
                {
                    foreach (var kvp in response.Rates)
                    {
                        var rates = CreateRateObjects.CreateObject(kvp, responseStatus.Id);
                        _dbContext.Rates.Add(rates);
                    }
                    await _dbContext.SaveChangesAsync();
                }
                await _dbContext.SaveChangesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
