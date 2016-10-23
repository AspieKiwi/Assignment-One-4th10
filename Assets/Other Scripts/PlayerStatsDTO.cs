using SQLite4Unity3d;

public class PlayerStatsDTO
{ // PlayerStatsDTO set up, turned into a data table in dataservice

	[PrimaryKey]
	public int PlayerId {get; set;}
	public string StatusName {get; set;}
	public string Changed {get; set;}
	public int Value {get; set;}



    public override string ToString()
    {
        return string.Format("[PlayerStatsDTO: PlayerId={0}, StatusName={1},  Changed={2}, Value={3}]", PlayerId, StatusName, Changed, Value);
    }
}
