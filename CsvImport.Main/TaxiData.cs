namespace CsvImport.Main
{
    public class TaxiData
    {
        public DateTime TpepPickup { get; set; }

        public DateTime TpepDropoff { get; set; }

        public int PassengerCount { get; set; }

        public decimal TripDistance { get; set; }

        public string StoreAndFwd { get; set; }

        public int PULocationID { get; set; }

        public int DOLocationID { get; set; }

        public decimal FareAmount { get; set; }

        public decimal TipAmount { get; set; }

        public int RatecodeID { get; set; }

        public int PaymentType { get; set; }

        public decimal Extra { get; set; }

        public decimal MTATax { get; set; }

        public decimal TollsAmount { get; set; }

        public decimal ImprovementSurcharge { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal CongestionSurcharge { get; set; }

        public int VendorID { get; set; }
    }

}
