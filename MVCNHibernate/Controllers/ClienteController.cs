using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCNHibernate.Models;
using NHibernate.Linq;

namespace MVCNHibernate.Controllers
{
    public class ClienteController : Controller
    {

        public ActionResult Index()
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var clientes = session.Query<Cliente>().ToList();
                return View(clientes);
            }
        }

        public ActionResult Details(int id = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var cliente = session.Get<Cliente>(id);
                return View(cliente);
            }
        }

        //
        // GET: /Associates/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Associates/Create
        [HttpPost]
        public ActionResult Create(Cliente cli)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(cli);
                    transaction.Commit();
                }
            }

            return View(cli);
        }

        //
        // GET: /Associates/Edit/5
        public ActionResult Edit(int id = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var cliente = session.Get<Cliente>(id);
                return View(cliente);
            }
        }

        //
        // POST: /Associates/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Cliente cli)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var cliente = session.Get<Cliente>(id);
                cliente.nome = cli.nome;
                cliente.email = cli.email;
                cliente.cpf = cli.cpf;
                cliente.telefone = cli.telefone;
               

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(cliente);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Associates/Delete/5
        public ActionResult Delete(int id = 0)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                var cliente = session.Get<Cliente>(id);
                return View(cliente);
            }
        }

        //
        // POST: /Associates/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, Cliente cli)
        {
            using (ISession session = OpenNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(cli);
                    transaction.Commit();
                }
            }
            return RedirectToAction("Index");
        }
	}
}