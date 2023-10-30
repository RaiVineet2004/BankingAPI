using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankData.EFCore;
using BankData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankData.Controllers
{

    [ApiController]
    public class BankDataController : ControllerBase
    {
        private readonly DbHelper _db;

        private readonly ILogger<BankDataController> _logger;
        public BankDataController(ILogger<BankDataController> logger, EF_DataContext eF_DataContext)
        {
            _logger = logger;
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/BankData
        [HttpGet]
        [Route("api/[controller]/GetRawBankTrans")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<RawBankTrans> data = _db.GetRawBankTrans();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }

                // Log a successful retrieval
                Log.Information("Retrieved RawBankTrans data successfully.");
                return Ok(ResponseHandler.GetAppResponse(type, data));

            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                // Log an error
                Log.Error(ex, "Error while retrieving RawBankTrans data.");
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetBankTrans")]
        public IActionResult Get1()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<BankTrans> data = _db.GetBankTrans();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                Log.Information("Retrieved BankTrans data successfully.");
                return Ok(ResponseHandler.GetAppResponse(type, data));

            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                Log.Error(ex, "Error while retrieving BankTrans data.");
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpPost]
        [Route("api/[controller]/SaveRawBankTran")]
        public IActionResult Post([FromBody] RawBankTrans bankTrans)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveBankTran(bankTrans);

                _logger.LogInformation("Saved RawBankTrans data: {@bankTrans}", bankTrans);

                return Ok(ResponseHandler.GetAppResponse(type, bankTrans));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while saving RawBankTrans data: {@bankTrans}", bankTrans);
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateRawBankTran")]
        public IActionResult Put([FromBody] RawBankTrans bankTrans)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveBankTran(bankTrans);
                _logger.LogInformation("Updated RawBankTrans data: {@bankTrans}", bankTrans);
                return Ok(ResponseHandler.GetAppResponse(type, bankTrans));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating RawBankTrans data: {@bankTrans}", bankTrans);

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete()]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteBankTran(id);
                // Log a successful deletion
                _logger.LogInformation("Deleted RawBankTrans data with ID: {Id}", id);
                return Ok(ResponseHandler.GetAppResponse(type, null));
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "Error while deleting RawBankTrans data with ID: {Id}", id);

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        
    }
}
