using System;

public class Resume
{
   public string _name;
   public List<Job> _jobs = new List<Job>();
 
   public void Display()
   {
    //  console.WriteLine($"Name: {_name}");
    //  console.WriteLine("Jobs:");
 
     foreach (Job job in _jobs)
     {
         job.Display();
     }
   }
}