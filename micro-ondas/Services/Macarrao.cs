using micro_ondas.controllers;
using System;

namespace micro_ondas
{
    internal class Macarrao : Programa
    {

        public Macarrao()
        {
            this.ProgramName = "macarrao";
            this.Time = 30;
            this.Power = 6;
            this.UseInstructions = "instrucao de como enquentar seu miojo";
            this.CharHeating = "@";
        }
    }
}