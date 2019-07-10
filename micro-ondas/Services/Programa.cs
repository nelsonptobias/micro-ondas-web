using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;

namespace micro_ondas.controllers
{
    public class Programa
    {

        private int time;
        private int power;
        private String program = "";
        private String useInstructions;
        private String charHeating = ".";
        private String messageHeat = "";
        public Boolean isFinished = false;

        public string CharHeating { get => charHeating; set => charHeating = value; }
        public string ProgramName { get => program; set => program = value; }

        public string UseInstructions { get => useInstructions; set => useInstructions = value; }

        public int Time {
            get
            {
                return time;
            }
            set
            {
                if (! IsValidTime(value))
                {
                    throw new TimeValueExcetpion("Tempo nao pode ser maior que 2 minutos (120 segundos) nem menor que 1 segundo");
                     
                }
                time = value;
            }
        }
        public int Power {
            get
            {
                return power;
            }
            set
            {
                if (! IsValidPower(value))
                {
                    throw new PowerValueExcetpion("Potencia nao pode ser maior que 10 nem menor que 1");
                }
                power = value;

            }
        }

        public string MessageHeat { get => messageHeat; set => messageHeat = value; }

        public String turnOn()
        {
            this.isFinished = false;
            String points = "";
            String powerPoints = this.getPowerPoints();
            for (int i = 0; i < this.Time; i++)
            {
                Thread.Sleep(1000);
                points += powerPoints;


            }
            points += "aquecida";
            this.isFinished = true;
            return points;
        }

        public void ThreadTurnOn()
        {
            this.MessageHeat = turnOn();
            Console.WriteLine(this.MessageHeat);
        }

        private string getPowerPoints()
        {
            switch (this.Power)
            {
                case 1:  return this.charHeating;
                case 2:  return this.charHeating + this.charHeating;
                case 3:  return this.charHeating + this.charHeating + this.charHeating;
                case 4:  return this.charHeating + this.charHeating + this.charHeating + this.charHeating;
                case 5:  return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating ;
                case 6:  return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating +
                                this.charHeating ;
                case 7:  return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating +
                                this.charHeating + this.charHeating ;
                case 8:  return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating +
                                this.charHeating + this.charHeating + this.charHeating ;
                case 9:  return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating +
                                this.charHeating + this.charHeating + this.charHeating + this.charHeating ;
                case 10: return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating +
                                this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating  ;
                default: return this.charHeating + this.charHeating + this.charHeating + this.charHeating + this.charHeating + 
                                this.charHeating + this.charHeating + this.charHeating ;


            }
        }

        public String print()
        {
            return "Nome : " + this.ProgramName + Environment.NewLine +
                   "Instrucao: " + this.useInstructions + Environment.NewLine +
                   "Tempo: " + this.Time + Environment.NewLine +
                   "Potencia: " + this.Power + Environment.NewLine;


        }

        private Boolean IsValidTime(int timeValue)
        {
            if (timeValue < 1 || timeValue > 121)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean IsValidPower(int timeValue)
        {
            if (timeValue < 1 || timeValue > 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


}
