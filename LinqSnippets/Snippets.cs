using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{


    public class Snippets
    {

        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW GOlf",
                "VW California",
                "Audi A3",
                "Audi A4",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // 1. SELECT * of all cars
            var carList = from car in cars select car;

            foreach ( var car in carList )
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach( var audi in audiList )
            {
                Console.WriteLine(audi);
            }
        }

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multiplied by 3
            // take all numbers, but 9
            // Order ascending value

            var proccesedNumberList =
                numbers
                    .Select(num => num * 3)
                    .Where(num => num != 9)
                    .OrderBy(num => num); // at the end, we order ascending
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text == "c");

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains Z or default
            var firstOrDefault = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. Last element that contains "z" or default
            var lastOrDefault  = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var uniqueText = textList.Single();

            int[] evenNumbers = {0, 2, 4, 6 , 8 };
            int[] otherNumbers = { 0, 2, 6 };

            var myEvenNumber = evenNumbers.Except(otherNumbers);

        }

        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3",
                "Opinion 4, text 4",
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Martin",
                            Email = "Martin@gmail.com",
                            Salary = 3000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Pepe",
                            Email = "Pepe@gmail.com",
                            Salary = 1000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Juanjo",
                            Email = "Juanjo@gmail.com",
                            Salary = 2000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                            Id = 1,
                            Name = "Maria",
                            Email = "Maria@gmail.com",
                            Salary = 3200
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Pedro",
                            Email = "Pedro@gmail.com",
                            Salary = 4000
                        },
                        new Employee()
                        {
                            Id = 1,
                            Name = "Juan",
                            Email = "Juan@gmail.com",
                            Salary = 3800
                        }
                    }
                }
            };

            // Obtains all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees).ToList();

            // Know if any list is empty
            bool hasEnterprises = enterprises.Any();
            bool hasEmployees = enterprises.Any(enterprises => enterprises.Employees.Any());

            // All enterprises at least has an employee with more than 1000 of salary
            bool hasEmployeeWithSalaryMoreThan1000 =
                enterprises.Any(enterprises =>
                    enterprises.Employees.Any(employee => employee.Salary >= 1000));
        }

        static public void linqCollection()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var communtResult = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                select new { element, secondElement };

            var commundResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondelement) => new { element, secondelement });

            // OUTER JOIN - LEFT
            var leftOuterJoin = from e in firstList
                                join se in secondList
                                on e equals se
                                into temporalList
                                from te in temporalList.DefaultIfEmpty()
                                where e != te
                                select new { Element = e };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - RIGTH
            var rightOuterJoin = from se in secondList
                                join e in firstList
                                on se equals e
                                into temporalList
                                from te in temporalList.DefaultIfEmpty()
                                where se != te
                                select new { Element = se };


            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);


        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11
            };

            // SKIP
            var skipTwoFirstValues = myList.Skip(2);
            
            var skipLastTwoValues = myList.SkipLast(2);

            var skipWhile = myList.SkipWhile(num => num < 4);

            // TAKE
            var takeFirstTwoValues = myList.Take(2);

            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);



        }
    }
}