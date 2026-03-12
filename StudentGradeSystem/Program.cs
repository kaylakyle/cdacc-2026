using System;

namespace StudentGradeAwardingSystem
{
    // Enum for possible outcomes
    public enum ExamResult
    {
        Pass,
        Fail
    }

    public enum WorkStatus
    {
        Satisfactory,
        Unsatisfactory
    }

    public enum Action
    {
        AwardPass,
        ResubmitWork,
        FailCourse,
        ResitExamination
    }

    // Decision Table Class
    public class GradeDecisionTable
    {
        // Decision Table represented as a list of rules
        private List<DecisionRule> decisionRules;

        public GradeDecisionTable()
        {
            InitializeDecisionTable();
        }

        private void InitializeDecisionTable()
        {
            decisionRules = new List<DecisionRule>
            {
                // Rule 1: Pass everything - Award Pass
                new DecisionRule
                {
                    ConditionExam = ExamResult.Pass,
                    ConditionCourseWork = WorkStatus.Satisfactory,
                    ConditionProject = WorkStatus.Satisfactory,
                    Action = Action.AwardPass
                },
                
                // Rule 2: Pass exam, Satisfactory course work, Unsatisfactory project - Resubmit Work
                new DecisionRule
                {
                    ConditionExam = ExamResult.Pass,
                    ConditionCourseWork = WorkStatus.Satisfactory,
                    ConditionProject = WorkStatus.Unsatisfactory,
                    Action = Action.ResubmitWork
                },
                
                // Rule 3: Pass exam, Unsatisfactory course work, Satisfactory project - Resubmit Work
                new DecisionRule
                {
                    ConditionExam = ExamResult.Pass,
                    ConditionCourseWork = WorkStatus.Unsatisfactory,
                    ConditionProject = WorkStatus.Satisfactory,
                    Action = Action.ResubmitWork
                },
                
                // Rule 4: Pass exam, Both unsatisfactory - Resubmit Work
                new DecisionRule
                {
                    ConditionExam = ExamResult.Pass,
                    ConditionCourseWork = WorkStatus.Unsatisfactory,
                    ConditionProject = WorkStatus.Unsatisfactory,
                    Action = Action.ResubmitWork
                },
                
                // Rule 5: Fail exam, Both satisfactory - Re-sit Examination
                new DecisionRule
                {
                    ConditionExam = ExamResult.Fail,
                    ConditionCourseWork = WorkStatus.Satisfactory,
                    ConditionProject = WorkStatus.Satisfactory,
                    Action = Action.ResitExamination
                },
                
                // Rule 6: Fail exam, Satisfactory course work, Unsatisfactory project - Fail Course
                new DecisionRule
                {
                    ConditionExam = ExamResult.Fail,
                    ConditionCourseWork = WorkStatus.Satisfactory,
                    ConditionProject = WorkStatus.Unsatisfactory,
                    Action = Action.FailCourse
                },
                
                // Rule 7: Fail exam, Unsatisfactory course work, Satisfactory project - Fail Course
                new DecisionRule
                {
                    ConditionExam = ExamResult.Fail,
                    ConditionCourseWork = WorkStatus.Unsatisfactory,
                    ConditionProject = WorkStatus.Satisfactory,
                    Action = Action.FailCourse
                },
                
                // Rule 8: Fail exam, Both unsatisfactory - Fail Course
                new DecisionRule
                {
                    ConditionExam = ExamResult.Fail,
                    ConditionCourseWork = WorkStatus.Unsatisfactory,
                    ConditionProject = WorkStatus.Unsatisfactory,
                    Action = Action.FailCourse
                }
            };
        }

        // Method to determine action based on conditions
        public Action DetermineAction(ExamResult examResult, WorkStatus courseWork, WorkStatus project)
        {
            var rule = decisionRules.Find(r => 
                r.ConditionExam == examResult && 
                r.ConditionCourseWork == courseWork && 
                r.ConditionProject == project);

            if (rule == null)
            {
                throw new InvalidOperationException("No matching rule found in decision table");
            }

            return rule.Action;
        }

        // Display decision table
        public void DisplayDecisionTable()
        {
            Console.WriteLine("STUDENT GRADE AWARDING DECISION TABLE");
            Console.WriteLine("=======================================");
            Console.WriteLine("| Exam Pass | Course Work | Project | Action Taken |");
            Console.WriteLine("|-----------|-------------|---------|--------------|");

            foreach (var rule in decisionRules)
            {
                Console.WriteLine($"| {rule.ConditionExam,-9} | {rule.ConditionCourseWork,-11} | {rule.ConditionProject,-7} | {rule.Action,-12} |");
            }
        }
    }

    // Decision Rule Class
    public class DecisionRule
    {
        public ExamResult ConditionExam { get; set; }
        public WorkStatus ConditionCourseWork { get; set; }
        public WorkStatus ConditionProject { get; set; }
        public Action Action { get; set; }
    }

    // Student Class
    public class Student
    {
        public string Name { get; set; }
        public ExamResult ExamResult { get; set; }
        public WorkStatus CourseWork { get; set; }
        public WorkStatus Project { get; set; }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"\nStudent: {Name}");
            Console.WriteLine($"Exam Result: {ExamResult}");
            Console.WriteLine($"Course Work: {CourseWork}");
            Console.WriteLine($"Project: {Project}");
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Create decision table
            GradeDecisionTable decisionTable = new GradeDecisionTable();
            
            // Display the decision table
            decisionTable.DisplayDecisionTable();

            // Test the decision table with sample students
            TestDecisionTable(decisionTable);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void TestDecisionTable(GradeDecisionTable decisionTable)
        {
            // Create test students
            var students = new List<Student>
            {
                new Student { Name = "John Doe", ExamResult = ExamResult.Pass, CourseWork = WorkStatus.Satisfactory, Project = WorkStatus.Satisfactory },
                new Student { Name = "Jane Smith", ExamResult = ExamResult.Pass, CourseWork = WorkStatus.Satisfactory, Project = WorkStatus.Unsatisfactory },
                new Student { Name = "Bob Johnson", ExamResult = ExamResult.Fail, CourseWork = WorkStatus.Satisfactory, Project = WorkStatus.Satisfactory },
                new Student { Name = "Alice Brown", ExamResult = ExamResult.Fail, CourseWork = WorkStatus.Unsatisfactory, Project = WorkStatus.Unsatisfactory }
            };

            Console.WriteLine("\n\nTESTING DECISION TABLE WITH SAMPLE STUDENTS");
            Console.WriteLine("=============================================");

            foreach (var student in students)
            {
                student.DisplayStudentInfo();
                
                Action action = decisionTable.DetermineAction(
                    student.ExamResult, 
                    student.CourseWork, 
                    student.Project);
                
                Console.WriteLine($"Recommended Action: {action}");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}