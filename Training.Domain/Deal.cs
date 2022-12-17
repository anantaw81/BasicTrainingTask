using System.Xml.Linq;

namespace Training.Domain
{
    public class Deal: Product
    {
        public Deal(string Id, string Name = "", string Desc = "", int Price=0, bool IsActive = true, int Quantity = 0)
        {
            if (Id is null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            this.Id = $"Deal-{Id}";
            this.Name = Name;
            this.Description = Desc;
            this.Price = Price;
            this.IsActive = IsActive;
            this.ProductType = "Deal";
            this.Quantity = Quantity;
        }
    }
}