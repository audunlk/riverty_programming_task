using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.API.Data;
using CurrencyConverter.API.Services;
using CurrencyConverter.API.Operations.Deserialization;
using CurrencyConverter.ConsoleApp.Operations.Conversion;

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
            var responseStatuses = _dbContext.ResponseStatus.ToList();
            if(responseStatuses.Count == 0)
            {
                return NotFound();
            }
            return Ok(responseStatuses);
        }

        //get rates by response status responseStatusId
        [HttpGet("rates/{responseStatusId}")]
        public IActionResult GetRatesByResponseStatusId(int responseStatusId)
        {
            var rates = _dbContext.Rates.Where(r => r.ResponseStatusId == responseStatusId).ToList();
            if(rates.Count == 0)
            {
                return NotFound();
            }
            return Ok(rates);
        }

        [HttpGet("latest")]
        public IActionResult CalculateExchange(string from, string to, decimal amount)
        {
            //http://localhost:5270/api/exchangerate/latest?from=USD&to=EUR&amount=100
            var responseStatus = _dbContext.ResponseStatus.Where(r => r.Success == true).OrderByDescending(r => r.Date).FirstOrDefault();
            if(responseStatus == null)
            {
                return NotFound();
            }
            var rates = _dbContext.Rates.Where(r => r.ResponseStatusId == responseStatus.Id).ToDictionary(r => r.Currency, r => r.Value);
            if(rates.Count == 0)
            {
                return NotFound();
            }
            var result = ConvertUserInput.Convert(from, to, amount, rates);
            return Ok(result);
        }

        //get all errors
        [HttpGet("errors")]
        public IActionResult GetErrors()
        {
            var errors = _dbContext.Errors;
            if(errors == null)
            {
                return NotFound();
            }
            return Ok(errors);
        }

        //get errors by response status responseStatusId
        [HttpGet("errors/{responseStatusId}")]
        public IActionResult GetErrorsByResponseStatusId(int id)
        {
            var errors = _dbContext.Errors.Where(e => e.ResponseStatusId == id);
            if(errors == null)
            {
                return NotFound();
            }
            return Ok(errors);
        }

        [HttpPost]
        public async Task<IActionResult> GetExchangeRate()
        {
            try
            {
                //date today in yyyy-MM-dd format
                var dateNow = DateTime.Now.ToString("yyyy-MM-dd");
                //perform a get request to the database to check if there already is a successful response for today
                var response = await ExchangeServices.GetExchange(dateNow);
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

        ////get the ResponseStatus by date
        //[HttpGet("{date}")]
        //public IActionResult GetResponseStatusByDate(DateTime date)
        //{
        //    //2021-03-01T00:00:00
        //    //since for testing purposes the date is not unique in the database, the first responseStatus with the date is returned
        //    var responseStatus = _dbContext.ResponseStatus.Where(r => r.Success == true && r.Date == date).FirstOrDefault();
        //    if (responseStatus == null)
        //    {
        //        return NotFound();
        //    }
        //    // else return the rates of the responseStatus
        //    return Ok(responseStatus);
        //}
    }
}
