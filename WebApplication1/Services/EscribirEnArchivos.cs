﻿using Microsoft.AspNetCore.Mvc;
using WebApiHuevos3.Controllers;
using WebApiHuevos3.Entidades;

namespace WebApiHuevos3.Services
{
    public class EscribirEnArchivo : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nombreArchivo = "Grupo777.txt";
        private Timer timer;
        public EscribirEnArchivo(IWebHostEnvironment env)
        {
            this.env = env;

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Se ejecuta cuando cargamos la aplicacion 1 vez
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(20));
            Escribir("Proceso Iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Se ejecuta cuando detenemos la aplicacion aunque puede que no se ejecute por algun error. 
            timer.Dispose();
            Escribir("Proceso Finalizado");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Escribir("Proceso en ejecucion: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
            //GuardarAlumnos();
        }
        private void Escribir(string msg)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArchivo}";

            using (StreamWriter writer = new StreamWriter(ruta, append: true)) { writer.WriteLine(msg); }
        }

        private void GuardarAlumnos()
        {
            //var ruta = $@"{env.ContentRootPath}\wwwroot\{archivo}";
            //ActionResult task = alumnosController.ObtenerGuid();
            //object Alumno = task.Result.Value;
            //using (StreamWriter writer = new StreamWriter(ruta, append: true)) { writer.WriteLine(Alumno); }
        }
    }
}
