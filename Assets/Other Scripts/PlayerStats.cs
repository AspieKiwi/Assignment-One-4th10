using SQLite4Unity3d;

public class PlayerStats  {

	[PrimaryKey]
	public int PlayerId {get; set;} // do I need this?
	public string StatusName {get; set;}
	public string Changed {get; set;}
	public int Value {get; set;}
	
	// what else do I need to do in this class?
	

	//public override string ToString ()
	//{
	//	return string.Format ("[Person: Id={0}, Name={1},  Surname={2}, Age={3}]", Id, Name, Surname, Age);
	//}
}
