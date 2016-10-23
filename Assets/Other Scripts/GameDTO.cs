using SQLite4Unity3d;

// DTO for the Set up of the Game Table. where data containing the game ID and name are stored
public class GameDTO
{

	[PrimaryKey, AutoIncrement]
	public int GameId {get; set;}
	public string Name {get; set;}



    public override string ToString()
    {
        return string.Format("[GameDTO: GameId={0}, Name={1}]", GameId, Name);
    }
}
