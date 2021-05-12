using System;
using System.Collections.Generic;
using System.IO;
using IndiaCensus.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus
{
    internal class CSVCensusAdaptor
    {
        // Dictionary initialisation
        public Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();

        
        
       //checks for csv file existance
        public Dictionary<string, CensusDTO> LoadCsv(FileType type, string path, string dataheaders)
        {
            // If the path doesnt exist
            if (!File.Exists(path))
                throw new CensusAnalyserException("The specified file doesnt exist", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);

            // If the extension of file is wrong
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyserException("The specified file extension doesnt exist", CensusAnalyserException.ExceptionType.EXTENSION_NOT_FOUND);

            // If the dataheaders doesnt match with file
            using (StreamReader stream = new StreamReader(path))
            {
                if (stream.ReadLine() != dataheaders)
                    throw new CensusAnalyserException("Data headers doesnt match", CensusAnalyserException.ExceptionType.HEADERS_MISMATCH);

            };

            // Get the object of DAO accort=ding to type of file
            var census = new CensusFactory().GetObject(type);

            // Return the dictionary after loading csv file
            return census.LoadCsv(path);
        }
    }
}
