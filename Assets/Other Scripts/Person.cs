using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private int _Id;
    private string _Name;
    private string _Surname;
    private int _Age;
    private string _Password;
    private int _Score;
    private static List<Person> allPersons = new List<Person>();
    private Person _connected_person = new Person();


    // get set Person ID
    public int Id
    {
        get
        {
            return _Id;
        }

        set
        {
            _Id = value;
        }
    }


    // get set Person Name
    public string Name
    {
        get
        {
            return _Name;
        }

        set
        {
            _Name = value;
        }
    }


    // get set Person Surname
    public string Surname
    {
        get
        {
            return _Surname;
        }

        set
        {
            _Surname = value;
        }
    }


    // get set Person Age
    public int Age
    {
        get
        {
            return _Age;
        }

        set
        {
            _Age = value;
        }
    }


    // get set Person Password
    public string Password
    {
        get
        {
            return _Password;
        }

        set
        {
            _Password = value;
        }
    }



    // gets and sets the Connect_person needed for setting up the load in the data service
    public Person Connected_person
    {
        get
        {
            return _connected_person;
        }

        set
        {
            _connected_person = value;
        }
    }


    // gets and sets the list of AllPersons
    public static List<Person> AllPersons
    {
        get
        {
            return allPersons;
        }

        set
        {
            allPersons = value;
        }
    }


    // gets and sets the Person Score
    public int Score
    {
        get
        {
            return _Score;
        }

        set
        {
            _Score = value;
        }
    }


    // adds a Person to the All Persons list
    public Person()
    {
        Person.AllPersons.Add(this);
    }
}
