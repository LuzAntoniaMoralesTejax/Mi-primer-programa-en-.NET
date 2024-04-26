using Microsoft.AspNetCore.Mvc;
using Proyecto.ContextBD;
using Proyecto.Models;
using System.Diagnostics;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonaDB personaDB = new PersonaDB(); //otra opcion de pasar data a una vista <!---->
        private readonly InfoDB infoDB = new InfoDB();          //InfoDB
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX CREACION DE UNA VISTA RAZON XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX MODELS --> TABLA PERSONA E INFORMACION XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXX VISTA LISTAR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        public IActionResult ListarRegistros()  //LISTAR REGISTROS
        {
            List<Persona> personas = personaDB.ListarTodosRegistros();
            return View(personas);
        }
        //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        public IActionResult ListarInformacion() //LISTAR INFORMACION
        {
            List<Info> info = infoDB.ListarInformacion();
            return View(info);
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX CREACION DE UNA VISTA RAZON XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX MODELS --> TABLA PERSONA E INFORMACION XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXX VISTA CREAR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        public IActionResult Crear() // CREAR DE LA TABLA PERSONA
        {
            return View(); 
        }

        public IActionResult Guardar(Persona model) // METODO GUARDAR DE LA TABLA PERSONA
        {
            if (ModelState.IsValid) //si el estado del modelo es valido
            {
                personaDB.Guardar(model);
            }
            return RedirectToAction("ListarRegistros"); //redirecciona a la accion listar registros
        }
        //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
        public IActionResult CrearInfo() //CREAR DE LA TABLA INFORMACION
        {
            return View();
        }

        public IActionResult GuardarInfo(Info model)  //opcion guardar --> Esta en la vista de Crear
        {
            if (ModelState.IsValid) //si el estado del modelo es valido
            {
                infoDB.GuardarInfo(model);
            }
            return RedirectToAction("ListarRegistros"); //redirecciona a la accion listar registros
        }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX CREACION DE UNA VISTA RAZON XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX MODELS --> TABLA PERSONA E INFORMACION XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXX REGION PARA EDITAR Y LISTAR DETALLE XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXX VISTA DETALLE XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        public IActionResult Detalle(int id) //DETALLE DE LA TABLA PERSONA
        {   //crear la variable
            Persona persona = personaDB.ObtenerPersona(id); //Lee los datos de la BD en detalle
            return View(persona);
        }

        public IActionResult DetalleInfo(int id) //DETALLE DE LA TABLA PERSONA
        {
            Info informacion = infoDB.ObtenerInfo(id); //Lee los datos de la BD en detalle
            return View(informacion);
        }
        
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX CREACION DE UNA VISTA RAZON XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX MODELS --> TABLA PERSONA E INFORMACION XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //XXXXXXXXXXXXXXXXX VISTA EDITAR XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //VISTA RAZON EDITAR
        public IActionResult Editar(int id) //xx EDITAR DE LA TABLA PERSONA
        {//*Enviar los valores directamente a la vista*
            return View(personaDB.ObtenerPersona(id));
        }
        
        public IActionResult Update(Persona persona)//xx ACTUALIZAR PERSONA
        {
            personaDB.Actualizar(persona);
            return RedirectToAction("ListarRegistros");
        }
         
        public IActionResult Eliminar(int id) //XX ELIMINAR PERSONA
        {
            personaDB.Eliminar(id);
            return RedirectToAction("ListarRegistros");
        }

        //CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

        public IActionResult EditarInfo(int id) //xx EDITAR DE LA TABLA INFORMACION
        {
            return View(infoDB.ObtenerInfo(id));
        }

        public IActionResult UpdateInfo(Info informacion)//xx ACTUALIZAR INFORMACION
        {
            infoDB.ActualizarInfo(informacion);
            return RedirectToAction("ListarInformacion");
        }

        public IActionResult EliminarInfo(int id) //XX ELIMINAR INFORMACION
        {
            infoDB.EliminarInfo(id);
            return RedirectToAction("ListarInformacion");
        }
    }
}


