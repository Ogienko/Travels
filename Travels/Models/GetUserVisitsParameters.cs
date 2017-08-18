namespace Travels.Models {

    public class GetUserVisitsParameters {

        public int? FromDate { get; set; }

        public int? ToDate { get; set; }

        public string Country { get; set; }

        public int? ToDistance { get; set; }
    }
}