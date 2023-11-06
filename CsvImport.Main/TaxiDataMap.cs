using CsvHelper.Configuration;

namespace CsvImport.Main
{
    public sealed class TaxiDataMap : ClassMap<TaxiData>
    {
        public TaxiDataMap()
        {
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            Map(m => m.TpepPickup).Name("tpep_pickup_datetime")
                                  .Convert(args => TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(args.Row[1]), estTimeZone));
            Map(m => m.TpepDropoff).Name("tpep_dropoff_datetime")
                                   .Convert(args => TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(args.Row[2]), estTimeZone));
            Map(m => m.PULocationID).Name("PULocationID");
            Map(m => m.DOLocationID).Name("DOLocationID");
            Map(m => m.FareAmount).Name("fare_amount");
            Map(m => m.TipAmount).Name("tip_amount");
            Map(m => m.StoreAndFwd).Name("store_and_fwd_flag").Convert(args => args.Row[6] == "Y" ? "Yes" : "No");
            Map(m => m.PassengerCount).Name("passenger_count").Default(0); // Has to put it here to avoid exception,
            Map(m => m.TripDistance).Name("trip_distance");                // contains empty string that cannot be converted to int
            Map(m => m.VendorID).Name("VendorID").Default(0);              // Same thing here don't know whether to ignore 
            Map(m => m.RatecodeID).Name("RatecodeID").Default(0);          // these records, so just put default value for them
            Map(m => m.PaymentType).Name("payment_type").Default(0);       //
            Map(m => m.Extra).Name("extra");
            Map(m => m.MTATax).Name("mta_tax");
            Map(m => m.TollsAmount).Name("tolls_amount");
            Map(m => m.ImprovementSurcharge).Name("improvement_surcharge");
            Map(m => m.TotalAmount).Name("total_amount");
            Map(m => m.CongestionSurcharge).Name("congestion_surcharge");
        }
    }
}
