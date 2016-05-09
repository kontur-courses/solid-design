namespace Samples.RestaurantMenu
{
    public interface IRestaurantMenu
    {
        bool IsVegetarian(DishId dishId);
        bool HasHolidayDiscount(DishId dishId);
        DishType GetDishType(DishId dishId);
    }
}