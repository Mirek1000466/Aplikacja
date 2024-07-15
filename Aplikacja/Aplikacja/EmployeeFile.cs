using System.Reflection.PortableExecutable;

namespace Aplikacja
{
    public class EmployeeFile : EmployeeBase
    {
        public override event GradeAddedDelegate GradeAdded;

        public EmployeeFile(string name, string surname, string dateOfBirth, string sex, string fileName)
            : base(name, surname, dateOfBirth, sex)
        {
            this.FileName = fileName;
        }
        public string FileName { get; private set; }

        public override void AddGrade(double grade)
        {
            float result = (float)grade;
            this.AddGrade(result);
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 50)
            {
                using (var writer = File.AppendText(this.FileName))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null) GradeAdded(this, new EventArgs());
                }
            }
            else throw new Exception("Podano błędną ocenę!");
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                AddGrade(result);
            }
            else
            {
                if (grade.Length == 1) AddGrade(grade[0]);
                else throw new Exception("BŁĄD [A..F]/[1..50]");
            }
        }

        public override void AddGrade(char grade)
        {
            switch (grade) 
            {
                case 'A':
                case 'a': 
                    {
                        AddGrade(50);
                        break; 
                    }
                case 'B':
                case 'b':
                    { 
                        AddGrade(40);
                        break; 
                    }
                case 'C':
                case 'c':
                    {
                        AddGrade(30);
                        break; 
                    }
                case 'D':
                case 'd':
                    {
                        AddGrade(20); 
                        break; 
                    }
                case 'E':
                case 'e':
                    {
                        AddGrade(10);
                        break; 
                    }
                case 'F':
                case 'f':
                    {
                        AddGrade(0); 
                        break; 
                    }
                default: 
                    {
                        throw new Exception("BŁĄD [A..F]/[a..f]");
                    }
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            if(File.Exists(FileName)) 
            {
                using (var reader = File.OpenText(FileName))
                {
                    var lineNumber = 4;
                    var line = "";
                    while (line != null)
                    {
                        if (lineNumber < 5)
                        {
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                            line = reader.ReadLine();
                        }
                        else if(line !="") statistics.AddGrade(float.Parse(line));
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        }
    }
}
