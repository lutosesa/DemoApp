﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoApp.Backend.Models;
using ModelApp.Common.Models;

namespace DemoApp.Backend.Controllers
{
    public class EmployeesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.District).Include(e => e.Region).Include(e => e.Section).Include(e => e.Title);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeFullName = employee.FullName;
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName");
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName");
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName");
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "JobTitle");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeID,EmployeeNumber,LastName,FirstName,TitleID,RegionID,SectionID,DistrictID,ManagerID,Phone,Mobil,Email,IsActive,Notes,ImagePath")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", employee.DistrictID);
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", employee.RegionID);
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", employee.SectionID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "JobTitle", employee.TitleID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeFullName = employee.FullName;
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", employee.DistrictID);
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", employee.RegionID);
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", employee.SectionID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "JobTitle", employee.TitleID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeID,EmployeeNumber,LastName,FirstName,TitleID,RegionID,SectionID,DistrictID,ManagerID,Phone,Mobil,Email,IsActive,Notes,ImagePath")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "DistrictName", employee.DistrictID);
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", employee.RegionID);
            ViewBag.SectionID = new SelectList(db.Sections, "SectionID", "SectionName", employee.SectionID);
            ViewBag.TitleID = new SelectList(db.Titles, "TitleID", "JobTitle", employee.TitleID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeFullName = employee.FullName;
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
