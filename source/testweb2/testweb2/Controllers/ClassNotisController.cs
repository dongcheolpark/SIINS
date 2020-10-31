using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using testweb2.Models;

namespace testweb2.Controllers
{
    /*
    이 컨트롤러에 대한 경로를 추가하려면 WebApiConfig 클래스를 추가로 변경해야 할 수 있습니다. 가능한 경우 WebApiConfig 클래스의 Register 메서드에 이 문을 병합합니다. OData URL은 대/소문자를 구분합니다.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using testweb2.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ClassNoti>("ClassNotis");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ClassNotisController : ODataController
    {
        private ClassNotiDBcontext db = new ClassNotiDBcontext();

        // GET: odata/ClassNotis
        [EnableQuery]
        public IQueryable<ClassNoti> GetClassNotis()
        {
            return db.ClassNotis;
        }

        // GET: odata/ClassNotis(5)
        [EnableQuery]
        public SingleResult<ClassNoti> GetClassNoti([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClassNotis.Where(classNoti => classNoti.key == key));
        }

        // PUT: odata/ClassNotis(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ClassNoti> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClassNoti classNoti = db.ClassNotis.Find(key);
            if (classNoti == null)
            {
                return NotFound();
            }

            patch.Put(classNoti);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassNotiExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(classNoti);
        }

        // POST: odata/ClassNotis
        public IHttpActionResult Post(ClassNoti classNoti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassNotis.Add(classNoti);
            db.SaveChanges();

            return Created(classNoti);
        }

        // PATCH: odata/ClassNotis(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ClassNoti> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClassNoti classNoti = db.ClassNotis.Find(key);
            if (classNoti == null)
            {
                return NotFound();
            }

            patch.Patch(classNoti);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassNotiExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(classNoti);
        }

        // DELETE: odata/ClassNotis(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ClassNoti classNoti = db.ClassNotis.Find(key);
            if (classNoti == null)
            {
                return NotFound();
            }

            db.ClassNotis.Remove(classNoti);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassNotiExists(int key)
        {
            return db.ClassNotis.Count(e => e.key == key) > 0;
        }
    }
}
