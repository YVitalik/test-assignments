using System.Data;
using System.Data.SqlClient;

namespace CsvImport.Main
{
    public class DatabaseImportService
    {
        private const string _connectionString = "Server=.;Database=Test;Integrated Security=SSPI;Trusted_Connection=True";
        private const string _tableName = "dbo.TaxiData";

        public void ImportTaxiData(IEnumerable<TaxiData> records)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionString))
            {
                bulkCopy.DestinationTableName = _tableName;
                bulkCopy.BatchSize = 1000;

                var dataTable = ToDataTable(records);
                bulkCopy.WriteToServer(dataTable);
            }
        }

        private DataTable ToDataTable(IEnumerable<TaxiData> records)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("tpep_pickup_datetime", typeof(DateTime));
            dataTable.Columns.Add("tpep_dropoff_datetime", typeof(DateTime));
            dataTable.Columns.Add("passenger_count", typeof(int));
            dataTable.Columns.Add("trip_distance", typeof(decimal));
            dataTable.Columns.Add("store_and_fwd_flag", typeof(string));
            dataTable.Columns.Add("PULocationID", typeof(int));
            dataTable.Columns.Add("DOLocationID", typeof(int));
            dataTable.Columns.Add("fare_amount", typeof(decimal));
            dataTable.Columns.Add("tip_amount", typeof(decimal));

            foreach (var record in records)
            {
                var dataRow = dataTable.NewRow();

                dataRow["tpep_pickup_datetime"] = record.TpepPickup;
                dataRow["tpep_dropoff_datetime"] = record.TpepDropoff;
                dataRow["passenger_count"] = record.PassengerCount;
                dataRow["trip_distance"] = record.TripDistance;
                dataRow["store_and_fwd_flag"] = record.StoreAndFwd;
                dataRow["PULocationID"] = record.PULocationID;
                dataRow["DOLocationID"] = record.DOLocationID;
                dataRow["fare_amount"] = record.FareAmount;
                dataRow["tip_amount"] = record.TipAmount;

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

    }
}
