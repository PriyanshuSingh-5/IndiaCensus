using System;
using System.Collections.Generic;
using System.Linq;
using IndiaCensus.DAO;
using IndiaCensus.DTO;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus.DAO
{
    public class IndiaStateCodeDAO : CensusDTO
    {
        CensusDTO census;
        public Dictionary<string, CensusDTO> dataMap = new Dictionary<string, CensusDTO>();

        public IndiaStateCodeDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }

       
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
                census = new IndiaStateCodeDAO(column[0], column[1], column[2], column[3]);
                dataMap.Add(column[0], census);
            }
            return dataMap;
        }
    }
}

