using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHuevos3.Entidades;
using WebApiHuevos3.Filtros;
using WebApiHuevos3.Services;

namespace WebApiHuevos3.Controllers
{
    [ApiController]
    [Route("/encargados")]
    public class EncargadosController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ILogger<EncargadosController> logger;
        private readonly IWebHostEnvironment env;
        private readonly string nuevosRegistros = "nuevosRegistros.txt";
        private readonly string registrosConsultados = "registrosConsultados.txt";
        
        public EncargadosController(ApplicationDbContext context, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton, ILogger<EncargadosController> logger,
            IWebHostEnvironment env)
        {
            this.dbContext = context;
            this.service = service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.logger = logger;
            this.env = env;
        }

        [HttpGet("GUID")]
        [ResponseCache(Duration = 10)]
        [ServiceFilter(typeof(FiltroDeAccion))]
        public ActionResult ObtenerGuid()
        {
            throw new NotImplementedException();
            logger.LogInformation("Durante la ejecucion");
            return Ok(new
            {
                EncargadosControllerTransient = serviceTransient.guid,
                ServiceA_Transient = service.GetTransient(),
                EncargadosControllerScoped = serviceScoped.guid,
                ServiceA_Scoped = service.GetScoped(),
                EncargadosControllerSingleton = serviceSingleton.guid,
                ServiceA_Singleton = service.GetSingleton()
            });
        }

        [HttpGet]
        //[HttpGet("listado")]
        //[HttpGet("/listado")]
        public async Task<ActionResult<List<Encargado>>> GetEncargados()
        {
            throw new NotImplementedException();
            logger.LogInformation("Se obtiene el listado de encargados");
            logger.LogWarning("Mensaje de prueba warning");
            service.EjecutarJob();
            return await dbContext.Encargados.Include(x=>x.huevos).ToListAsync();
        }
        [HttpGet("primero")]
        public async Task<ActionResult<Encargado>> PrimerAutor([FromHeader] int valor, [FromQuery] string encargado, [FromQuery] int encargadoId)
        {
            return await dbContext.Encargados.FirstOrDefaultAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Encargado>> Get(int id)
        {
            var alumno = await dbContext.Encargados.FirstOrDefaultAsync(x => x.Id == id);
            if (alumno == null)
            {
                return BadRequest();
            }
            return alumno;
        }
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Encargado>> Get([FromRoute] string nombre)
        {
            var alumno = await dbContext.Encargados.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
            if (alumno == null)
            {
                logger.LogError("No se encuentra el alumno. ");
                return NotFound();
            }
            return alumno;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Encargado encargado)
        {
            var existeAlumnoMismoNombre = await dbContext.Encargados.AnyAsync(x => x.Nombre == encargado.Nombre);

            if (existeAlumnoMismoNombre)
            {
                return BadRequest("Ya existe un autor con el nombre. ");
            }
            dbContext.Add(encargado);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult>Put(Encargado encargado,int id)
        {
            if (encargado.Id != id)
            {
                return BadRequest("El id del encargado no coincide con el establecido en la url.");
            }

            dbContext.Update(encargado);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Encargados.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Encargado()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
