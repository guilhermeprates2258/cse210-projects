using System;

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

abstract class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Date { get; private set; }
    public string Time { get; private set; }
    public Address Address { get; private set; }

    protected Event(string title, string description, string date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nAddress: {Address}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {Title}\nDate: {Date}";
    }
}

class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

class Reception : Event
{
    public string RSVPEmail { get; private set; }

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RSVPEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {RSVPEmail}";
    }
}

class OutdoorGathering : Event
{
    public string WeatherStatement { get; private set; }

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        WeatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {WeatherStatement}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
        Address address3 = new Address("789 Oak St", "Sometown", "TX", "USA");

        // Create events
        Lecture lecture = new Lecture("Tech Conference", "A conference about the latest in tech.", "2024-06-15", "10:00 AM", address1, "John Doe", 100);
        Reception reception = new Reception("Wedding Reception", "Join us for a celebration.", "2024-07-20", "5:00 PM", address2, "rsvp@example.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Festival", "A fun outdoor event for the whole family.", "2024-08-10", "1:00 PM", address3, "Sunny and warm");

        // Create a list of events
        Event[] events = new Event[] { lecture, reception, outdoorGathering };

        // Display marketing messages for each event
        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine();
        }
    }
}
