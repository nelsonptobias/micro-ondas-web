using micro_ondas.controllers;
using System;

namespace micro_ondas
{
    internal class Carne : Programa
    {


        public Carne()
        {
            this.ProgramName = "carne";
            this.Time = 7;
            this.Power = 5;
            this.UseInstructions = "instrucao de como enquentar sua carne";
            this.CharHeating = "#";
        }


    }
}