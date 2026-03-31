
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;

namespace XeroTron
{
    public class CommandProcessor
    {

        string userName;
        string userGreetings;
        string userResponse;

        private SpeechSynthesizer speech = new SpeechSynthesizer();
        private Responses response = new Responses();


        //RUN METHODS IN ORDER TO HIDE COMPLEXITY IN THE MAIN METHOD
        public void Run()
        {
            //GREET USER
            TypeReader(response.Welcome());

            //GREETINGS RESPONSEConsole.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nREPLY : ");
            Console.ResetColor();

            userGreetings = Console.ReadLine().Trim().ToLower();
            UserGreetingsChecker(userGreetings);

            //WELCOME MESSAGE
            PrintLogo(userName);

            //RESPONSE
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nREPLY : ");
            Console.ResetColor();

            userResponse = Console.ReadLine().Trim().ToLower();
            CheckResponse(userResponse);

        }


        //USES THREADING SLEEP METHOD TO ENABLE INPUT TO SPEAK AND WRITE SEMULTENEOUSLY
        private void TypeReader(string method)
        {
            
            speech.SpeakAsync(method);

            //WAIT FOR TEXT TO KICK IN
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

                //OVERALL TYPING EFFECT SPEED
                Thread.Sleep(55);
            }
            //WAIT FOR VOICE TO FINISH
            Thread.Sleep(3000);
            Console.WriteLine();


        }

        
        //THREADS USE SLEEP TO RUN SPEECH AND ASCII SEMULTENEOUSLY 
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
                Console.ResetColor();
                Thread.Sleep(1);
            }
        }

        //IF USER INPUT CONTAINS THE TRIGGERING WORD THIS METHOD ENDS OPERATION
        private void EndConversation()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeReader("Appreciate the visit Mister " + userName +". Goodbye!");
            Console.ResetColor();
            Environment.Exit(0);
        }


        private void UserGreetingsChecker(string reply)
        {
            if (Regex.IsMatch(reply, @"\bhi\b") || Regex.IsMatch(reply, @"\bhy\b") || Regex.IsMatch(reply, @"\bhello\b") || Regex.IsMatch(reply, @"\bgreeting\b") || Regex.IsMatch(reply, @"\bhow are you\b"))
            {
                TypeReader(reply + "! " + response.NamePrompt());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nNAME  : ");
                Console.ResetColor();

                userName = Console.ReadLine();

                while (String.IsNullOrEmpty(userName) || Regex.IsMatch(userName, @"[^a-zA-Z0-9]") || userName == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeReader(response.EmptyWarning());
                    TypeReader("AND CANNOT CONTAIN SPECIAL CHARACTERS!");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nNAME  : ");
                    Console.ResetColor();

                    userName = Console.ReadLine();
                }
            }
            else if (String.IsNullOrEmpty(reply))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeReader(response.EmptyWarning());
                TypeReader(response.NamePrompt());
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nNAME  : ");
                Console.ResetColor();

                userName = Console.ReadLine();

                while (String.IsNullOrEmpty(userName) || Regex.IsMatch(userName, @"[^a-zA-Z0-9]") || userName == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeReader(response.EmptyWarning());
                    TypeReader("AND CANNOT CONTAIN SPECIAL CHARACTERS!");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nNAME  : ");
                    Console.ResetColor();

                    userName = Console.ReadLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeReader("Even though you don't greet");
                Console.ResetColor();
                CheckResponse(reply);
            }
        }


        //METHOD USES IF STATEMENTS AND VARIETY OF USER INPUT TO DECIDE THE DIRECTION OF THE CONVERSATION
        private void CheckResponse(string input)
        {
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(input) || input == "exit" || input == "quit" || input == "thanks" || input == "x")
            {
                EndConversation();
                return;
            }

            if (input == "hy" || input == "hi" || input == "hello" || input == "hey" || input == "greetings" || input == "good" || input == "gud" )
            {
                TypeReader("Hello Mister " + userName + ", hope you are well. How can I help you?");
            }

            else if (input.Contains("email") || input.Contains("phishing"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.LineSeparator());
                Console.ResetColor();

                TypeReader(response.EmailPhishing());
            }

            else if (input.Contains("password"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.LineSeparator());
                Console.ResetColor();

                TypeReader(response.SafePasswordPractices());
            }

            else if (input.Contains("suspicious") || input.Contains("link"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.LineSeparator());
                Console.ResetColor();

                TypeReader(response.RecognizingSuspiciousLinks());
            }

            else if (input.Contains("how are you"))
            {
                TypeReader("I am well, thank you! Feel free to ask me about cybersecurity.");
            }

            else if (input.Contains("what's your purpose") || input.Contains("what is your purpose"))
            {

                TypeReader("To assist you maneuver this hard-to-understand digital age. You can ask me about \nemail phishing, suspicious links, and safe password practices.");
                
            }

            else if (input.Contains("what can i ask you"))
            {
                TypeReader("I am well trained for Cybersecurity field, if you have any questions about Email Phishing, Suspicious Links and Safe Password Practices");
            }


            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeReader("I specialize in Cybersecurity. To be specific in Phishing, Passwords, and Links.");
                TypeReader("Please ask a related question or type 'exit' to quit.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nREPLY : ");
            Console.ResetColor();

            userResponse = Console.ReadLine()?.Trim().ToLower();

            CheckResponse(userResponse);
        }

    }
}
