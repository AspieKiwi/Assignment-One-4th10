using SQLite4Unity3d;

public class SceneDiagloueDTO
{ // SceneDialogueDTO set up, which is created into a data table in data service

	[PrimaryKey, AutoIncrement]
	public int SceneDialogueID {get; set;}
	public string Name {get; set;}
	public string Text {get; set;}
	

	public override string ToString ()
	{
		return string.Format ("[SceneDiagloueDTO: SceneDialogueID={0}, Name={1},  Text={2}]", SceneDialogueID, Name, Text);
	}
}
