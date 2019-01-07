﻿using System;
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

        // PUT: api/Bills/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBill(int id, Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.billID)
            {
                return BadRequest();
            }

            db.Entry(bill).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bills
        [ResponseType(typeof(Bill))]
        public async Task<IHttpActionResult> PostBill(Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bills.Add(bill);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bill.billID }, bill);
        }

        // DELETE: api/Bills/5
        [ResponseType(typeof(Bill))]
        public async Task<IHttpActionResult> DeleteBill(int id)
        {
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            db.Bills.Remove(bill);
            await db.SaveChangesAsync();

            return Ok(bill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BillExists(int id)
        {
            return db.Bills.Count(e => e.billID == id) > 0;
        }
    }
}