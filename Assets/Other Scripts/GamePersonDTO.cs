using SQLite4Unity3d;

// connection between Game and Person table as there can be many persons in one game
public class GamePersonDTO
{

	public int PersonId {get; set;} 
	public int GameId {get; set;}
    public string Description {get; set;}



    public override string ToString()
    {
        return string.Format("[GamePersonDTO: PlayerId={0}, GameId={1}, Description={2}]", PersonId, GameId, Description);
    }
}
