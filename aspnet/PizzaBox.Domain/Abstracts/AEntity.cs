using System;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AEntity
    {
        public long EntityID { get; set; }
        

        protected AEntity()
        {
            // EntityID = DateTime.Now.Ticks;
        }

    }
}