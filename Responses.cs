
using System;
using System.Collections.Generic;
using System.Text;

namespace XeroTron
{
    internal class Responses
    {
        public string LineSeparator()
        {
            return
                "-------------------------------------------------------------------------------";
        }
        public string Logo()
        {
            return
                "\n-------------------------------------------------------------------------------\r\n-----██╗--██╗███████╗██████╗--██████╗-████████╗██████╗--██████╗-███╗---██╗-----\r\n-----╚██╗██╔╝██╔════╝██╔══██╗██╔═══██╗╚══██╔══╝██╔══██╗██╔═══██╗████╗--██║-----\r\n------╚███╔╝-█████╗--██████╔╝██║---██║---██║---██████╔╝██║---██║██╔██╗-██║-----\r\n------██╔██╗-██╔══╝--██╔══██╗██║---██║---██║---██╔══██╗██║---██║██║╚██╗██║-----\r\n-----██╔╝-██╗███████╗██║--██║╚██████╔╝---██║---██║--██║╚██████╔╝██║-╚████║-----\r\n-----╚═╝--╚═╝╚══════╝╚═╝--╚═╝-╚═════╝----╚═╝---╚═╝--╚═╝-╚═════╝-╚═╝--╚═══╝-----\r\n-------------------------------------------------------------------------------\r\n";
        }

        public string Welcome()
        {
            return "GREETINGS!";
        }

        public string NamePrompt()
        {
            return "What is your name?";
        }

        public string EmptyWarning()
        {
            return "VALUE CANNOT BE EMPTY!";
        }
        public string Greetings(string name)
        {
            return "Pleased to meet you Mister " + name + ". My name is Xerotron. A Cybersecurity assistance. Please tell me, how can i help you?";
        }
        public string EmailPhishing()
        {
            return "A suspected phishing email, stay calm and act safely. " +
                "Never click links, open \nattachments, or reply, as this can put your device or accounts at risk. " +
                "\nQuickly check the real sender address and hover over links to spot fake domains \nor urgent threats like “account will be locked. " +
                "Mark the email as phishing or \nspam in your email app, then delete it. " +
                "Remember the golden rule: never trust \nan email that asks you to click or log in—always type the official website \nyourself. " +
                "If you accidentally clicked or shared info, change your password \nimmediately from a safe device, run a virus scan, and enable two-factor \nauthentication. " +
                "Following these simple steps keeps you protected. " +
                "You’ve got \nthis! If you see one now, share it and I’ll help. Stay secure my friend!";
        }

        public string SafePasswordPractices()
        {
            return "When it comes to staying safe online, strong password habits are essential. " +
                "Use \nunique, long passwords (at least 16 characters) for every account. " +
                "Never reuse \nthe same password across different sites. " +
                "The easiest way is to use a reputable \npassword manager — it creates and remembers strong passwords for you. " +
                "Always \nenable two-factor authentication, preferably with an app rather than SMS." +
                "Never \nshare your passwords or write them down in plain sight. " +
                "Change them immediately \nif you suspect a breach.";
        }

        public string RecognizingSuspiciousLinks()
        {
            return "Learning to recognize suspicious link is one of the best skills you can have. " +
                "\nBefore clicking any link in an email, message, or website, always hover your \nmouse over it without clicking to see where the real web address leads to. " +
                "Look \ncarefully: does the link match the official site? For example, a fake link \nmight say microsoft.com in the text but actually go to a sudo link example \nmicr0soft-support.com. " +
                "Be extra careful with shortened links as they hide real \ndestination.";
        }

        public string Decider()
        {
            return "Do you want to ask more questions?";
        }

    }
}
