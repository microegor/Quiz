using System.Xml.Linq;

class QuizReader
{
    public static List<QuizQuestion> ReadQuizFromXml(string filePath)
    {
        var quizQuestions = new List<QuizQuestion>();
        var doc = XDocument.Load(filePath);

        foreach (var questionElement in doc.Descendants("Question"))
        {
            var questionText = questionElement.Element("Text").Value;
            var answers = new List<string>();
            int correctAnswerIndex = -1;

            foreach (var answerElement in questionElement.Descendants("Answer"))
            {
                answers.Add(answerElement.Value);
                if (answerElement.Attribute("correct") != null && answerElement.Attribute("correct").Value == "true")
                {
                    correctAnswerIndex = answers.Count - 1;
                }
            }

            quizQuestions.Add(new QuizQuestion
            {
                Question = questionText,
                Answers = answers,
                CorrectAnswerIndex = correctAnswerIndex
            });
        }

        return quizQuestions;
    }
}
