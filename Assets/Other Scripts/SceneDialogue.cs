using SQLite4Unity3d;

public class SceneDiagloue  {

	[PrimaryKey, AutoIncrement]
	public int SceneDialogueID {get; set;}
	public string Name {get; set;}
	public string Text {get; set;}
	

	//public override string ToString ()
	//{
	//	return string.Format ("[Person: Id={0}, Name={1},  Surname={2}, Age={3}]", Id, Name, Surname, Age);
	//}
	
	
	// what else needs to be added here
	
}
