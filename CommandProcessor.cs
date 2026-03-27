
using System.Speech.Synthesis;
using System.Threading;

namespace XeroTron
{
    public class CommandProcessor
    {

        string name;

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
                else
                {
                    
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
            //GREET USER
            TypeReader(response.Welcome());

            //RESPONSE TO GREETINGS

            string reply = Console.ReadLine().Trim().ToLower();
            UserGreetingsChecker(reply);

            //PRINT LOGO
            string method = response.Logo();
            foreach (char letter in method)
            {
                Console.Write(letter);
                Thread.Sleep(4);
            }




            Console.ForegroundColor = ConsoleColor.White;
            TypeReader(response.Greetings(name));


            bool running = true;
        }

        private void EndConversation(Boolean running)
        {

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

                if (input == "exit" || input == "quit" || input == "thanks")
                {
                    TypeReader("Stay safe out there, mister " + name + ". Goodbye!");
                    running = false;
                }
                else
                {
                    CheckResponse(input);
                }
            }
        }

        private void UserGreetingsChecker(string reply)
        {


            if (reply == "hy" || reply == "hi" || reply == "hello" || reply == "hey" || reply == "greetings" || reply == "how are you")
            {
                TypeReader(response.NamePrompt());

                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine();
            }
            else {
                CheckResponse(reply);
            }
        }

        private void CheckResponse(string input)
        {
            if (input == "hy" || input == "hi" || input == "hello" || input == "hey" || input == "greetings" || input == "How are you")
            {
                TypeReader("Hello mister " + name + ", hope you are well, how can i help you?");
            }
            else if (input.Contains("email") || input.Contains("phishing"))
            {
                TypeReader(response.EmailPhishing());
            }
            else if (input.Contains("password"))
            {
                TypeReader(response.SafePasswordPractices());
            }
            else if (input.Contains("suspicious") || input.Contains("link"))
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
