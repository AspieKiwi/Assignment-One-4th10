using SQLite4Unity3d;

public class GamePlayer  {

	[PrimaryKey, AutoIncrement]
	public int GameId {get; set;}
	public string Name {get; set;}
	
	// what else do I need to do in this class?
	

	//public override string ToString ()
	//{
	//	return string.Format ("[Person: Id={0}, Name={1},  Surname={2}, Age={3}]", Id, Name, Surname, Age);
	//}
}
