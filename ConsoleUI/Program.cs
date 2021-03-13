using System;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetails();
            //BrandList();
            //ColorList();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Today }).Message);
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
