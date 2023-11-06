using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace CsvImport.Main
{
    public class TaxiDataService
    {
        public (IEnumerable<TaxiData>, IEnumerable<TaxiData>) GetUniqueAndDuplicateRecordsFromCsv()
        {
            var records = GetAllRecordsFromCsv();

            var uniqueKeys = new HashSet<string>();

            var duplicateRecords = new List<TaxiData>();
            var uniqueRecords = new List<TaxiData>();

            foreach (var record in records)
            {
                string key = $"{record.TpepPickup}_{record.TpepDropoff}_{record.PassengerCount}";

                if (uniqueKeys.Contains(key))
                {
                    duplicateRecords.Add(record);
                }
                else
                {
                    uniqueKeys.Add(key);
                    uniqueRecords.Add(record);
                }
            }

            return (uniqueRecords, duplicateRecords);
        }

        public void ImportDuplicateRecordsToCsv(IEnumerable<TaxiData> duplicates)
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "duplicates.csv");

            using (var writer = new StreamWriter(path))
            using (var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvWriter.WriteRecords(duplicates);
            }
        }

        private IEnumerable<TaxiData> GetAllRecordsFromCsv()
        {
            using (var reader = new StreamReader("sample-cab-data.csv"))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<TaxiDataMap>();
                var records = csv.GetRecords<TaxiData>().ToList();

                return records;
            }
        }
    }
}
