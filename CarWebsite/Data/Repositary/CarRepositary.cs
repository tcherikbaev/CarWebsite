using CarWebsite.Data.Interfaces;
using CarWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Data.Repositary
{
    public class CarRepositary : IAllCars
    {
        private readonly AppDBContent appDBContent;
        public CarRepositary(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDBContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);



        public Car getObjectCar(int carID) => appDBContent.Car.FirstOrDefault(p => p.id == carID);


    }
}
