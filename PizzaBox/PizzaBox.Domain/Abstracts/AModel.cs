using System;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AModel
    {
      public long Id { get; }
      public AModel()
      {
        Id = DateTime.Now.Ticks;
      }
    }
}