public class StudentManagementSystem
{
    private List<Student> students = new List<Student>();
    private List<Professor> professors = new List<Professor>();

    public StudentManagementSystem()
    {
        
        professors.Add(new Professor("sathish", "Sathish@2001"));
        students.Add(new Student("1", "Gohul"));
        students.Add(new Student("2", "Hari@2001"));
    }

    public bool AuthenticateStudent(string studentId, string password)
    {
        
        return students.Any(s => s.StudentId == studentId);
    }

    public bool AuthenticateProfessor(string username, string password)
    {
        return professors.Any(p => p.Username == username && p.Password == password);
    }

    public void StudentLogin()
    {
        Console.Write("Enter Student ID: ");
        string studentId = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = ReadPassword(); 

        if (AuthenticateStudent(studentId, password))
        {
            var student = students.FirstOrDefault(s => s.StudentId == studentId);
            Console.WriteLine("Login Successful! Welcome, " + student.Name);
            student.ViewMarks();
        }
        else
        {
            Console.WriteLine("Invalid credentials!");
        }
    }

    public void ProfessorLogin()
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter Password: ");
        string password = ReadPassword();

        if (AuthenticateProfessor(username, password))
        {
            Console.WriteLine("Login Successful! Welcome, Professor " + username);
            HandleProfessorActions();
        }
        else
        {
            Console.WriteLine("Invalid credentials!");
        }
    }
    private string ReadPassword()
{
    string password = string.Empty;
    while (true)
    {
        var key = Console.ReadKey(true); 
        if (key.Key == ConsoleKey.Enter) break;
        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
        {
            password = password.Substring(0, password.Length - 1);
            Console.Write("\b \b"); 
        }
        else
        {
            password += key.KeyChar;
            Console.Write("*"); 
        }
    }
    Console.WriteLine(); 
    return password;
}

    public void HandleProfessorActions()
    {
        Console.WriteLine("1. View Student Details");
        Console.WriteLine("2. Add Student Marks");
        Console.WriteLine("3. Logout");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewStudentDetails();
                break;
            case "2":
                AddMarksToStudent();
                break;
            case "3":
                Console.WriteLine("Logging out...");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    public void ViewStudentDetails()
    {
        Console.Write("Enter Student ID: ");
        string studentId = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.StudentId == studentId);

        if (student != null)
        {
            var professor = professors.FirstOrDefault(); 
            professor.ViewStudentDetails(student);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void AddMarksToStudent()
    {
        Console.Write("Enter Student ID: ");
        string studentId = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.StudentId == studentId);

        if (student != null)
        {
            Console.Write("Enter Mark: ");
            if (int.TryParse(Console.ReadLine(), out int mark) && mark >= 0 && mark <= 100)
            {
                var professor = professors.FirstOrDefault();
                professor.AddMark(student, mark);
            }
            else
            {
                Console.WriteLine("Invalid mark.");
            }
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}
