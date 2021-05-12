using System;
using System.Collections.Generic;
using IndiaCensus.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus
{
    
    // Interface to be implemented by DAO of all file classes
   
    internal interface ILoadCsv
    {
        Dictionary<string, CensusDTO> LoadCsv(string filePath);
    }
}
