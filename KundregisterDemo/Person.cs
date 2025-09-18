internal class Person
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Person(Person personToCopy)
    {
        Name = personToCopy.Name;
        Email = personToCopy.Email;
    }

    public Person(string name = "", string email = "")
    {
        if (name.Contains("@"))
        {
            email = name;
            name = "";
        }

        if (name == "")
        {
            name = "Okänd";
        }

        Name = name;
        Email = email;
    }

}