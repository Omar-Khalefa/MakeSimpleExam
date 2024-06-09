using MakeExam.Questions;
using System.Diagnostics;

namespace MakeExam.Exams
{
    internal class FinalExam : Exam
    {
        public FinalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new Question[NumberOfQuestions];
            for (var i = 0; i < Questions?.Length; i++)
            {
                int QuestionType;
                do
                {

                    Console.WriteLine("Please Enter Type Of Question (1 for MCQ | 2 For True | False)");

                } while (!(int.TryParse(Console.ReadLine(), out QuestionType) && QuestionType is 1 or 2));

                if(QuestionType is 1)
                {
                    Questions[i] = new MCQQuestion();
                    Questions[i].AddQuestion();
                }
                else
                {
                    Questions[i] = new TFQuestion();
                    Questions[i].AddQuestion();
                }
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            //Show Questions
           foreach (var question in Questions)
            {
                Console.WriteLine(question);

                //Show Answers
                for (int i = 0; i < question?.Answers?.Length; i++)
                    Console.WriteLine(question.Answers[i]);

                //Get User Answer
                int userAnswerId;
             if (question?.GetType() == typeof(MCQQuestion))
                {
                    do
                    {
                        Console.WriteLine("Please Enter The Answer Id");
                    } while (!(int.TryParse(Console.ReadLine(), out userAnswerId) && (userAnswerId is 1 or 2 or 3)));
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Please Enter The Answer Id (1 For True | 2 For False)");
                    } while (!(int.TryParse(Console.ReadLine(), out userAnswerId) && (userAnswerId is 1 or 2)));
                }


                Console.Clear();




            }
                // Calculate Marks

                int Grade =0 , TotalMark = 0;

                for(var i  = 0; i < Questions?.Length; i++)
                {
                    TotalMark += Questions[i].Mark;
                    if (Questions[i].RightAnswer.Id == Questions[i].UserAnswer.Id)
                    {
                        Grade += Questions[i].Mark;
                    }

                    Console.WriteLine($"Question {i + 1} : {Questions[i].Body}");
                    Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.Text}");
                    Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.Text}");
                }
                Console.WriteLine($"Your Grade is {Grade} from {TotalMark}");
        }
    }
}
