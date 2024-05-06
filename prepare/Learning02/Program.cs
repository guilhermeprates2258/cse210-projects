using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "student";
        job1._company = "BYU";
        job1._startYear = 2019;
        job1._endYear = 2027;
        Job job2 = new Job();
        job2._jobTitle = "assistant";
        job2._company = "DB1";
        job2._startYear = 2022;
        job2._endYear = 2023;
        Resume myResume = new Resume();
        myResume._name = "Guilherme Prates";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}