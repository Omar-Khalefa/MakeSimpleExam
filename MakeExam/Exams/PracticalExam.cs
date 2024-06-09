using MakeExam.Questions;

namespace MakeExam.Exams
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int _time, int _numberOfQuestions) : base(_time, _numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new MCQQuestion[NumberOfQuestions];
            for (var i = 0; i < Questions?.Length; i++)
            {
                Questions[i] = new MCQQuestion();
                Questions[i].AddQuestion();
            }
            Console.Clear();
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                for (var i = 0; i < question?.Answers?.Length; i++)
                {
                    Console.WriteLine(question?.Answers[i]);
                }

                Console.WriteLine("----------------------------------------");
                int UserAns;
                do
                {
                    Console.WriteLine("Please Enter The Answer Id");

                } while (!(int.TryParse(Console.ReadLine(), out UserAns) && (UserAns is 1 or 2 or 3)));


                question.UserAnswer.Id = UserAns;
                question.UserAnswer.Text = question.Answers[UserAns - 1].Text;

                Console.Clear();

            }

                Console.WriteLine("Right Answers");

                for (int i = 0; i < Questions?.Length; i++)
                {
                    Console.WriteLine($"Question Number {i + 1} {Questions[i].Body}");

                    Console.WriteLine($"Right Answer => {Questions[i].RightAnswer.Text}");

                    Console.WriteLine("----------------------------------------------------------------------");
                }
        }
    }
}
