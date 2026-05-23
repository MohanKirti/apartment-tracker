using System;
using System.Collections.Generic;
using System.Web.Http;
using ApartmentTracker.Business.DTOs;
using ApartmentTracker.Data.Models;

namespace ApartmentTracker.API.Controllers
{
    [RoutePrefix("api/expenses")]
    public class ExpensesController : ApiController
    {
        // TODO: Inject IExpenseService through dependency injection

        /// <summary>
        /// Get all expenses for an apartment
        /// </summary>
        [HttpGet]
        [Route("apartment/{apartmentId}")]
        public IHttpActionResult GetExpensesByApartment(int apartmentId)
        {
            try
            {
                // TODO: Implement logic using IExpenseService
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get expense by ID
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetExpenseById(int id)
        {
            try
            {
                // TODO: Implement logic using IExpenseService
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Create a new expense
        /// </summary>
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateExpense([FromBody] CreateExpenseDTO createExpenseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // TODO: Implement logic using IExpenseService
                return Created("", new { });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Update an expense
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateExpense(int id, [FromBody] UpdateExpenseDTO updateExpenseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // TODO: Implement logic using IExpenseService
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete an expense
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteExpense(int id)
        {
            try
            {
                // TODO: Implement logic using IExpenseService
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get expense summary for an apartment
        /// </summary>
        [HttpGet]
        [Route("summary/apartment/{apartmentId}")]
        public IHttpActionResult GetExpenseSummary(int apartmentId, [FromUri] int month = 0, [FromUri] int year = 0)
        {
            try
            {
                if (month == 0) month = DateTime.Now.Month;
                if (year == 0) year = DateTime.Now.Year;

                // TODO: Implement logic to return total expenses, category breakdown, etc.
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get resident payment summary
        /// </summary>
        [HttpGet]
        [Route("resident/{residentId}/summary")]
        public IHttpActionResult GetResidentPaymentSummary(int residentId, [FromUri] int apartmentId)
        {
            try
            {
                // TODO: Implement logic to return total owed, paid, pending, etc.
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}