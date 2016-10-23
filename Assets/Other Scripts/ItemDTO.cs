using System;
using SQLite4Unity3d;

// set up for information that is stored about item in the SQLite Database
public class ItemDTO
{
		[PrimaryKey, AutoIncrement]
		public int ItemID {get; set;}
		public int SceneFindID {get; set;}
		public int SceneUseID {get; set;}
		public string Name {get; set;}
		public string Use {get; set;}
		public string Description {get; set;}

    public override string ToString()
    {
        return string.Format("[ItemID: ItemID={0}, SceneFindID={1},  SceneUseID={2}, Name={3}, Use={4}, Description={5}]", ItemID, SceneFindID, SceneUseID, Name, Use, Description);
    }

}


	


