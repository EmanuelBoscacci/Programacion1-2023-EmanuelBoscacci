using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Annotations;
using WAPISatelite.Helper;
using WAPISatelite.Models;

namespace prueba.Controllers
{

    //[ApiController]
    //[Route("[controller]")]
    //public class TopSecretController : ControllerBase
    //{


    [Produces("application/json")]
    [Route("api/topSecret")]
    public class TopSecretController : Controller
    {

            // POST api/topSecret
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.Created,
                        Description = "Calcula las coordenadas del objeto y el mensaje combinado que envian los Satelites",
                        Type = typeof(string))]
        [Route("api/TopSecret")]
        public IActionResult topSecret([FromBody] ListaSatelitesIn lSatelites)
        {
            if (!ModelState.IsValid)
            {
                
                return NotFound(ModelState);
            }
            else
            {

                InfoSateliteOut sat1o = new InfoSateliteOut();
                InfoSateliteOut sat2o = new InfoSateliteOut();
                InfoSateliteOut sat3o = new InfoSateliteOut();

                // Los mensajes y las distancias las leo 
                InfoSateliteIn Sat1 = new InfoSateliteIn();
                InfoSateliteIn Sat2 = new InfoSateliteIn();
                InfoSateliteIn Sat3 = new InfoSateliteIn();


                Sat1 = lSatelites.satellites[0];
                Sat2 = lSatelites.satellites[1];
                Sat3 = lSatelites.satellites[2];


               ListaSatelitesOut lsato = new ListaSatelitesOut();

                
             

                // Las coordenadas de los Satelites son Conocidas

                main ocontrollerppal = new main();

                mMensaje lomensaje = new mMensaje();

                string dist1 = Sat1.distance.ToString().Replace(',', '.');
                string dist2 = Sat2.distance.ToString().Replace(',', '.');
                string dist3 = Sat3.distance.ToString().Replace(',', '.');

                string msj1 = Sat1.message.Replace("“", "").Replace("”", "").Replace("[", "").Replace("]", "").Replace("\"", "");
                string msj2 = Sat2.message.Replace("“", "").Replace("”", "").Replace("[", "").Replace("]", "").Replace("\"", "");
                string msj3 = Sat3.message.Replace("“", "").Replace("”", "").Replace("[", "").Replace("]", "").Replace("\"", "");
                                             
                // Las coordenadas de los Satelites son Conocidas

                Coordenadas c1 = new Coordenadas();
                c1.X = -11;
                c1.Y = 8;

                Coordenadas c2 = new Coordenadas();
                c2.X = -1;
                c2.Y = 9;

                Coordenadas c3 = new Coordenadas();
                c3.X = -16;
                c3.Y = -4;

                sat1o.distancia = Double.Parse(dist1, CultureInfo.InvariantCulture);
                sat1o.nombre = Sat1.name;
                sat1o.mensaje = msj1;
                sat1o.ubicacion = c1;

                sat2o.distancia = Double.Parse(dist2, CultureInfo.InvariantCulture);
                sat2o.nombre = Sat2.name;
                sat2o.mensaje = msj2;
                sat2o.ubicacion = c2;

                sat3o.distancia = Double.Parse(dist3, CultureInfo.InvariantCulture);
                sat3o.nombre = Sat3.name;
                sat3o.mensaje = msj3;
                sat3o.ubicacion = c3;

                // Calculos

                lsato.Satelite1 = sat1o;
                lsato.Satelite2 = sat2o;
                lsato.Satelite3 = sat3o;

                lomensaje.mensaje = ocontrollerppal.GetMessage(lsato);


                if (lomensaje.mensaje == "False")
                {

                    return NotFound("No se pudo descifrar el Mensaje.");

                }

                Coordenadas posicion = ocontrollerppal.GetLocation(lsato);

                if (posicion.resultado == "False")
                {
                    return NotFound("No se pudo encontrar el objeto.");
                }

                lomensaje.ubicacion = Calculos.cCoordenadas.CoordAString(posicion.X, posicion.Y);
                return Ok(lomensaje);
              
            }

        }
    }
}
