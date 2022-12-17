namespace Training.Domain
{
    public class Deal: Product
    {
        public Deal(string Id, string Name, string Desc, int Price)
        {
            this.Id = $"Deal-{Id}";
            this.Name = Name;
            this.Description = Desc;
            this.Price = Price;
        }
    }
}