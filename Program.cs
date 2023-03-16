using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10095113_PROG6221_ICE_Task_Luca_Folli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scriptsPerLecturer = 0;
            int scripts = 0;
            int question = 0;
            int lecturers = 0;
            int subTotal = 0;

            //Accepting user information for how many scripts
            Console.WriteLine("Please enter the total number of scripts");
            scripts = int.Parse((Console.ReadLine()));

            //Error checking for how many scripts have been entered 
            while (scripts < 0)
            {
                Console.WriteLine("Please enter the total number of scripts");
                scripts = int.Parse((Console.ReadLine()));
            }

            //Accepting information for how many lectures there are.
            Console.WriteLine("Please enter number of lecturers");
            lecturers = int.Parse((Console.ReadLine()));

            //Error checking for how many lecturers have been entered
            while (lecturers < 1)
            {
                Console.WriteLine("Please enter number of lecturers");
                lecturers = int.Parse((Console.ReadLine()));
            }

            //Accepting information on how many questions 
            Console.WriteLine("Please enter number of questions");
            question = int.Parse((Console.ReadLine()));

            //Error checking for how many question have been entered
            while (question < 1 || question > 10)
            {
                Console.WriteLine("Please enter number of questions");
                question = int.Parse((Console.ReadLine()));
            }

            //The for loop calculates how many marks there in a paper in total 
            for (int count = 1; count <= question; count++)
            {
                Console.WriteLine("Please enter the total marks for question: " + count);
                subTotal = subTotal + int.Parse((Console.ReadLine()));
            }

            // A method object is created in order to use the calcTime method. 
            Methods methods = new Methods();

            //The if statement checks if the sum has a remainder 
            //If the sum has a remained the first condition will activate else the second condition will
            if ((scripts % lecturers) != 0)
            {
                //The amount of scripts per lecturer is worked out and is sent to the method calcTime
                scriptsPerLecturer = scripts / lecturers;
                Console.WriteLine("Each lecturer will have " + scriptsPerLecturer + " scripts to Mark.");
                Console.WriteLine("Each lecturer will take: ");
                methods.calcTime(subTotal, scriptsPerLecturer);


                scriptsPerLecturer = scriptsPerLecturer + (scripts % lecturers);
                Console.WriteLine("The last lecturer will have " + scriptsPerLecturer + " scripts to Mark.");
                Console.WriteLine("The Last lecturer will take: ");
                methods.calcTime(subTotal, scriptsPerLecturer);

            }
            else
            {
                //The amount of scripts per lecturer is worked out and is sent to the method calcTime
                scriptsPerLecturer = scripts / lecturers;
                Console.WriteLine("Each lecturer will have " + scriptsPerLecturer + " scripts to Mark.");
                Console.WriteLine("Each lecturer will take: ");
                methods.calcTime(subTotal, scriptsPerLecturer);
            }

            Console.ReadLine();
        }
    }


    class Methods
    {
        //This method calculates how much time it takes for each lecturer to mark a script 
        public void calcTime(int subTotal, int scriptsPerLecturer)
        {
            int secondsPerScript = 0;
            int secondsTotal = 0;
            int minutes = 0;
            int hours = 0;

            //This calculates how much time each paper will take and how much time in total it will take to mark  
            secondsPerScript = subTotal * 2;
            secondsTotal = secondsPerScript * scriptsPerLecturer;

            //The while loop converts seconds to minutes
            while (secondsTotal >= 60)
            {
                secondsTotal = secondsTotal - 60;
                minutes++;
            }

            //The while loop converts minutes to hours
            while (minutes >= 60)
            {
                minutes = minutes - 60;
                hours++;
            }

            //If there is a remainder of seconds it would be rounded up to the nearest minute. 
            if (secondsTotal > 30 || secondsTotal < 60)
            {
                minutes++;
            }

            Console.WriteLine(hours + " Hours, " + minutes + " Minutes, " + secondsTotal + " Seconds to Mark");
        }
    }
}

