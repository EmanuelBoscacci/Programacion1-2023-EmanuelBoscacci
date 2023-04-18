using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAPISatelite.Models;

namespace WAPISatelite.Helper
{
    public class main
    {
       


        public string GetMessage(ListaSatelitesOut listaS)
        {

            string lomensaje = "";

            String lmsjCombinado;
            String lSubmsj;
            String lMsjVacio;

            int longMsj1;
            int longMsj2;
            int longMsj3;

            int DesfasajeMsj1;
            int DesfasajeMsj2;
            int DesfasajeMsj3;

            int posicionPrimerPalabra;
            int posicionPrimerPalabra1;
            int posicionPrimerPalabra2;
            int posicionPrimerPalabra3;
            int maxcant;
            int minposicion;

            //int satelitePrimerPalabra;

            int cantpalabras;
            int cantpalabras1;
            int cantpalabras2;
            int cantpalabras3;
            string[] lmsj1;
            string[] lmsj2;
            string[] lmsj3;

            string PrimerPalabraMsj1;
            string PrimerPalabraMsj2;
            string PrimerPalabraMsj3;

            string primerPalabra;

            maxcant = 0;
            minposicion = 0;
            cantpalabras = 0;
            cantpalabras1 = 0;
            cantpalabras2 = 0;
            cantpalabras3 = 0;

            lMsjVacio = " ";

            DesfasajeMsj1 = 0;
            DesfasajeMsj2 = 0;
            DesfasajeMsj3 = 0;
            primerPalabra = "";
            posicionPrimerPalabra = 0;
            posicionPrimerPalabra1 = -1;
            posicionPrimerPalabra2 = -1;
            posicionPrimerPalabra3 = -1;


            PrimerPalabraMsj1 = "";
            PrimerPalabraMsj2 = "";
            PrimerPalabraMsj3 = "";
            lSubmsj = "";

            try
            {

                lmsj1 = listaS.Satelite1.mensaje.Split(',');
                longMsj1 = lmsj1.Length;

                lmsj2 = listaS.Satelite2.mensaje.Split(',');
                longMsj2 = lmsj2.Length;

                lmsj3 = listaS.Satelite3.mensaje.Split(',');
                longMsj3 = lmsj3.Length;

                // Averiguar la primer palabra de cada satelite

                var j = 0;
                bool lencuentra;
                lencuentra = false;
                while (lencuentra == false && j <= (longMsj1 - 1))
                {
                    if (!string.IsNullOrEmpty(lmsj1[j].Trim()) && lmsj1[j].Trim() != lMsjVacio)
                    {
                        PrimerPalabraMsj1 = lmsj1[j].Trim();
                        posicionPrimerPalabra1 = j;
                        lencuentra = true;
                        cantpalabras1 = longMsj1 - j;
                    }

                    j += 1;
                }

                lencuentra = false;
                j = 0;
                while (lencuentra == false && j <= (longMsj2 - 1))
                {
                    if (!string.IsNullOrEmpty(lmsj2[j].Trim()) && lmsj2[j].Trim() != lMsjVacio)
                    {

                        PrimerPalabraMsj2 = lmsj2[j].Trim();
                        posicionPrimerPalabra2 = j;
                        cantpalabras2 = longMsj2 - j;
                        lencuentra = true;
                    }

                    j += 1;
                }



                lencuentra = false;
                j = 0;
                while (lencuentra == false && j <= (longMsj3 - 1))
                {
                    if (!string.IsNullOrEmpty(lmsj3[j].Trim()) && lmsj3[j].Trim() != lMsjVacio)
                    {

                        PrimerPalabraMsj3 = lmsj3[j].Trim();
                        posicionPrimerPalabra3 = j;
                        cantpalabras3 = longMsj3 - j;
                        lencuentra = true;
                    }

                    j += 1;
                }



                // Calcular la cantidad maxima de palabras en los tres mensajes
                // Y si hay varios con el máximo miro que mensaje empieza primero.

                maxcant = Math.Max(cantpalabras1, cantpalabras2);
                maxcant = Math.Max(maxcant, cantpalabras3);
                minposicion = 1000000;

                if (cantpalabras1 == maxcant && posicionPrimerPalabra1 >= 0)
                {
                    minposicion = Math.Min(posicionPrimerPalabra1, minposicion);
                }
                if (cantpalabras2 == maxcant && posicionPrimerPalabra2 >= 0)
                {
                    minposicion = Math.Min(posicionPrimerPalabra2, minposicion);
                }
                if (cantpalabras3 == maxcant && posicionPrimerPalabra3 >= 0)
                {
                    minposicion = Math.Min(posicionPrimerPalabra3, minposicion);
                }


                // Si la posicion de la primer palabra no es la 0, entonces hay un desfasaje

                if (posicionPrimerPalabra1 == minposicion && posicionPrimerPalabra1 >= 0)
                {
                    posicionPrimerPalabra = posicionPrimerPalabra1;
                    cantpalabras = cantpalabras1;
                    primerPalabra = PrimerPalabraMsj1;
                }



                if (posicionPrimerPalabra2 == minposicion && posicionPrimerPalabra2 >= 0)
                {
                    posicionPrimerPalabra = posicionPrimerPalabra2;
                    cantpalabras = cantpalabras2;
                    primerPalabra = PrimerPalabraMsj2;
                }


                if (posicionPrimerPalabra3 == minposicion && posicionPrimerPalabra3 >= 0)
                {
                    posicionPrimerPalabra = posicionPrimerPalabra3;
                    cantpalabras = cantpalabras3;
                    primerPalabra = PrimerPalabraMsj3;
                }

                // Concateno la primer palabra al mensaje
                lmsjCombinado = primerPalabra;


                // Y calculo el desfasaje, con la cantidad de palabras que tiene cada mensaje, 
                // menos la cantidad del mensaje que encontre (cantpalabras),
                // el resto, deben ser desfasajes


                DesfasajeMsj1 = longMsj1 > cantpalabras ? longMsj1 - cantpalabras : 0;
                DesfasajeMsj2 = longMsj2 > cantpalabras ? longMsj2 - cantpalabras : 0;
                DesfasajeMsj3 = longMsj3 > cantpalabras ? longMsj3 - cantpalabras : 0;


               

                lencuentra = false;

                // A partir de la posición del desfasaje, tengo que seguir buscando las palabras.
                // Como la primer palabra ya la encontre, tengo que buscar la segunda, y el desfasaje es en cantidad,
                // No como los subindices en base cero, asique no tengo que restar nada, 
                // empiezo a buscar desde la posición del desfasaje

                int i = 0;
                while (i < (cantpalabras - 1))
                {
                    lSubmsj = "";
                    lencuentra = false;

                    DesfasajeMsj1 = DesfasajeMsj1 + 1;
                    if (lencuentra == false && DesfasajeMsj1 <= longMsj1)
                    {
                        if (!string.IsNullOrEmpty(lmsj1[DesfasajeMsj1].Trim()) && lmsj1[DesfasajeMsj1].Trim() != lMsjVacio)
                        {
                            lSubmsj = lmsj1[DesfasajeMsj1].Trim();
                            lencuentra = true;
                        }
                    }


                    DesfasajeMsj2 = DesfasajeMsj2 + 1;
                    if (lencuentra == false && DesfasajeMsj2 <= longMsj2)
                    {
                        if (!string.IsNullOrEmpty(lmsj2[DesfasajeMsj2].Trim()) && lmsj2[DesfasajeMsj2].Trim() != lMsjVacio)
                        {
                            lSubmsj = lmsj2[DesfasajeMsj2].Trim();
                            lencuentra = true;

                        }
                    }


                    DesfasajeMsj3 = DesfasajeMsj3 + 1;
                    if (lencuentra == false && DesfasajeMsj3 <= longMsj3)
                    {

                        if (!string.IsNullOrEmpty(lmsj3[DesfasajeMsj3].Trim()) && lmsj3[DesfasajeMsj3].Trim() != lMsjVacio)
                        {
                            lSubmsj = lmsj3[DesfasajeMsj3].Trim();
                            lencuentra = true;
                        }
                    }


                    if (lSubmsj != "")
                    {
                        lmsjCombinado = lmsjCombinado + " " + lSubmsj.Trim();
                    }
                    else
                    {
                        lmsjCombinado = lmsjCombinado + " ";
                    }

                    i += 1;

                }

                // Termina de recorrer los mensajes, limpio todo por si quiere probar con otro


                lSubmsj = "";
                lMsjVacio = "";
                primerPalabra = "";
                PrimerPalabraMsj1 = "";
                PrimerPalabraMsj2 = "";
                PrimerPalabraMsj3 = "";


                DesfasajeMsj1 = 0;
                DesfasajeMsj2 = 0;
                DesfasajeMsj3 = 0;

                posicionPrimerPalabra = 0;
                posicionPrimerPalabra1 = -1;
                posicionPrimerPalabra2 = -1;
                posicionPrimerPalabra3 = -1;
                longMsj1 = 0;
                longMsj2 = 0;
                longMsj3 = 0;

                cantpalabras = 0;

                cantpalabras1 = 0;
                cantpalabras2 = 0;
                cantpalabras3 = 0;

                lmsj1 = null;
                lmsj2 = null;
                lmsj3 = null;


            }
            catch
            {

                lmsjCombinado = "False";
                return lomensaje;
            }



            lomensaje = lmsjCombinado;


            return lomensaje;

        }




        public Coordenadas GetLocation(ListaSatelitesOut listaS)
        {




            //Este es el valor conocido para cada fórmula:
            //a=  cuadrado(x1) + cuadrado(y1) + cuadrado(d1)
            // b=  cuadrado(x2) + cuadrado(y2) + cuadrado(d2)
            // c = cuadrado(x3) + cuadrado(y3) + cuadrado(d3)

            var P = new Coordenadas();

            double interseccionA_Bx;
            double interseccionA_By;
            double interseccionA_Bi;
            double Ejeradicalx;
            double Ejeradicali;
            double puntoXcua;
            double puntoX;
            double puntoi;
            double solucionX1;
            double solucionX2;
            double solucionY1;
            double solucionY2;
            double prueba1;
            double prueba2;

            interseccionA_Bx = 0.00;
            interseccionA_By = 0.00;
            interseccionA_Bi = 0.00;
            Ejeradicali = 0.00;
            Ejeradicalx = 0.00;
            puntoXcua = 0.00;
            puntoi = 0.00;
            puntoX = 0.00;
            solucionX1 = 0.00;
            solucionX2 = 0.00;
            solucionY1 = 0.00;
            solucionY2 = 0.00;
            prueba1 = 0.00;
            prueba2 = 0.00;

            try
            {
                var a = Calculos.TerminoIndependiente(listaS.Satelite1.ubicacion.X, listaS.Satelite1.ubicacion.Y, listaS.Satelite1.distancia);
                var b = Calculos.TerminoIndependiente(listaS.Satelite2.ubicacion.X, listaS.Satelite2.ubicacion.Y, listaS.Satelite2.distancia);
                var c = Calculos.TerminoIndependiente(listaS.Satelite3.ubicacion.X, listaS.Satelite3.ubicacion.Y, listaS.Satelite3.distancia);

                //Intersecto la primer circunferencia con la segunda

                interseccionA_Bx = -(2 * listaS.Satelite1.ubicacion.X) + (2 * listaS.Satelite2.ubicacion.X);
                interseccionA_By = -(2 * listaS.Satelite1.ubicacion.Y) + (2 * listaS.Satelite2.ubicacion.Y);
                // interseccionA_Bi = Math.Pow((-S1.ubicacion.X),2) + Math.Pow(S2.ubicacion.X,2) + Math.Pow((-S1.ubicacion.Y),2) + Math.Pow(S2.ubicacion.Y,2) + Math.Pow((-S1.distancia.Value),2) + Math.Pow(S2.distancia.Value,2);
                interseccionA_Bi = a - b;

                //Para sacar la Y del eje radical, hago:
                // Y = (- x - i) / valor de y. Tengo que hacer por -1 porque pasa restando del otro lado

                Ejeradicalx = (interseccionA_Bx / interseccionA_By) * -1;
                Ejeradicali = (interseccionA_Bi / interseccionA_By) * -1;

                // Calculo los dos puntos de interseccion entre la recta radical y las circunferencias A y B

                // Interseccion del eje radical con una circunf. en este caso la A.
                //Para ello reemplazo Y en la circunferencia A

                // La circunferencia A = X ´2 + y ´2 - 2 x1 * x - 2 y1 * y + a = 0
                // La recta radical = Y = Ejeradicalx  + Ejeradicali


                // puntoXcua = -1 + Math.Pow(Ejeradicalx, 2);
                puntoXcua = 1 + Math.Pow(Ejeradicalx, 2);
                puntoX = (2 * Ejeradicalx * Ejeradicali) - (2 * listaS.Satelite1.ubicacion.X) - (2 * listaS.Satelite1.ubicacion.Y * Ejeradicalx);
                // puntoi = Math.Pow(Ejeradicali, 2) + Math.Pow(interseccionA_Bi,2) - (2 * S1.ubicacion.Y * Ejeradicali) + a;
                puntoi = Math.Pow(Ejeradicali, 2) - (2 * listaS.Satelite1.ubicacion.Y * Ejeradicali) + a;


                // Para sacar los puntos solucion debo hacer
                // X = (- b +- raiz(b^2 -4ac)) 2a


                solucionX1 = Math.Round((-puntoX + (Math.Sqrt((Math.Pow(puntoX, 2) - (4 * puntoXcua * puntoi))))) / (2 * puntoXcua), 2);
                solucionX2 = Math.Round((-puntoX - (Math.Sqrt((Math.Pow(puntoX, 2) - (4 * puntoXcua * puntoi))))) / (2 * puntoXcua), 2);

                // Reemplazo estos posibles valores de X en la recta radical
                solucionY1 = Math.Round((Ejeradicalx * solucionX1) + Ejeradicali, 2);
                solucionY2 = Math.Round((Ejeradicalx * solucionX2) + Ejeradicali, 2);

                // Ahora reemplazo estos dos puntos en la circunferencia C, para sacar el punto de interseccion de las 3

                prueba1 = Math.Pow(solucionX1, 2) + Math.Pow(solucionY1, 2) - (2 * listaS.Satelite3.ubicacion.X * solucionX1) - (2 * listaS.Satelite3.ubicacion.Y * solucionY1) + c;

                prueba2 = Math.Pow(solucionX2, 2) + Math.Pow(solucionY2, 2) - (2 * listaS.Satelite3.ubicacion.X * solucionX2) - (2 * listaS.Satelite3.ubicacion.Y * solucionY2) + c;

                if (Math.Floor(prueba1) == 0)
                {
                    P.X = solucionX1;
                    P.Y = solucionY1;
                }
                else
                {
                    P.X = solucionX2;
                    P.Y = solucionY2;
                }

            }
            catch (Exception ex)
            {

                P.resultado = "False";
                return P;
            }


            return P;



        }



    }





}
