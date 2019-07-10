using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using micro_ondas.controllers;
using micro_ondas.Services;
using Microsoft.AspNetCore.Mvc;

namespace micro_ondas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TurnOnController : ControllerBase

    {
        //se nao nomear como static, ele destroi o objeto no final  das interacoes
        public static Programa programaInstace;
        public static GenericPrograms programas;

        public Programa GetProgram()
        {
            if (programaInstace == null)
            {
                programaInstace = new Programa();
                return programaInstace;
            }
            return programaInstace;
        }


        public GenericPrograms GetPrograms()
        {
            if (programas == null)
            {
                programas = new GenericPrograms();
                return programas;
            }
            return programas;
        }
    

        [HttpGet]
        public JsonResult GetDefaultPrograms()
        {
            if (GetPrograms().ProgramList.Count == 0)
            {
                GetPrograms().ProgramList.Add(new Frango());
                GetPrograms().ProgramList.Add(new Carne());
                GetPrograms().ProgramList.Add(new Macarrao());
            }

            return new JsonResult(GetPrograms().ProgramList);
        }

        [HttpGet("turnonbyname")]
        public JsonResult GetTurnOnByname(string programName)
        {
            try
            {
                programaInstace = GetPrograms().searchByName(programName);
                Thread TurnOnCaller = new Thread(
                        new ThreadStart(programaInstace.ThreadTurnOn));

                TurnOnCaller.Start();

                Response resposta = new Response("Aquecimento do programa " + programName + " iniciado");
                return new JsonResult(resposta);
            }
            catch (Exception exc)
            {
                JsonResult error = new JsonResult(new ErrorResponse(exc.GetType().FullName, exc.Message));
                error.StatusCode = 500;
                return error;
            }

        }

        [HttpGet("programbyname")]
        public JsonResult GetProgramByname(string programName)
        {
            try
            {             
                return new JsonResult(GetPrograms().searchByName(programName));
            }
            catch(Exception exc)
            {
                JsonResult error = new JsonResult(new ErrorResponse(exc.GetType().FullName, exc.Message));
                error.StatusCode = 500;
                return error;
            }

        }

        [HttpGet("checkheat")]
        public JsonResult Getcheckheat()
        {
            if (GetProgram().isFinished)
            {
                return new JsonResult(new Response(GetProgram().MessageHeat));
            }
            return new JsonResult(new Response("Aquecendo..."));
        }


        [HttpGet("params")]
        public JsonResult Get(int time, int power)
        {
            try
            {
                if (time == 0 && power == 0)
                {
                    GetProgram().Time = 30;
                    GetProgram().Power = 8;
                }
                else
                {
                    GetProgram().Time = time;
                    GetProgram().Power = power;

                }


                Thread TurnOnCaller = new Thread(
                new ThreadStart(GetProgram().ThreadTurnOn));

                TurnOnCaller.Start();

                Response resposta = new Response("Aquecimento iniciado");
                return new JsonResult(resposta);
            }
            catch (Exception exc)
            {
                JsonResult error = new JsonResult(new ErrorResponse(exc.GetType().FullName, exc.Message));
                error.StatusCode = 500;
                return error;
            }


        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]Programa customProgram)
        {
            try
            {
                GetPrograms().ProgramList.Add(new ProgramaGenerico(customProgram.Time,
                                                                   customProgram.Power,
                                                                   customProgram.ProgramName,
                                                                   customProgram.UseInstructions,
                                                                   customProgram.CharHeating));
                return new JsonResult(new Response("Programa adicionado"));
            }
            catch (Exception exc)
            {
                JsonResult error = new JsonResult(new ErrorResponse(exc.GetType().FullName, exc.Message));
                error.StatusCode = 500;
                return error;
            }
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //todo
        }

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //todo
        }
    }
}
