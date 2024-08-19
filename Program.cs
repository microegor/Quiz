using System;
using System.Collections.Generic;
using System.Xml.Linq;

class QuizQuestion
{
    public string Question { get; set; }
    public List<string> Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }
}

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

// Example usage
class Program
{
    static void Main(string[] args)
    {
        var quizQuestions = QuizReader.ReadQuizFromXml(args[0]);
        foreach (var question in quizQuestions)
        {
            Console.WriteLine($"Question: {question.Question}");
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i]}");
            }
            Console.Write("Введите номер правильного ответа: ");
            int answerIndex = int.Parse(Console.ReadLine()) - 1;
            if (answerIndex == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Правильно!");
            }
            else
            {
                Console.WriteLine("Неправильно!");
            }
            Console.WriteLine();
        }
    }
}