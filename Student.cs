public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public List<int> Marks { get; set; }

    public Student(string studentId, string name)
    {
        StudentId = studentId;
        Name = name;
        Marks = new List<int>();
    }

    public void AddMark(int mark)
    {
        Marks.Add(mark);
    }

    public void ViewMarks()
    {
        Console.WriteLine($"Marks for {Name}: ");
        foreach (var mark in Marks)
        {
            Console.WriteLine(mark);
        }
    }
    
}
