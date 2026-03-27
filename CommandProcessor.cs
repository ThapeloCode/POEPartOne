
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;

namespace XeroTron
{
    public class CommandProcessor
    {

        string name;
        string reply;
        string userResponse;

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

            //GREETINGS RESPONSE
            reply = Console.ReadLine().Trim().ToLower();
            UserGreetingsChecker(reply);

            //WELCOME MESSAGE
            PrintLogo(name);

            //RESPONSE
            userResponse = Console.ReadLine().Trim().ToLower();
            CheckResponse(userResponse);
            
        }

        private void PrintLogo(string name)
        {

            string greet = response.Greetings(name);
            speech.SpeakAsync(greet);

            //WAIT FOR SPEECH
            Thread.Sleep(950);

            string method = response.Logo();
            foreach (char letter in method)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(letter);
                Thread.Sleep(1);
            }
        }

        private void EndConversation(string userResponse)
        {
            
                if (userResponse == "exit" || userResponse == "quit" || userResponse == "thanks")
                {
                    TypeReader("Stay safe out there, mister " + name + ". Goodbye!");
                }
                else
                {
                    CheckResponse(userResponse);
                }
                Environment.Exit(0);
        }

        private void UserGreetingsChecker(string reply)
        {

            if (Regex.IsMatch(reply, @"\bhi\b") || Regex.IsMatch(reply, @"\bhy\b") || Regex.IsMatch(reply, @"\bhello\b") || Regex.IsMatch(reply, @"\bgreeting\b") || Regex.IsMatch(reply, @"\bhow are you\b"))
            {
                TypeReader(reply + "! " + response.NamePrompt());

                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine();
                while ( String.IsNullOrEmpty(name) || Regex.IsMatch(name, @"[^a-zA-Z0-9]")) 
                {
                    TypeReader(response.EmptyWarning());
                    TypeReader(" and cannot contain special characters");
                    Console.ForegroundColor = ConsoleColor.Green;
                    name = Console.ReadLine();

                }

            }
            else if (String.IsNullOrEmpty(reply)) {
                TypeReader(response.EmptyWarning());
                TypeReader(response.NamePrompt());
                name = Console.ReadLine();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeReader("Even though you don't greet");
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
                if (input == "exit" || input == "quit" || input == "thanks" || String.IsNullOrEmpty(input))
                {
                    EndConversation(input);
                }
                else
                {
                    TypeReader("I specialize in CyberSecurity. To Be Specific Phishing, Password and Links ");
                    TypeReader("Please ask questions related to Cybersecuruty");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine("TO QUIT:");
                    Console.WriteLine("[QUIT]                             [EXIT]                              [THANKS]");

                    Console.Write("REPLY: "); userResponse = Console.ReadLine().Trim().ToLower();
                    CheckResponse(userResponse);
                }

            }
        }

    }
}
