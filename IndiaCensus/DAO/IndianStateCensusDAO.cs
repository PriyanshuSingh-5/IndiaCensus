using System;
using System.Collections.Generic;
using System.Linq;
using IndiaCensus.DTO;
using System.IO;
using IndiaCensus.DAO;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus.DAO
{
    class IndianStateCensusDAO : CensusDTO
    {
        // Variable declarations
        CensusDTO census;
        public Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();


        //initialize new instances
        public IndianStateCensusDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }

       //load csv files
        public override Dictionary<string, CensusDTO> LoadCsv(string path)
        {
            // Read the file and add each instance to dictionary
            foreach (string line in File.ReadLines(path).Skip(1))
            {
                if (!line.Contains(","))
                {
                    throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
                }
                string[] column = line.Split(",");
                census = new IndianStateCensusDAO(column[0], column[1], column[2], column[3]);
                dataMap.Add(column[0], census);
            }
            return dataMap;
        }
    }
}

