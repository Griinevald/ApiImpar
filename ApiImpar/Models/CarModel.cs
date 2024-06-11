namespace ApiImpar.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public string? Name  { get; set; }
        public string? Status { get; set; }
        public virtual PhotoModel Photo { get; set; }

    }
}
