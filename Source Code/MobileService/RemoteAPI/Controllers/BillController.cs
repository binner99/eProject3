using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Data;
using RemoteAPI.Models;

namespace RemoteAPI.Controllers
{
    public class BillController : ApiController
    {
        private ConnectDatabase db = new ConnectDatabase();

        // GET: api/Bills
        public IQueryable<Bill> GetBills()
        {
            return db.Bills;
        }

        // GET: api/Bills/5
        [ResponseType(typeof(Bill))]
        public async Task<IHttpActionResult> GetBill(int id)
        {
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }
    }
}