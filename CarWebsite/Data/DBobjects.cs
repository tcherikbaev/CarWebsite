using CarWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebsite.Data
{
    public class DBobjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        shortDesc = "Fast Car",
                        longDesc = "The Tesla Model S is an all-electric five-door liftback sedan, produced by Tesla, Inc., and introduced on June 22, 2012.[10] As of February 16, 2020, the Model S Long Range Plus has an EPA range of 390 miles (630 km), which is higher than any other battery electric car.",
                        img = "/img/tesla.jpg",
                        prize = 45000,
                        IsFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                     new Car
                     {
                         Name = "Mercedes s65",
                         shortDesc = "Mercedes-AMG S65 Final Edition",
                         longDesc = "The performance of the Final Edition differs in details of a matte bronze color like 20-inch wheels, inserts in the front air intakes, on the thresholds and in the rear bumper. AMG emblems are also installed on the rear pillar, indicating the special status of the sedan.",
                         img = "/img/s65.jpg",
                         prize = 60000,
                         IsFavourite = true,
                         available = true,
                         Category = Categories["Классические автомобили"]
                     },
                     new Car
                     {
                         Name = "Toyota Camry",
                         shortDesc = "Toyota Camry 70",
                         longDesc = "The Toyota Camry (/ˈkæmri/; Japanese: トヨタ・カムリ Toyota Kamuri) is an automobile sold internationally by the Japanese manufacturer Toyota since 1982, spanning multiple generations. Originally compact in size (narrow-body), later Camry models have grown to fit the mid-size classification (wide-body)—although the two sizes co-existed in the 1990s. Since the release of the wide-bodied versions, Camry has been extolled by Toyota as the firm's second  after the Corolla",
                         img = "/img/camry.jpg",
                         prize = 30000,
                         IsFavourite = false,
                         available = true,
                         Category = Categories["Классические автомобили"]
                     },
                           new Car
                           {
                               Name = "Toyota Hybrid",
                               shortDesc = "Toyota Prius",
                               longDesc = "The Toyota Prius (/ˈpriːəs/; Japanese:トヨタ プリウス Toyota Puriusu) is a full hybrid electric automobile developed and manufactured by Toyota since 1997. Initially offered as a 4-door sedan, it has been produced only as a 4-door liftback since 2003.",
                               img = "/img/prius.jpg",
                               prize = 10000,
                               IsFavourite = false,
                               available = true,
                               Category = Categories["Электромобили"]
                           }
                            

                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName ="Электромобили",desc="Современный вид транспорта"},
                         new Category{CategoryName="Классические автомобили",desc=" Машины с двигателем внутренного сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName, el);
                    }
                }
                return category;
            }
        }
    }
}
