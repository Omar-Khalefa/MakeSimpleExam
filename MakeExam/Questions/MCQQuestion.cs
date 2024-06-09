using MakeExam.Answers;

namespace MakeExam.Questions
{
    internal class MCQQuestion : Question
    {
        public override string Header => "MCQ Question";

        public MCQQuestion()
        {
            Answers = new Answer[3];
        }
        public override void AddQuestion()
        {
            //Header
            Console.WriteLine(Header);

            //Get Question

            do
            {
                Console.WriteLine("Please Enter Question Body");
                Body = Console.ReadLine();


            } while (string.IsNullOrWhiteSpace(Body));

            //Get the Mark
            int mark;
            do
            {
                Console.WriteLine("Please Enter Question Mark");

            } while (!int.TryParse(Console.ReadLine(), out mark));

            Mark = mark;


            //Get The Answers
            Console.WriteLine("Choices Of Question");

            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = new Answer() { Id = i + 1 };

                // Text
                do
                {
                    Console.WriteLine($"Please Enter Choice Number {i + 1}");
                    Answers[i].Text = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(Answers[i].Text));

            }

            //Get the Right Answer

            int rightAnswerId;
            do
            {
                Console.WriteLine("Please Enter the right Answer id");
            } while (!(int.TryParse(Console.ReadLine(), out rightAnswerId) && (rightAnswerId is 1 or 2 or 3)));

            RightAnswer.Id = rightAnswerId;
            RightAnswer.Text = Answers[rightAnswerId - 1].Text;
            Console.Clear();
        }
    }
}
