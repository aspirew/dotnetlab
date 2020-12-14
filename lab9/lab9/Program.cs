using System;
using static lab7.Program;
using static list8.Program;
using static lab6.Zad1;
using System.Linq;
using LinqExamples;
using System.Collections.Generic;

namespace lab9
{
    class Program
    {

        public class Topic
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Topic(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString() => $"{Id,2}, {Name,11}";
        }


        public class StudentWithTopics
        {
            public int Id { get; set; }
            public int Index { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public bool Active { get; set; }
            public int DepartmentId { get; set; }

            public List<int> TopicIDs { get; set; }
            public StudentWithTopics(int id, int index, string name, Gender gender, bool active,
                int departmentId, List<int> topicIDs)
            {
                Id = id;
                Index = index;
                Name = name;
                Gender = gender;
                Active = active;
                DepartmentId = departmentId;
                TopicIDs = topicIDs;
            }

            public string getTopicsWithNames(List<Topic> topics)
            {
                string res = "";
                var str = topics.FindAll(top => TopicIDs.Contains(top.Id));
                foreach (var topic in str)
                    res += topic + "\n";
                return res;
            }

            public override string ToString()
            {
                return $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}";
            }
        }



        static void zad1()
        {
            string path = Console.ReadLine();

                readPath(path);

            var words =
            from word in wordsList
            group word by word
            into wGroup
            orderby wGroup.Count() descending
            select new
            {
                wGroup.Key,
                Frequency = wGroup.Count()
            };

                foreach (var word in words.Take(10))
                {
                    Console.WriteLine("Word: {0}, Frequency: {1} ", word.Key, word.Frequency);
                }
        }

        static void zad2(int n)
        {
            var studentsOrdered = (
                    from student in Generator.GenerateStudentsEasy()
                    orderby student.Name, student.Index
                    select student
                ).Select((stud, index) => new { stud, index });

            var studentsGrouped = from student in studentsOrdered
            group student by student.index / n
            into sGroup
            select new
                {
                    sGroup.Key,
                    Enumerable = sGroup.Select(s => s.stud)
                };

            foreach (var student in studentsGrouped)
            {
                Console.WriteLine(student.Key);
                student.Enumerable.ToList().ForEach(Console.WriteLine);
            }
        }

        static void zad3()
        {
            var students = Generator.GenerateStudentsEasy();

            var selection =
            from student in students
            from topic in student.Topics
            group topic by topic into tGroup
            orderby tGroup.Count() descending
            select new
            {
                tGroup.Key,
                Count = tGroup.Count()
            };

            selection.ToList().ForEach(Console.WriteLine);

            var selectionByGender =
                from student in students
                group student by student.Gender
                into gGroup
                select new
                {
                    gGroup.Key,
                    topicGroup = from student in gGroup
                                 from topic in student.Topics
                                 group topic by topic into tGroup
                                 orderby tGroup.Count() descending
                                 select new
                                 {
                                     tGroup.Key,
                                     Count = tGroup.Count()
                                 }
                };


            foreach (var group in selectionByGender)
            {
                Console.WriteLine(group.Key);
                group.topicGroup.ToList().ForEach(Console.WriteLine);
            }
        }

        static void zad4()
        {
            var students = Generator.GenerateStudentsEasy();
            var topics =
                (from student in students
                from topic in student.Topics
                select topic).Distinct().ToList();

            List<Topic> topicClassCollection = new List<Topic>();

            foreach (var item in topics.Select((value, i) => new { value, i }))
            {
                topicClassCollection.Add(new Topic(item.i, item.value));
            }

            var studentsWithTopics =
                from student in students
                select new StudentWithTopics(student.Id, student.Index, student.Name, student.Gender, student.Active, student.DepartmentId,
                    (from topic in student.Topics
                     select topicClassCollection.Find(t => t.Name == topic).Id).ToList()
                );

            studentsWithTopics.ToList().ForEach(s =>
            {
                Console.WriteLine(s.ToString());
                Console.WriteLine(s.getTopicsWithNames(topicClassCollection));
            });
        }

        static void zad5()
        {
            Pojazd rower = new Rower("AMD", 2020, "gorski");
            Pojazd sedan = new SamochodOsobowy("Ford", 2015, 200, 150, 9.7, false);
            Pojazd ciezarowka = new SamochodCiezarowy("Scania", 2018, 160, 400, 1000, 1250.5);
            Pojazd ciezarowka2 = new SamochodCiezarowy("Volvo", 2016, 180, 420, 1400, 1380.1);
            Pojazd[] pojazdy = new Pojazd[4] { rower, sedan, ciezarowka, ciezarowka2 };
            lab6.Zad1 nosn = new lab6.Zad1();

            int res = (int)typeof(lab6.Zad1).GetMethod("SumaNosnosci").Invoke(nosn, new object[] { pojazdy });

            Console.WriteLine(res);
        }

        static void Main(string[] args)
        {
            zad5();
        }
    }
}
