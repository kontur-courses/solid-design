using System.Collections.Generic;
using System.Linq;

namespace Samples.RestaurantMenu
{
    public class RestaurantMenuByPolymorphism : IRestaurantMenu
    {
        private readonly IDictionary<DishId, IDish> dishes;

        public RestaurantMenuByPolymorphism()
        {
            var dishes = new IDish[]
            {
                new Minestrone(),
                new PureeSoup(),
                new Pasta(),
                new Pizza(),
                new FreshJuice(),
                new Tea(),
                new IceCream()
            };
            this.dishes = dishes.ToDictionary(d => d.Id);
        }

        public bool IsVegetarian(DishId dishId)
        {
            return dishes[dishId].IsVegetarian;
        }

        public bool HasHolidayDiscount(DishId dishId)
        {
            return dishes[dishId].HasHolidayDiscount;
        }

        public DishType GetDishType(DishId dishId)
        {
            return dishes[dishId].Type;
        }
    }

    public interface IDish
    {
        DishId Id { get; }
        DishType Type { get; }
        bool IsVegetarian { get; }
        bool HasHolidayDiscount { get; }
    }

    public class Minestrone : IDish
    {
        public DishId Id { get { return DishId.Minestrone; } }
        public DishType Type { get { return DishType.Soup; } }
        public bool IsVegetarian { get { return true; } }
        public bool HasHolidayDiscount { get { return false; } }
    }

    public class PureeSoup : IDish
    {
        public DishId Id { get { return DishId.PureeSoup; } }
        public DishType Type { get { return DishType.Soup; } }
        public bool IsVegetarian { get { return true; } }
        public bool HasHolidayDiscount { get { return false; } }
    }

    public class Pasta : IDish
    {
        public DishId Id { get { return DishId.Pasta; } }
        public DishType Type { get { return DishType.MainDish; } }
        public bool IsVegetarian { get { return false; } }
        public bool HasHolidayDiscount { get { return false; } }
    }

    public class Pizza : IDish
    {
        public DishId Id { get { return DishId.Pizza; } }
        public DishType Type { get { return DishType.MainDish; } }
        public bool IsVegetarian { get { return false; } }
        public bool HasHolidayDiscount { get { return false; } }
    }

    public class FreshJuice : IDish
    {
        public DishId Id { get { return DishId.FreshJuice; } }
        public DishType Type { get { return DishType.Drink; } }
        public bool IsVegetarian { get { return true; } }
        public bool HasHolidayDiscount { get { return false; } }
    }

    public class Tea : IDish
    {
        public DishId Id { get { return DishId.Tea; } }
        public DishType Type { get { return DishType.Drink; } }
        public bool IsVegetarian { get { return true; } }
        public bool HasHolidayDiscount { get { return false; } }
    }

    public class IceCream : IDish
    {
        public DishId Id { get { return DishId.IceCream; } }
        public DishType Type { get { return DishType.Dessert; } }
        public bool IsVegetarian { get { return true; } }
        public bool HasHolidayDiscount { get { return true; } }
    }
}
