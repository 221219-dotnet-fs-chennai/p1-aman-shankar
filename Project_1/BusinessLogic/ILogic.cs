using Models;
namespace Business_Logic
{
    public interface ILogic
    {
        /// <summary>
        /// This method will return all the users been queried from the Data Logic
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllUser();
/*
        /// <summary>
        /// This will fetch all the restaurants from the Data layer and then filter it by zipocode
        /// </summary>
        /// <param name="zipcode"></param>
        /// <returns>IEnumerable<Restaurants></Restaurants></returns>
       
        IEnumerable<User> GetRestaurantsByZipcode(string zipcode);
*/
    }
}
