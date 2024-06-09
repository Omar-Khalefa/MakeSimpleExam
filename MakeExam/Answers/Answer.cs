namespace MakeExam.Answers
{
    internal class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Answer(int _id, string _text)
        {

            Id = _id;
            Text = _text;
        }
        public Answer()
        {

        }
        public override string ToString()
        {
            return $"{Id} - {Text}";
        }
    }
}
