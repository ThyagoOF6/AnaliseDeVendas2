using System;

namespace Entities
{
    public class Sale
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Seller { get; set; }
        public int? Items { get; set; }
        public double? Total { get; set; }

        public Sale(int? month, int? year, string seller, int? items, double? total)
        {
            Month = month;
            Year = year;
            Seller = seller;
            Items = items;
            Total = total;
        }

        public double? AveragePrice()
        {
            return Total / Items;
        }

        public override int GetHashCode()
        {
            return Seller?.GetHashCode() ?? 0;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || GetType() != obj.GetType())
                return false;
            Sale other = (Sale)obj;
            return Seller == other.Seller;
        }

        public override string ToString()
        {
            return $"{Month}/{Year}, {Seller}, {Items}, {Total}, pm = {AveragePrice():F2}";
        }
    }
}