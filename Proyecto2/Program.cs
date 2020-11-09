using System;
using System.Collections.Generic;
using System.IO;

namespace Proyecto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la ruta del archivo de los estudiantes: ");
            var StudentsPath = @"" + Console.ReadLine();

            Console.WriteLine ("Ingrese la ruta del archivo de los temas: ");
            var TopicsPath = @"" + Console.ReadLine();

            //leo el archivo
            StreamReader students = new StreamReader (StudentsPath);
            List <string> StudentsList = new List<string>();
            string hey;
            while ((hey = students.ReadLine()) != null){
                    StudentsList.Add(hey);
            }

            //leo el archivo
            StreamReader topics = new StreamReader (TopicsPath);
            List <string> TopicsList = new List<string>();
            string hey2;
            while ((hey2 = topics.ReadLine()) != null){
                    TopicsList.Add(hey2);
            }

            //Randomize students
            Random RandomStudents = new Random();
            List<string> StudentsL = new List<string>();
            int index = 0;

            while(StudentsList.Count > 0){
                index = RandomStudents.Next (0, StudentsList.Count);
                StudentsL.Add(StudentsList[index]);
                StudentsList.RemoveAt(index);
            }

            //Randomize topics
            Random RandomTopics = new Random();
            List<string> TopicsL = new List<string>();
            index = 0;

            while(TopicsList.Count > 0){
                index = RandomTopics.Next (0, TopicsList.Count);
                TopicsL.Add(TopicsList[index]);
                TopicsList.RemoveAt(index);
            }

            Console.WriteLine("Introduzca la cantidad de grupos: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= StudentsL.Count){
                Console.WriteLine ("La cantidad de estudiantes es menor que la cantidad de grupos");
                return;
            }
            int QuantityOfGroups = StudentsL.Count % size;

             if (QuantityOfGroups > TopicsL.Count){
                Console.WriteLine ("La cantidad de temas es menor que la cantidad de grupos");
                return;
            }

            Group [] groups = new Group [size];
            int numOfGroups = 0;

            for (int i = 0; i < size; i ++){
                numOfGroups = i + 1;
                groups [i] = new Group(numOfGroups);
            }

            int cont = 0;
            int StudentsCount = StudentsL.Count;
            int TopicsCount = TopicsL.Count;

            while (StudentsCount > 0){
                var st = StudentsL[StudentsCount-1];
                
                if (cont == size){
                    cont = 0;
                }

                groups[cont].Students.Add(st);
                cont++;
                StudentsCount--;
            }

            while (TopicsCount > 0){
                var top = TopicsL[TopicsCount-1];
                
                if (cont == size){
                    cont = 0;
                }

                groups[cont].Topics.Add(top);
                cont++;
                TopicsCount--;
            }

            foreach (Group g in groups){

            Console.WriteLine ($"Grupo # {g.numOfGroups}");
            Console.WriteLine("\n");
            Console.WriteLine ($"Estudiantes en el grupo: {g.Students.Count}");
            Console.WriteLine("\n");

            foreach (String stud in g.Students){
            Console.Write ("     ");
            Console.WriteLine("\n");
            Console.WriteLine(stud);
            Console.WriteLine("\n");
            }

            Console.WriteLine ($"Temas en este grupo: {g.Topics.Count}");
            Console.WriteLine("\n");

            foreach (String topc in g.Topics){
            Console.Write ("     ");
            Console.WriteLine("\n");
            Console.WriteLine(topc);
            Console.WriteLine("\n");
            }

            }

        }
        class Group {

            public int numOfGroups {get; set; }

            public List <string> Topics = new List<string>();
            public List <string> Students = new List<string> ();

        public Group (int NumOfGroups){
            numOfGroups = NumOfGroups;
            this.Students = new List<string> ();
            this.Topics = new List<string> ();
        } 
        }
    }
}
