using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int correctAnswersCounter = 0;
        int wrongAnswersCounter = 0;
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
                correctAnswersCounter++;
            }
            else
            {
                Console.WriteLine("Неправильно!");
                wrongAnswersCounter++;
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Правильных ответов: {correctAnswersCounter}");
        Console.WriteLine($"Неправильных ответов: {wrongAnswersCounter}");
    }
}