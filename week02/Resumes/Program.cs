using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "SoftwareDeveloper";
        job1._company = "Skyfall Const.";
        job1._startYear = 2020;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._jobTitle = "ManagingDirector";
        job2._company = "JudOk247 Tech.";
        job2._startYear = 2025;
        job2._endYear = 2069;

        Resume resume1 = new Resume();
        resume1._name = "Okechukwu Igatta";

        // resume1.jobs.Add(job1);
        // resume1.jobs.Add(job2);

        resume1.Display();
    }
   
}