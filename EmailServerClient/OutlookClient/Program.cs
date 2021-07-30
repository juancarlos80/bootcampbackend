using System;
using System.Collections.Generic;

namespace OutlookClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** OutlookConsole Client ****************");
            MailServer server = new( GetExampleClients(), new ReceiverEmail(), new SenderEmail() );

            Console.ReadLine();

            //Send Email without rules Test 
            Console.WriteLine("Send Email without rules Test ");
            Email email0 = new()
            {
                To = "test1@testmail.com",
                From = "progran@testmail.com",
                Subject = "Test Mail Server",
                Body = "Prueba de correo",
                IpOrigin = "182.78.12.123"
            };

            server.RecieveEmail(email0);
            Console.ReadLine();

            //Send Mail that apply a Social Rule Test 
            Console.WriteLine("Send Mail that apply a Social Rule Test ");
            Email email1 = new() {
                To = "test1@testmail.com",
                From = "progran@testmail.com",
                Subject = "Facebook Friend",
                Body = "Prueba de correo",
                IpOrigin = "182.78.12.123"
            };

            server.RecieveEmail(email1);            
            Console.ReadLine();

            //Add Client to the server
            Console.WriteLine("Add Client to the server");
            var client3 = new ClientSMTP()
            {
                AccountName = "TestUser3",
                Username = "test3@testmail.com",
                Password = "12345a6",
                ServerName = "testmail.com",
                Port = 456,
            };

            server.Clients.Add(client3);

            Console.WriteLine("Clientes Server: {0}", server.Clients.Count);
            Console.ReadLine();

            Console.WriteLine("Test send emails from new client");
            //Test send emails from new client
            Email email2 = new()
            {
                To = "test1@testmail.com",
                From = "test3@testmail.com",
                Subject = "Facebook Friend Suggest",
                Body = "Prueba de correo",
                IpOrigin = "182.78.12.123"
            };

            server.SendEmail(email2, client3);
            Console.WriteLine();
            Console.ReadLine();


            //Add New Out Rule Email in Client
            Console.WriteLine("Add New Out Rule Email in Client - Delete Mail in CC");
            Rule rule1 = new Rule("Delete Mail in CC");
            rule1.Conditions.Add( new ConditionContact("Username", "CC") );
            rule1.Actions.Add( new ActionDeleteMail() );
            client3.RulesOut.Add(rule1);

            //Test send emails from new client
            Email email3 = new()
            {
                To = "test1@testmail.com",
                From = "test2@testmail.com",
                CC = "test3@testmail.com",
                Subject = "Copy of the document",
                Body = "Prueba de correo",
                IpOrigin = "182.78.12.123"
            };

            server.SendEmail(email3, client3);
            Console.ReadLine();


            //Create New Folder and Create a New Rule to the new Folder
            Console.WriteLine("Create New Folder and Create a New Rule to the new Folder");
            client3.Folders.Add("Work", new List<Email>());

            //Add New In Rule Email in Client
            Rule rule2 = new Rule("Move to Work Folder");
            rule2.Conditions.Add(new ConditionKeyWord("Subject", "Jala"));
            rule2.Actions.Add(new ActionMove("Work"));
            client3.RulesIn.Add(rule2);


            //Test send emails from new client
            Email email4 = new()
            {
                To = "test3@testmail.com",
                From = "test1@testmail.com",
                Subject = "Jala Meeting",
                Body = "Prueba de correo",
                IpOrigin = "182.78.12.13"
            };

            server.RecieveEmail(email4);            
            Console.ReadLine();

            //Action Delete Mail
            Console.WriteLine("Delete Mails function, email: {0}", email4.Subject);
            var deleteMail = new ActionDeleteMail();
            deleteMail.Execute(client3, email4);            
            client3.ShowStatusUSer();
            Console.ReadLine();

            //Action Delete Folder
            string folderDelete = "Work";
            Console.WriteLine("Delete Folder client: {0}", folderDelete);
            var deleteFolder = new ActionDeleteFolder();
            deleteFolder.Execute(client3, folderDelete );
            client3.ShowStatusUSer();
            Console.WriteLine(client3);

        }
        

        static List<Client> GetExampleClients()
        {

            //Create some users
            Console.WriteLine("Create some users");
            var cliente1 = new ClientSMTP()
            {
                AccountName = "TestUser1",                
                Username = "test1@testmail.com",
                Password = "123456",
                ServerName = "testmail.com",
                Port = 456,
            };

            //Setup defult Rules Social Media Mails
            Rule socialDir = new("Social Mails");
            socialDir.Conditions.Add(new ConditionKeyWord("Subject", "Facebook"));
            socialDir.Actions.Add(new ActionMove("Social"));

            cliente1.RulesIn.Add(socialDir);

            Console.WriteLine(cliente1);

            var cliente2 = new ClientSMTP()
            {
                AccountName = "TestUser2",                
                Username = "test2@testmail.com",
                Password = "123456",
                ServerName = "testmail.com",
                Port = 456,
            };

            cliente2.RulesIn.Add(socialDir);

            List<Client> Clients = new List<Client> {
                cliente1,
                cliente2
            };

            Console.WriteLine(cliente2);

            return Clients;
        }
        
    }
}
