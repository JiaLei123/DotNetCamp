﻿using System;
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
        }
    }
}