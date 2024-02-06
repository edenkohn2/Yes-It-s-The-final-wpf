using System.Windows;
using System;
using System.Timers;
using System.Windows.Threading;
using System.Windows.Media;


public class Game
{
    private Random random = new Random();
    private int number1;
    private int number2;
    private int correct_answer;
    private int possible1;
    private int possible2;
    private int points = 0;
    private int question_counter = 0;
    private int currentCorrectAnswer;
    private string op;
    private Timer questionTimer;
    private int timeRemaining;
    private MediaPlayer mediaPlayer;
    public Game(int number1, int number2, int correct_answer, int points, int question_counter, string op, int currentCorrectAnswer)
    {
        this.number1 = number1;
        this.number2 = number2;
        this.correct_answer = correct_answer;
        this.op = op;
        this.points = points;
        this.question_counter = question_counter;
        this.currentCorrectAnswer = currentCorrectAnswer;
   

    }

    public Game()
    {

    }
    

    public int GetPoints()
    {
        return points;
    }

    public void GenerateNewQuestion()
    {
        // Generate random numbers and operator
        number1 = RandomNums1();
        number2 = RandomNums2();
        op = Get_Operator();

        // Calculate and store the correct answer for the new question
        currentCorrectAnswer = GetCorrectAnswer(number1, number2, op);
    }
 

    public int RandomNums1()
    {
        this.number1 = random.Next(1, 11);
        
        return number1;
    }

    public int RandomNums2()
    {
        this.number2 = random.Next(1, 11);
       
        return number2;
    }

    public string Get_Operator()
    {
        op = random.Next(2) == 0 ? "+" : "-";
        
        return op;
    }

    public int GetCorrectAnswer(int num1 , int num2, string op)
    {
        if (op == "+")
        {
            return num1 + num2;
        }
        else
        {
            return num1 - num2;
        }
    }
    public void PlayAudio()
    {
        mediaPlayer.Play();
    }


    public void CheckAnswer(int userAnswer)
    {
        try
        {
            int correctAnswer = GetCorrectAnswer(number1, number2, op);

            if (correctAnswer == userAnswer)
            {
                this.points += 20;
                
                MessageBox.Show("Correct");
                
            }
            else
            {
                if (this.points >= 20)
                {
                    this.points -= 20;
                }
                MessageBox.Show("-20 Points :(");
            }

            NextQuestion();
        }
        catch (FormatException)
        {
            MessageBox.Show("Invalid input. Please enter a valid integer.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}");
        }
    }


    public bool IsGameFinished()
    {
        return question_counter >= 5;
    }

    public void NextQuestion()
    {
        if (question_counter < 5)
        {
            GenerateNewQuestion();
            question_counter++;
        }
        else
        {
            MessageBox.Show("You've completed all 5 questions!");
            MessageBox.Show("Thank You For Playing!");

            // Add additional logic for finishing the game
        }
    }
}
