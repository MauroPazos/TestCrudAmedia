using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using TestCrudAmedia.Helpers;
using TestCrudAmedia.Models;
using TestCrudAmedia.Models.DB;

namespace TestCrudAmedia.Controllers
{
    public class CuentaController : Controller
    {
        private TestCrudContext db;

        public CuentaController()
        {
            db = new TestCrudContext();
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TestCrudContext db = new TestCrudContext();

                    TUsers user = db.TUsers.FirstOrDefault(c => c.TxtUser.ToUpper() == model.user.ToUpper());
                    if (user != null)
                    {
                        if (user.SnActivo == -1)
                        {
                            if (model.pass.Equals(user.TxtPassword))
                            {
                                var claims = new List<Claim>
                            {
                                new Claim(TablaGeneral.CustomClaimIdentity.Nombre.ToString(), user.TxtNombre),
                                new Claim(TablaGeneral.CustomClaimIdentity.Apellido.ToString(), user.TxtApellido),
                                new Claim(TablaGeneral.CustomClaimIdentity.CuentaID.ToString(), user.CodUsuario.ToString()),
                                new Claim(ClaimTypes.Name, user.TxtUser)
                            };

                                var identity = new ClaimsPrincipal(new ClaimsIdentity(claims, "CookieAuth"));



                                await HttpContext.SignInAsync("CookieAuth", identity);

                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("Pass", "La contraseña ingresada no es correcta.");
                                ModelState.AddModelError("Pass", "La contraseña ingresada no es correcta.");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("User", "Este usuario ya no está activo.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("User", "No existe este usuario.");
                    }
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Ocurrió un problema, por favor reintente más tarde.");
            }

            return View("Login", model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login", "Cuenta");

        }

        [Authorize]
        public IActionResult ABMUsuarios()
        {
            if (Helper.tienePermiso(User.Identity.Name, TablaGeneral.RolesUsuario.Admin))
            {
                ABMUsuarios model = new ABMUsuarios();
                model.users = db.TUsers.Where(u => u.SnActivo == -1).ToList(); //-1 Cuentas activas
                return View("ABMUsuarios", model);
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpPost]
        public IActionResult BajaUsuarioInterno(int usuarioID)
        {
            if (Helper.tienePermiso(User.Identity.Name, TablaGeneral.RolesUsuario.Admin))
            {
                TUsers cuenta = db.TUsers.Find(usuarioID);
                cuenta.SnActivo = 1;

                db.Entry(cuenta).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ABMUsuarios", "Cuenta");
        }

        [HttpGet, Authorize]
        public IActionResult AltaModificacionUsuario(int? usuarioID)
        {
            UsuarioModel model = new UsuarioModel();

            if (usuarioID != null)
            {
                TUsers cuenta = db.TUsers.Find(usuarioID);

                if (cuenta != null)
                {
                    model.TxtNombre = cuenta.TxtNombre;
                    model.TxtApellido = cuenta.TxtApellido;
                    model.NroDoc = cuenta.NroDoc;
                    model.TxtUser = cuenta.TxtUser;
                    model.TxtPassword = cuenta.TxtPassword;
                    model.CodRol = cuenta.CodRol;
                    model.CodUsuario = cuenta.CodUsuario;
                    model.accion = TablaGeneral.Acciones.MODIFICACION;
                }
            }
            else
            {
                int cod = db.TUsers.OrderByDescending(e => e.CodUsuario).FirstOrDefault().CodUsuario;
                model.CodUsuario = cod++;
                model.accion = TablaGeneral.Acciones.ALTA;
            }

            return PartialView(model);
        }

        [HttpPost, Authorize]
        public ActionResult AltaModificacionUsuario(UsuarioModel model)
        {

            if (model.accion.Equals(TablaGeneral.Acciones.ALTA)) //Nuevo usuario
            {
                if (ModelState.IsValid)
                {
                    //Solo se crea si no hay usuarios con el mismo NroDoc o User
                    if (!db.TUsers.Any(c => (c.NroDoc == model.NroDoc || c.TxtUser == model.TxtUser)))
                    {

                        TUsers user = new TUsers
                        {
                            TxtUser = model.TxtUser,
                            TxtNombre = model.TxtNombre,
                            TxtApellido = model.TxtApellido,
                            CodRol = model.CodRol,
                            TxtPassword = model.TxtPassword,
                            NroDoc = model.NroDoc,
                            SnActivo = -1
                        };

                        db.TUsers.Add(user);
                        db.SaveChanges();

                        return RedirectToAction("ABMUsuarios", "Cuenta");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un usuario registrado con esa direccion de mail.");
                    }
                }
            }
            else // Edicion
            {

                TUsers user = db.TUsers.Find(model.CodUsuario);

                if (user != null)
                {
                    user.TxtUser = model.TxtUser;
                    user.TxtNombre = model.TxtNombre;
                    user.TxtApellido = model.TxtApellido;
                    user.CodRol = model.CodRol;
                    user.TxtPassword = model.TxtPassword;
                    user.NroDoc = model.NroDoc;
                    user.SnActivo = -1;
                }

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ABMUsuarios", "Cuenta");

            }

            return PartialView(model);


        }


    }
}

