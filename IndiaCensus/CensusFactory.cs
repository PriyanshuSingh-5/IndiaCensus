using System;
using System.Collections.Generic;
using IndiaCensus.DTO;
using IndiaCensus.DAO;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus
{
    class CensusFactory
    {
        // Declarations
        public Dictionary<FileType, CensusDTO> fileInstanceMap = new Dictionary<FileType, CensusDTO>();
       
       
        internal CensusDTO GetObject(FileType type)
        {
            if (fileInstanceMap.ContainsKey(type))
                return fileInstanceMap[type];
            if (type == FileType.INDIAN_STATE_CENSUS)
            {
                fileInstanceMap.Add(type, new IndianStateCensusDAO());
                return fileInstanceMap[type];
            }

            if (type == FileType.INDIAN_STATE_CODE)
            {
                fileInstanceMap.Add(type, new IndiaStateCodeDAO());
                return fileInstanceMap[type];
            }
            return null;
        }
    }
}


