﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Training.Domain
{
    public class Activity: Product
    {
        public Activity(string Id, string Name = "", string Desc = "" , int Price = 0, bool IsActive = true)
        {
            if (Id is null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            this.Id = $"Activity-{Id}";
            this.Name = Name;
            this.Description = Desc;
            this.Price = Price;
            this.IsActive = IsActive;
            this.ProductType = "Activity";
        }
    }
}
