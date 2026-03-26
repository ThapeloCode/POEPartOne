
using System.Speech.Synthesis;
using System.Threading;

namespace XeroTron
{
    public class CommandProcessor
    {

        string name;
        string input;

        private SpeechSynthesizer speech = new SpeechSynthesizer();
        private Responses response = new Responses();


        private void TypeReader(string method)
        {

            speech.SpeakAsync(method);

            //WAIT FOR SPEECH
            Thread.Sleep(850);

            foreach (char letter in method)
            {

                Console.Write(letter);
                //CONTROL PANCTUATION
                if (letter == '.' || letter == '?' || letter == '!')
                {
                    Thread.Sleep(250);
                }
                else if (letter == ',')
                {
                    Thread.Sleep(100);

                }

                //OVERALL TYPING EFFECT
                Thread.Sleep(55);
            }
            //WAIT FOR VOICE TO FINISH
            Thread.Sleep(3000);
            Console.WriteLine();


        }

        public void Run()
        {
            response.Logo();
            TypeReader(response.Welcome());

            Console.ForegroundColor = ConsoleColor.Green;
            name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            TypeReader(response.Greetings(name));

            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine()?.Trim().ToLower();
                Console.ForegroundColor = ConsoleColor.White;

                if (string.IsNullOrEmpty(input))
                {
                    TypeReader(response.Warning());
                    continue;
                }

                if (input == "exit" || input == "quit")
                {
                    TypeReader("Stay safe out there, " + name + ". Goodbye!");
                    running = false;
                }
                else
                {
                    CheckResponse(input);
                }
            }
        }

        public void CheckResponse(string input)
        {
            // Compare against lowercase because of .ToLower()
            if (input == "hi" || input == "hello" || input == "hey" || input == "greetings")
            {
                TypeReader("Hello!!! " + name + ", how can I help you?");
            }
            else if (input.Contains("email") || input.Contains("phishing"))
            {
                TypeReader(response.EmailPhishing());
            }
            else if (input.Contains("password"))
            {
                TypeReader(response.SafePasswordPractices());
            }
            else if (input.Contains("suspicious") || input.Contains("link")) // Fixed typo "suspecious"
            {
                TypeReader(response.RecognizingSuspiciousLinks());
            }
            else
            {
                TypeReader("I'm specialized in CyberSecurity. Please ask about passwords, phishing, or suspicious links.");
            }
        }

    }
}
