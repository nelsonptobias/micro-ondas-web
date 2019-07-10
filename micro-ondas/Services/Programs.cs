using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace micro_ondas.controllers
{
    public class GenericPrograms
    {

        List<Programa> programList = new List<Programa>();

        public List<Programa> ProgramList { get => programList; set => programList = value; }

        internal Programa searchByName(string text)
        {
            Programa programaBuscado = ProgramList.Find(p => p.ProgramName == text);
            if (programaBuscado == null)
            {
                throw new ProgramNotFoudException("Nenhum programa encontrado para: " + text);
            }
            return ProgramList.Find(p => p.ProgramName == text);
        }
    }
}
