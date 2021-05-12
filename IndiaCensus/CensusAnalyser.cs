using System;
using System.Collections.Generic;
using IndiaCensus.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus
{
    
    // Different types of files
    
    public enum FileType
    {
        INDIAN_STATE_CENSUS
    }

    public class CensusAnalyser
    {
        public Dictionary<string, CensusDTO> LoadCsvFile(FileType type, string filePath, string dataheaders)
        {
            return new CSVCensusAdaptor().LoadCsv(type, filePath, dataheaders);
        }
    }
}

