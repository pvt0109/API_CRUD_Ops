using API_CURR_Converter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_CURR_Converter.Controllers
{
    public class CRUDController : ApiController
    {
        
        CRUDOps cRUDOps = new CRUDOps();
        
        [HttpGet]
        public IEnumerable<CRUD> GetAll()
        {
            return cRUDOps.GetAll();
            
        }

        
        [HttpGet]
        public CRUD Get(int id)
        {
            CRUD item = cRUDOps.Get(id);
            if (item == null)
            {
                var Error_response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Employee found with ID = {0}", id)),
                    ReasonPhrase = "Data Not Found"
                };

                throw new HttpResponseException(Error_response);
            }
            return item;
        }

        
        [HttpPost]
        public HttpResponseMessage PostCRUD(CRUD item)
        {
            item = cRUDOps.Add(item);
            if (item == null)
            {
                var Error_response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("An Error Occured")),
                    ReasonPhrase = "Data Not Found"
                };

                throw new HttpResponseException(Error_response);
            }
            var response = Request.CreateResponse<CRUD>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        
        
        [HttpPut]
        public HttpResponseMessage Put(int id,CRUD cRUD)
        {
            cRUD.Id = id;
            if (!cRUDOps.Update(cRUD))
            {
                var Error_response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Data found with ID = {0}", id)),
                    ReasonPhrase = "Data Not Found"
                };

                throw new HttpResponseException(Error_response);
            }
            var response = Request.CreateResponse<CRUD>(HttpStatusCode.Created, cRUD);
            string uri = Url.Link("DefaultApi", new { id = cRUD.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            CRUD item = cRUDOps.Get(id);
            //if (item == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            if (item == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No Data found with ID = {0}", id)),
                    ReasonPhrase = "Data Not Found"
                };

                throw new HttpResponseException(response);
            }
            cRUDOps.Remove(id);
            return Request.CreateResponse(HttpStatusCode.OK, item); 
     
        }
    }
}