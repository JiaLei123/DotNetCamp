using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractice
{
    class GroupByOperation : LinqBase
    {
        public override object prepareDemoData()
        {
            Console.WriteLine("Show Group By: ");
            List<int> list = new List<int>();
            foreach (int a in Constants.exampleints)
            {
                list.Add(a);
            }
            PrintArray("original int list are", list);

            return list;
        }

        public override void runLinq(object obj)
        {
            IEnumerable<int> list = obj as IEnumerable<int>;
            var result = from number in list
                         group number by number % 2 == 0;

            foreach (var group in result)
            {
                PrintArray("Splite the Int Array to", group);
            }

            var a_result = list.GroupBy(p => p % 2 == 0);
            foreach (var group in a_result)
            {
                PrintArray("Lambda Splite the Int Array to", group);
            }


            Console.WriteLine("Group with Embeded Query:");

            var students = StudentClass.students;

            var queryNestedGroups = from student in students
                         group student by student.Year into newgroup1
                         from newgroup2 in
                         (from student in newgroup1 group student by student.LastName)
                         group newgroup2 by newgroup1.Key;

            foreach (var outerGroup in queryNestedGroups)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    }
                }
            }

            Console.WriteLine("Lamdba Group with Embeded Query:");
            //var a_queryNestedGroups = students.GroupBy(p => p.Year, new {}).GroupBy(c => c.lastname);
            var a_queryNestedGroups = students.GroupBy(p => p.Year).Select(a=> new { a.Key, studend = a.GroupBy(b => b.LastName) });
            foreach (var outerGroup in a_queryNestedGroups)
            {
                Console.WriteLine("DataClass.Student Level = {0}", outerGroup.Key);
                foreach (var innerGroup in outerGroup.studend)
                {
                    Console.WriteLine("\tNames that begin with: {0}", innerGroup.Key);
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine("\t\t{0} {1}", innerGroupElement.LastName, innerGroupElement.FirstName);
                    } 
                }
            }

            Console.WriteLine("Group with Select:");
            var results = from number in list
                          group number by number % 2 == 0
                          into numbergroup
                          select numbergroup.Sum();

            PrintArray("Splite the Int Array to", results);

            var a_results = list.GroupBy(p => p % 2 == 0).Select(c => c.Sum());

            PrintArray("Lambda Splite the Int Array to", a_results);

        }
    }
}
