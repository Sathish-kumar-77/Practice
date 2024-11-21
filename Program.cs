
public class Program

{
    static void Main(string[] args)
    {
        var system = new StudentManagementSystem();

        while (true)
        {
            Console.WriteLine("1. Student Login");
            Console.WriteLine("2. Professor Login");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    system.StudentLogin();
                    break;
                case "2":
                    system.ProfessorLogin();
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}
