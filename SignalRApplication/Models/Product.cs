namespace SignalRApplication.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
    }
    public class Product:BaseEntity 
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStoc { get; set; }
    }
}
