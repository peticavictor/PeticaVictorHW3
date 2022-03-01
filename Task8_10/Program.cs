using System;

namespace Task8
{
    class Student
    {
        public const int arraySize = 3;

        public String lastName { get; set; }
        public String firstName { get; set; }
        public String patronimic { get; set; }
        public String group { get; set; }
        public int age { get; set; }
        public int[][] marks = new int[3][];

        public Student(string lastName, string firstName, string patronimic, string group, int age )
        {
            this.lastName=lastName;
            this.firstName=firstName;
            this.patronimic=patronimic;
            this.group=group;
            this.age=age;

            // creating jagged array
            marks[0] = new int[2];
            marks[1] = new int[3];
            marks[2] = new int[4];

            //setting number of marks on first position
            marks[0][0] = 0;
            marks[1][0] = 0;
            marks[2][0] = 0;
        }

        //method for raising size of marks array if it is necessary
        private void doubleArraySize(int i)
        {
            // check if there are place for another one mark
            if(marks[i][0] == marks[i].Length - 1)
            { 
                // creating a new array with size * 2
                int[] newArray = new int[marks[i].Length * 2];

                //copying values from old array to new array
                Array.Copy(marks[i], newArray, marks[i].Length);

                //assigning new array to old
                marks[i] = newArray;
            }
        }

        public void setMark(Discipline discipline, int mark)
        {
            //creating new int with value = index of Discipline
            int index = ((int)discipline);

            //raise array size if it is necesary
            doubleArraySize(index);

            //setting mark on (number of marks + 1 position)
            marks[index][marks[index][0] + 1] = mark;

            //increment number of marks
            marks[index][0] += 1;
        }

        public float getAverageMark(Discipline discipline)
        {
            //creating new int with value = index of Discipline
            int index = ((int)discipline);

            //calculating average of discipline
            int sum = 0;
            for(int i=1; i < marks[index][0] + 1; i++)
            {
                sum += marks[index][i];
            }
            float average = (float) sum / marks[index][0];

            return average;
        }

        public void outputMarks()
        {
            for(int i = 0; i < marks.Length; i++)
            {
                for (int j = 1; j < marks[i][0] + 1; j++)
                {
                    Console.Write("  " + marks[i][j]);
                }
                Console.WriteLine();
            }
        }
    }

    enum Discipline
    {
        Programming = 0,
        Administration = 1,
        Design = 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            // creating student
            Student student = new Student("George", "Doe", "Johnovich", "lpd2021", 32);

            // setting marks for student
            student.setMark(Discipline.Programming, 10);
            student.setMark(Discipline.Programming, 9);
            student.setMark(Discipline.Programming, 7);
            student.setMark(Discipline.Administration, 9);
            student.setMark(Discipline.Administration, 6);
            student.setMark(Discipline.Administration, 7);
            student.setMark(Discipline.Design, 8);
            student.setMark(Discipline.Design, 5);
            student.setMark(Discipline.Design, 7);
            student.setMark(Discipline.Design, 7);

            // output student average
            Console.WriteLine("Student programming average = " + student.getAverageMark(Discipline.Programming));
            Console.WriteLine("Student administration average = " + student.getAverageMark(Discipline.Administration));
            Console.WriteLine("Student design average = " + student.getAverageMark(Discipline.Design));

            student.outputMarks();
        }
    }
}
