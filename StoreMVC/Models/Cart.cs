using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Candy Candy { get; set; }
        public int Quantity { get; set; }

    }
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public virtual void AddItem(Candy candy, int quantity)
        {
            CartLine line = lines.Where(x => x.Candy.CandyID == candy.CandyID).FirstOrDefault();
            if (line == null)
            {
                lines.Add(new CartLine
                {
                    Candy = candy,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Candy candy) => lines.RemoveAll(x => x.Candy.CandyID == candy.CandyID);

        public virtual float ComputeTotalValue() => lines.Sum(x => x.Candy.Price * x.Quantity);

        public virtual void Clear() => lines.Clear();

        public virtual IEnumerable<CartLine> Lines => lines;

    }
}
