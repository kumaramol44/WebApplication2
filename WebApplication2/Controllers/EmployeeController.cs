using WebApplication2.APIModel;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Owin.Logging;
using WebApplication2.Services;
using Swashbuckle.Swagger.Annotations;
using Swashbuckle.Swagger;
using WebApplication2.CommonMethods;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    public class EmployeeController : ApiController
    {
        EmployeeServices emp_service = new EmployeeServices();
        /// <summary>
        /// Get all the employees.For Gender,Enums are specified as Male=1,Female=2.For Image base64 String is present.
        /// </summary>
        /// <returns></returns>
        // GET api/<controller>
        [HttpGet]
        [Route("api/Employee")]
        [ResponseType(typeof(List<APIModel.Employee>))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, emp_service.Get());
            return response;
        }

        /// <summary>
        /// Get Employee By Id.For Gender,Enums are specified as Male=1,Female=2.For Image base64 String is present.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Employee/{id}")] 
        [ResponseType(typeof(APIModel.Employee))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var emp = emp_service.Get(id);
                if (emp == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Not Found.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, emp_service.Get(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// This API is to add Employee Detail.For Gender,Enums are specified as Male=1,Female=2.For Image provide valid base64 image.
        /// </summary>
        /// <param name="employee"></param>
        [HttpPost]
        [Route("api/Employee")]
        [ResponseType(typeof(string))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public HttpResponseMessage Post([FromBody]APIModel.Employee employee)
        {
            if (!HelperFunctions.fBrowserIsMobile())
            {
                if (employee == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong type is given for either of the field.");
                }
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp_service.Add(employee));
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You only have read operation.Unauthorized access.");
            }
        }
        /// <summary>
        /// This API is to update the Employee details.For Gender,Enums are specified as Male=1,Female=2.For Image provide valid base64 image.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Employee/{id}")]
        [ResponseType(typeof(APIModel.Employee))]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public HttpResponseMessage Put(int id, APIModel.Employee employee)
        {
            if (!HelperFunctions.fBrowserIsMobile())
            {
                try
                {
                    var updateEmp = emp_service.Update(id, employee);
                    if (updateEmp == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Not Found");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, updateEmp);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You only have read operation.Unauthorized access.");
            }

        }

        /// <summary>
        /// Delete Employee record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<controller>/5
        [HttpDelete]
        [ResponseType(typeof(string))]
        [Route("api/Employee/{id}")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public HttpResponseMessage Delete(int id)
        {
            if (!HelperFunctions.fBrowserIsMobile())
            {
                try
                {
                    emp_service.Delete(id);
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "Employee Deleted Successfully!!");
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You only have read operation.Unauthorized access.");
            }

        }


    }
}