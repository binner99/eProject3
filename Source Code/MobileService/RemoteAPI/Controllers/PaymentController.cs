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
    public class PaymentController : ApiController
    {
        private ConnectDatabase db = new ConnectDatabase();

        // GET: api/Payment
        public IQueryable<Payment> GetPayments()
        {
            return db.Payments;
        }

        // GET: api/Payment/5
        [ResponseType(typeof(Payment))]
        public async Task<IHttpActionResult> GetPayment(int id)
        {
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // PUT: api/Payment/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPayment(int id, Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.payID)
            {
                return BadRequest();
            }

            db.Entry(payment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payment
        [ResponseType(typeof(Payment))]
        public async Task<IHttpActionResult> PostPayment(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payments.Add(payment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = payment.payID }, payment);
        }

        // DELETE: api/Payment/5
        [ResponseType(typeof(Payment))]
        public async Task<IHttpActionResult> DeletePayment(int id)
        {
            Payment payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payment);
            await db.SaveChangesAsync();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentExists(int id)
        {
            return db.Payments.Count(e => e.payID == id) > 0;
        }
    }
}