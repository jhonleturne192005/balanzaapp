using Newtonsoft.Json.Linq;
using SimpleHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //libreria simple-http
    internal class csAPI 
    {
        Action aumentar;
        Action disminuir;
        Action tara;

        public csAPI(Action aumentar, Action disminuir, Action tara) {
            Console.WriteLine("csapi");
            this.aumentar = aumentar;
            this.disminuir = disminuir;
            this.tara = tara;
            init();
        }

        public void init()
        {
            JObject jo = new JObject();
            jo.Add("message", "Accion realizada correctamente");

            Route.Add("/prueba", (req, res, props) =>
            {
                Console.WriteLine("ruta de prueba");
                res.AsText("Library simple-http");
            }, "GET");

            Route.Add("/aum", (req, res, props) =>
            {
                Console.WriteLine("ruta de aumentar");
                aumentar();
                res.AsText(jo.ToString());
            }, "GET");


            Route.Add("/des", (req, res, props) =>
            {
                Console.WriteLine("ruta de aumentar");
                disminuir();
                res.AsText(jo.ToString());
            }, "GET");

            Route.Add("/tara", (req, res, props) =>
            {
                Console.WriteLine("ruta de aumentar");
                tara();
                res.AsText(jo.ToString());
            }, "GET");

            Task.Run(() => HttpServer.ListenAsync(6000, CancellationToken.None, Route.OnHttpRequestAsync));
            Console.WriteLine("Servidor corriendo en http://localhost:6000");

        }
    }
}
