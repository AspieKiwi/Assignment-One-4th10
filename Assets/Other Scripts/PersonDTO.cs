using SQLite4Unity3d;

// set up of the Person data that will be stored in the SQLite database
public class PersonDTO
{

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public int Age { get; set; }
    public string Password { get; set; }
    public int Score { get; set; }

	public override string ToString ()
	{
		return string.Format ("[PersonDTO: Id={0}, Name={1},  Surname={2}, Age={3}, Password={4}, Score={5}]", Id, Name, Surname, Age, Password, Score);
	}
}
