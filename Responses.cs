
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
                "-------------------------------------------------------------------------------\r\n-----██╗--██╗███████╗██████╗--██████╗-████████╗██████╗--██████╗-███╗---██╗-----\r\n-----╚██╗██╔╝██╔════╝██╔══██╗██╔═══██╗╚══██╔══╝██╔══██╗██╔═══██╗████╗--██║-----\r\n------╚███╔╝-█████╗--██████╔╝██║---██║---██║---██████╔╝██║---██║██╔██╗-██║-----\r\n------██╔██╗-██╔══╝--██╔══██╗██║---██║---██║---██╔══██╗██║---██║██║╚██╗██║-----\r\n-----██╔╝-██╗███████╗██║--██║╚██████╔╝---██║---██║--██║╚██████╔╝██║-╚████║-----\r\n-----╚═╝--╚═╝╚══════╝╚═╝--╚═╝-╚═════╝----╚═╝---╚═╝--╚═╝-╚═════╝-╚═╝--╚═══╝-----\r\n-------------------------------------------------------------------------------\r\n";
        }

        public string Welcome()
        {
            return "GREETINGS!";
        }

        public string NamePrompt()
        {
            return "What is your name?";
        }

        public string Warning()
        {
            return "ENTER THE CORRECT VALUE!!!";
        }
        public string Greetings(string name)
        {
            return "Pleased to meet you Mister " + name + ". My name is Xerotron. please tell me, how can i help you?";
        }
        public string EmailPhishing()
        {
            return "When you receive a suspected phishing email, stay calm and act safely. " +
                "Never click links, open attachments, or reply, as this can put your device or accounts at risk. " +
                "Quickly check the real sender address and hover over links to spot fake domains or urgent threats like “account will be locked. " +
                "Mark the email as phishing or spam in your email app, then delete it." +
                " Remember the golden rule: never trust an email that asks you to click or log in—always type the official website yourself." +
                "If you accidentally clicked or shared info, change your password immediately from a safe device, run a virus scan, and enable two-factor authentication. " +
                "Following these simple steps keeps you protected. " +
                " You’ve got this! If you see one now, share it and I’ll help. Stay secure, friend!";
        }

        public string SafePasswordPractices()
        {
            return "When it comes to staying safe online, strong password habits are essential. " +
                "Use unique, long passwords (at least 16 characters) for every account. " +
                "Never reuse the same password across different sites. " +
                "The easiest way is to use a reputable password manager — it creates and remembers strong passwords for you. " +
                "Always enable two-factor authentication, preferably with an app rather than SMS." +
                "Never share your passwords or write them down in plain sight. " +
                "Change them immediately if you suspect a breach.";
        }

        public string RecognizingSuspiciousLinks()
        {
            return "Learning to recognize suspicious link is one of the best skills you can have. " +
                "Before clicking any link in an email, message, or website, always hover your mouse over it without clicking to see where the real web address leads to. " +
                "Look carefully: does the link match the official site? For example, a fake link might say microsoft.com in the text but actually go to a sudo link example micr0soft-support.com. " +
                "Be extra careful with shortened links as they hide real destination.";
        }

        public string Decider()
        {
            return "Do you want to ask more questions?";
        }

    }
}
