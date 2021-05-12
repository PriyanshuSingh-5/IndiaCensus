using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus.DTO
{
    public abstract class CensusDTO : ILoadCsv
    {
        // All the variables related to all file types
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public double totalArea;
        public double waterArea;
        public double landArea;

       //loads csv paths
        public abstract Dictionary<string, CensusDTO> LoadCsv(string filePath);
    }
}

