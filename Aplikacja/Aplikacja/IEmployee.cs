using static Aplikacja.EmployeeBase;

namespace Aplikacja
{
    public interface IEmployee
    {
        event GradeAddedDelegate GradeAdded;
        string Name { get;}
        string Surname { get;} 
        string DateOfBirth { get;}
        string Sex { get;}
        void AddGrade(double grade);
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(char grade);
        Statistics GetStatistics(); 
    }
}
