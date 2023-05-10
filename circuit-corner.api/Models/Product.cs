namespace circuit_corner.api.Models {
    public class Product {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public int categoryID { get; set; }
    }
}
