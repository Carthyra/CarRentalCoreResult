using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();
            //BrandList();
            //ColorList();
            //UserList();
        }

        private static void UserList()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var userresult = userManager.GetAll();
            if (userresult.Success == true)
            {
                foreach (var user in userresult.Data)
                {
                    Console.WriteLine(user.FirstName);
                }
            }
            else
            {
                Console.WriteLine(userresult.Message);
            }
        }

        private static void ColorList()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Success + "/" + result.Message);
            }
        }

        private static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Success + "/" + result.Message);
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Success + "/" + result.Message);
            }
        }
    }
}
