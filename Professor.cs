
public class Professor

{
    public string Username { get; set; }
    public string Password { get; set; }
    
    public Professor(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public void AddMark(Student student, int mark)
    {
        student.AddMark(mark);
        Console.WriteLine($"Mark added for {student.Name}");
    }

    public void ViewStudentDetails(Student student)
    {
        Console.WriteLine($"Student ID: {student.StudentId}");
        Console.WriteLine($"Student Name: {student.Name}");
        student.ViewMarks();
    }
}
