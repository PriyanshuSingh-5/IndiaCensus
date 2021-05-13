using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IndiaCensus;
using IndiaCensus.DTO;
using System;

namespace IndiaCensusMSTest
{
    [TestClass]
    public class UnitTest1
    {
        // Static variables
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public static string indianStateCensusFilePath = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCode.csv";
        public static string wrongHeaderIndianCensusFile = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        public static string wrongIndianStateCodeFilePath = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\WrongIndiaStateCode.csv";
        public static string IndianStateCodeFiletype = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\IndiaStateCode.txt";
        public static string delimeterIndianStateCodeFilePath = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\DelimiterIndiaStateCode.csv";
        public static string delimeterIndianCensusCodeFilePath = @"C:\Users\K.R.DHASHNIGA\source\repos\IndiaCensus\IndiaCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        //setup the instances
        
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        
        // TC1.1 Given the States Census CSV file, Check to ensure the Number of Record matches
        
        [TestMethod]
        public void GivenIndianCensusDataFile()
        {
            totalRecord = censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        
        // TC 1.2 Given the State Census CSV File if incorrect Returns a custom Exception
        
        [TestMethod]
        public void GivenWrongIndian()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, wrongIndianStateCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, indianCensusResult.type);
        }

        
        // TC 1.3 Given the State Census CSV File when correct but type incorrect Returns a custom Exception
        
        [TestMethod]
        public void GivenWrongIndianCensusDataFileType()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, wrongIndianStateCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.EXTENSION_NOT_FOUND, indianCensusResult.type);
        }

        
        // TC 1.4 Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception
       
        [TestMethod]
        public void GivenWrongIndianCensusDataFileTypeDelimeter()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, delimeterIndianCensusCodeFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER, indianCensusResult.type);
        }

        
        // TC 1.5 Given the State Census CSV File when correct but csv header incorrect Returns a custom Exception
        
        [TestMethod]
        public void GivenWrongIndianCensusDataHeadersCustomExcep()
        {
            var indianCensusResult = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCsvFile(IndiaCensus.FileType.INDIAN_STATE_CENSUS, wrongHeaderIndianCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADERS_MISMATCH, indianCensusResult.type);
        }
    }
}

