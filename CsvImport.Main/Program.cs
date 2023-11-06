namespace CsvImport.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var taxiDataService = new TaxiDataService();
            var databaseImportService = new DatabaseImportService();

            var (uniqueRecords, duplicateRecords) = taxiDataService.GetUniqueAndDuplicateRecordsFromCsv();

            taxiDataService.ImportDuplicateRecordsToCsv(duplicateRecords);
            databaseImportService.ImportTaxiData(uniqueRecords);
        }
    }
}