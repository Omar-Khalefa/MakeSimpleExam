using MakeExam.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeExam.Questions
{
    internal class TFQuestion : Question
    {
        public override string Header => "True Or False Question";

        public TFQuestion()
        {
            Answers = new Answer[2];
            Answers[0] = new Answer(1, "True");
            Answers[1] = new Answer(2, "Fals");
        }
        public override void AddQuestion()
        {
            // Header
            Console.WriteLine(Header);

            //Get The Questions
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

            //Get the Right Answer

            int rightAnswerId;
            do
            {
                Console.WriteLine("Please Enter the right Answer id (1 for true | 2 For False)");
            } while (!(int.TryParse(Console.ReadLine(), out rightAnswerId) && rightAnswerId is 1 or 2));

            RightAnswer.Id = rightAnswerId;
            RightAnswer.Text = Answers[rightAnswerId - 1].Text;
            Console.Clear();
        }
    }
}
