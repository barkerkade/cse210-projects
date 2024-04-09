class Patron
{
    public string Name { get; set; }
    public int ID { get; set; }

    public Patron(string name, int id)
    {
        Name = name;
        ID = id;
    }
}