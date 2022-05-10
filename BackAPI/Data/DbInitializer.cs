using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackAPI.Models;

namespace BackAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PcShopContext context)
        {
            context.Database.EnsureCreated();
            if ((context.Products.Any()) && (context.Category.Any()))
            {
                return;
            }
            var categoryes = new Category[]
            {
                new Category
                {
                   // category_id = 1,
                    category_name = "Видеокарты"
                },
                new Category
                {
                   // category_id = 2,
                    category_name = "Процессоры"
                },
                 new Category
                {
                    //category_id = 3,
                    category_name = "Оперативная память"
                },
                  new Category
                {
                    //category_id = 4,
                    category_name = "Охлаждение компьютера"
                },
                   new Category
                {
                   // category_id = 5,
                    category_name = "SSD накопители"
                },
                 new Category
                {
                    //category_id = 6,
                    category_name = "Жесткие диски"
                },
                  new Category
                {
                    //category_id = 7,
                    category_name = "Материнские платы"
                },
                     new Category
                {
                    //category_id = 8,
                    category_name = "Компьютеры"
                },
                        new Category
                {
                    //category_id = 9,
                    category_name = "Ноутбуки"
                },
                           new Category
                {
                    //category_id = 10,
                    category_name = "Мониторы"
                },
            };
            foreach (Category category in categoryes)
            {
                context.Category.Add(category);
            }
            context.SaveChanges();

            var products = new Products[]
            {
                new Products
                {
                    //product_id = 1,
                    product_name = "RTX 3090",
                    technical_specifications = "Объем видеопамяти 24 ГБ Тип памяти GDDR6X Разрядность шины памяти 384 бит Максимальная пропускная способность памяти 936 Гбайт/сек",
                    count_of_products = 1,
                    product_price = 356000,
                    discount = 3,
                    category_FK = 1

                },
                new Products
                {
                    //product_id = 2,
                    product_name = "Intel Core i7-9700",
                    technical_specifications = "Ядро Coffee Lake RТехпроцесс 14 нмКоличество ядер 8Максимальное число потоков 8Кэш L1 (инструкции) 256 КБКэш L1 (данные) 256 КБОбъем кэша L2 2 МБОбъем кэша L3 12 МБ",
                    count_of_products = 6,
                    product_price = 23599,
                    discount = 0,
                    category_FK = 2
                }, new Products
                {
                   // product_id = 3,
                    product_name = "ASUS ROG Strix GeForce RTX 3080 Ti OC",
                    technical_specifications = "Объем видеопамяти 12 ГБТип памяти GDDR6XПропускная способность памяти на один контакт 19 Гбит/сРазрядность шины памяти 384 битМаксимальная пропускная способность памяти 912 Гбайт/сек",
                    count_of_products = 10,
                    product_price = 179999,
                    discount = 5,
                    category_FK = 1
                }, new Products
                {
                    //product_id = 4,
                    product_name = "Жесткий диск Seagate 7200 BarraCuda",
                    technical_specifications = "Объем HDD 1ТБ",
                    count_of_products = 46,
                    product_price = 2799,
                    discount = 0,
                    category_FK = 6
                }, new Products
                {
                   // product_id = 5,
                    product_name = "Ноутбук ASUS ROG Zephyrus DUO 15 SE GX551QS-HB099T",
                    technical_specifications = "Видеокарта RTX 3080 для ноутбуков, Процессор AMD Ryzen 9 5900HX, Экран Ultra HD 4K",
                    count_of_products = 3,
                    product_price = 352999,
                    discount = 10,
                    category_FK = 9
                }
            };
            foreach (Products product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            if (context.LegalPerson.Any())
            {
                return;
            }

            var legalPersons = new LegalPerson[]
            {
                new LegalPerson
                {
                    Legal_person_CRS = "123456789",
                    Legal_person_TIN = "1234567891",
                    Legal_person_MSRN = "1234567897777"
                }
            };

            foreach (LegalPerson legalPerson in legalPersons)
            {
                context.LegalPerson.Add(legalPerson);
            }
            context.SaveChanges();

            if (context.PhysicalPerson.Any())
            {
                return;
            }

            var physicalPersons = new PhysicalPerson[]
           {
                new PhysicalPerson
                {
                    physical_person_name = "Иванов Геннадий Степанович",
                    physical_person_pasport_number = "2421 775477",
                    physical_person_TIN = "123456789101"
                }
           };

            foreach (PhysicalPerson physicalPerson in physicalPersons)
            {
                context.PhysicalPerson.Add(physicalPerson);
            }
            context.SaveChanges();
        }
    }
}
