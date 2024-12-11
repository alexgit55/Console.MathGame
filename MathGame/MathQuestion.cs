/*
 * This class is reponsible for each math question
 * It generates the question and records whether the
 * user is correct or not
 */

namespace MathGame.alexgit55
{
    internal class MathQuestion
    {
        private int _operation;
        private int _lowerRange;
        private int _upperRange;
        public MathQuestion(int operation, int lowerRange, int upperRange)
        {
            _operation = operation;
            _lowerRange = lowerRange;
            _upperRange = upperRange;
        }

        internal int GenerateMathQuestion()
        {
            bool correct = false;
            switch (_operation)
            {
                case 0:
                    correct = Addition();
                    break;
                case 1:
                    correct = Subtraction();
                    break;
                case 2:
                    correct = Multiplication();
                    break;
                case 3:
                    correct = Division();
                    break;
            }

            if (correct)
                return 1;
            else
                return 0;
        }

        private bool Division()
        // Generate the division problem and check if the user's answer is correct
        {
            int userAnswer;
            int num1 = 0;
            int num2 = 1;
            // Generate two random numbers between lowerRange and upperRange
            // Ensure that num1 is divisible by num2
            do
            {
                Random rand = new();
                num1 = rand.Next(_lowerRange, _upperRange);
                num2 = rand.Next(_lowerRange, _upperRange);
            } while (num1 % num2 != 0);

            // Ask the user to solve the division problem
            Console.WriteLine($"What is the quotient of {num1} / {num2}?");

            while (!int.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Please enter a valid number.");
            }

            // Check if the user's answer is correct
            int correctAnswer = num1 / num2;
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct! Good job!\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
                return false;
            }
        }

        private bool Multiplication()
        // Generate the multiplication problem and check if the user's answer is correct
        {
            int userAnswer;
            // Generate two random numbers between lowerRange and upperRange

            Random rand = new();
            int num1 = rand.Next(_lowerRange, _upperRange);
            int num2 = rand.Next(_lowerRange, _upperRange);

            // Ask the user to solve the multiplication problem
            Console.WriteLine($"What is the product of {num1} * {num2}?");

            while (!int.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Please enter a valid number.");
            }

            // Check if the user's answer is correct
            int correctAnswer = num1 * num2;
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct! Good job!\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
                return false;
            }
        }

        private bool Subtraction()
        // Generate the subtraction problem and check if the user's answer is correct
        {
            // Generate two random numbers between lowerRange and upperRange
            //keep generating while num1 <= num2
            int num1;
            int num2;
            int userAnswer;
            do
            {
                Random rand = new();
                num1 = rand.Next(_lowerRange, _upperRange);
                num2 = rand.Next(_lowerRange, _upperRange);
            } while (num1 <= num2);

            // Ask the user to solve the subtraction problem
            Console.WriteLine($"What is the difference of {num1} - {num2}?");

            while (!int.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Please enter a valid number.");
            }

            // Check if the user's answer is correct
            int correctAnswer = num1 - num2;
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct! Good job!\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
                return false;
            }
        }

        private bool Addition()
        // Generate the addition problem and check if the user's answer is correct
        {
            int userAnswer;
            // Generate two random numbers between lower range and upper range
            Random rand = new();
            int num1 = rand.Next(_lowerRange, _upperRange);
            int num2 = rand.Next(_lowerRange, _upperRange);

            //Ask the user to solve the addition problem
            Console.WriteLine($"What is the sum of {num1} + {num2}?");

            while (!int.TryParse(Console.ReadLine(), out userAnswer))
            {
                Console.WriteLine("Please enter a valid number.");
            }

            // Check if the user's answer is correct
            int correctAnswer = num1 + num2;
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct! Good job!\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Incorrect. The correct answer is {correctAnswer}\n");
                return false;
            }
        }
    }
}
