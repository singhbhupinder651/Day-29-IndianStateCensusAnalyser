using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {


        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCodeFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\ishaa\Documents\ZNewFolder\Day-29-IndianStateCensusAnalyser\IndianStateCensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            stateRecord = new Dictionary<string, CensusDTO>();
        }


        //TC-2.1
        [Test]
        public void GivenStateCodeDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }


        //TC-2.2
        [Test]
        public void GivenWrongStateCodeDataFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        
        //TC-2.3
        [Test]
        public void GivenWrongStateCodeDataFilePath_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }


        //TC-2.4
        [Test]
        public void GivenWrongDelimiterStateCodeDataFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }


        //TC-2.5
        [Test]
        public void GivenWrongHeaderStateCodeDataFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

    }
}