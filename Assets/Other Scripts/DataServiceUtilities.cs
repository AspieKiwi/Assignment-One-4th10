using UnityEngine;
using System.Collections;

public class DataServiceUtilities : MonoBehaviour
{

    // delete database conncetion to SQLite
	public void DeleteDB()
    {
		DataService _connection = new DataService();
		if(_connection.DbExists("NeverLDb"))
        {
			_connection.deleteDatabaseFile();
		}
	}

    // save database connection to SQLite
	public void Save()
    {
		DataService _connection = new DataService();
		if(_connection.DbExists("NeverLDb"))
        {
			_connection.Connect();
			_connection.SaveScenes();
		}
	}
    // load database connection to SQLite
	public void Load()
    {
		DataService _connection = new DataService();
		if(_connection.DbExists("NeverLDb"))
        {
			_connection.Connect();
			_connection.LoadScenes();
		}
	}
}
