using Adressbok.Interfaces;
using Adressbok.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Adressbok.Models;

public class Menu
{
    //list with contacts
    public ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

    private readonly FileService file = new FileService();

    public void PopulateContactList()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());

            if (items != null)
            {
                contacts = items;
            }
        }
        catch { }
    }


    public void MainMenu()
    {

        PopulateContactList();

        //loop menu if this value is true
        bool ShowMenu = true;

        while (ShowMenu == true)
        {

            //clears console
            Console.Clear();
            GreenString("Välkommen till Adressboken");
            Console.WriteLine();
            YellowString("1. ");
            Console.WriteLine("Skapa en kontakt");
            YellowString("2. ");
            Console.WriteLine("Visa alla kontakter");
            YellowString("3. ");
            Console.WriteLine("Visa en specifik kontakt");
            YellowString("4. ");
            Console.WriteLine("Ta bort en specifik kontakt");
            YellowString("5. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Avsluta programmet");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Välj ett av alternativen ovan: ");

            //User´s menu choice
            int MenuChoice = 0;

            MenuChoice = Convert.ToInt32(Console.ReadLine());


            switch (MenuChoice)
            {
                //Create a new contact
                case 1:
                    Console.Clear();
                    CreateContact();
                    Console.Clear();
                    GreenString("Kontakt tillagd");
                    Console.WriteLine();
                    PressKeyToGoBack();
                    Console.ReadKey();
                    break;
                    //Show all contacts
                case 2:
                    Console.Clear();
                    ShowContacts();
                    PressKeyToGoBack();
                    Console.ReadKey();
                    break;
                    //show a specific contact
                case 3:
                    Console.Clear();
                    ShowContact();
                    Console.WriteLine();
                    PressKeyToGoBack();
                    Console.ReadKey();
                    break;
                    //delete a contact
                case 4:
                    Console.Clear();
                    DeleteContact();
                    PressKeyToGoBack();
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Klicka på valfri tangent för att avsluta programmet.");
                    ShowMenu = false;
                    break;
                default:
                    break;
            }
        }
    }

    //Create a contact
    private void CreateContact()
    {
        Console.Write("Ange fullständigt namn: ");
        string UserNameInput = Console.ReadLine();
        Console.Write("Ange Telefon: ");
        int PhoneNumberInput = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ange Email: ");
        string EmailInput = Console.ReadLine();

        Contact NewContact = new Contact()
        {
            UserName = UserNameInput,
            PhoneNumber = PhoneNumberInput,
            Email = EmailInput
        };

        contacts.Add(NewContact);

        //tack till Sara Linström för hjälp samt inspiration med att hämta och ladda upp information från json filen.
        file.Save(JsonConvert.SerializeObject(contacts));

    }

    //Show all contacts
    private void ShowContacts()
    {
        foreach (Contact contact in contacts)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(contact.UserName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(contact.Email);
            Console.WriteLine();
        }
    }

    //Show a spefific contact
    private void ShowContact()
    {
        int ForEachContact = 1;

        foreach (Contact contact in contacts)
        {
            Console.WriteLine(ForEachContact + ". " + contact.UserName);
            Console.WriteLine();

            ForEachContact++;
        }
        Console.Write("Välj den kontaktpersonen som du vill visa: ");

        int UserChoiceShowContact = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.Clear();

        Console.WriteLine("Namn: " + contacts[UserChoiceShowContact].UserName);
        Console.WriteLine("Telefonnummer: " + contacts[UserChoiceShowContact].PhoneNumber);
        Console.WriteLine("E-postadress: " + contacts[UserChoiceShowContact].Email);


    }

    //Delete/remove a contact
    private void DeleteContact()
    {
        int ForEachContact = 1;

        foreach (Contact contact in contacts)
        {
            Console.WriteLine(ForEachContact + ". " + contact.UserName);
            Console.WriteLine();

            ForEachContact++;
        }
        Console.Write("Välj den kontaktpersonen som du vill ta bort: ");

        int UserChoiceDeleteContact = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.Clear();
        Console.Write($"Är du säker på att du vill ta bort {contacts[UserChoiceDeleteContact].UserName}? y/n: ");

        string ConDeleteContact = Console.ReadLine();

        if ( ConDeleteContact.ToLower() == "y" ) {

            contacts.RemoveAt(UserChoiceDeleteContact);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kontakt borttagen.");
            Console.ForegroundColor = ConsoleColor.White;
            file.Save(JsonConvert.SerializeObject(contacts));
        }

        else
        {
            Console.WriteLine();
            Console.WriteLine("Kontakt ej borttagen.");
        }

    }

    private void PressKeyToGoBack()
    {
        Console.WriteLine("Klicka på valfri tangent för att gå tillbaka.");
    }

    private void YellowString(string content)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(content);
        Console.ForegroundColor = ConsoleColor.White;

    }
    private void GreenString(string content)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(content);
        Console.ForegroundColor = ConsoleColor.White;

    }

}

