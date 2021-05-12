using System;
using System.Collections.Generic;
using IndiaCensus.DTO;
using IndiaCensus.DAO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaCensus
{
    class CensusFactory
    {
        // Declarations
        public Dictionary<FileType, CensusDTO> fileInstanceMap = new Dictionary<FileType, CensusDTO>();

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        internal CensusDTO GetObject(FileType type)
        {
            if (fileInstanceMap.ContainsKey(type))
                return fileInstanceMap[type];
            if (type == FileType.INDIAN_STATE_CENSUS)
                return new IndianStateCensusDAO();
            return null;
        }
    }
}


