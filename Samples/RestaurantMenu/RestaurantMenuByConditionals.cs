using System;

namespace Samples.RestaurantMenu
{
    public class RestaurantMenuByConditionals : IRestaurantMenu
    {
        public bool IsVegetarian(DishId dishId)
        {
            return dishId != DishId.Pasta && dishId != DishId.Pizza;
        }

        public bool HasHolidayDiscount(DishId dishId)
        {
            return dishId == DishId.IceCream;
        }

        public DishType GetDishType(DishId dishId)
        {
            switch (dishId)
            {
                case DishId.Minestrone:
                case DishId.PureeSoup:
                    return DishType.Soup;
                case DishId.Pasta:
                case DishId.Pizza:
                    return DishType.MainDish;
                case DishId.FreshJuice:
                case DishId.Tea:
                    return DishType.Drink;
                case DishId.IceCream:
                    return DishType.Dessert;
                default:
                    throw new ArgumentOutOfRangeException("dishId", dishId, null);
            }
        }
    }
}