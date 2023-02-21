using Adressbok.Models;

namespace Adressbok.Tests
{
    public class Adressbok_Tests
    {
        private Menu menu;
        Contact contact;

        public Adressbok_Tests()
        {
            //arrenge
            menu = new Menu();
            contact = new Contact();
        }

        [Fact]
        public void ShouldAddContactToList()
        {            

            //act
            menu.contacts.Add(contact);

            //assert
            Assert.Single(menu.contacts);

        }
    }
}