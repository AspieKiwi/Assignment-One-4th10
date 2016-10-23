using SQLite4Unity3d;
using UnityEngine;
using System.IO;

#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{
	private SQLiteConnection _connection;
	private string currentDbPath = "";
	private bool dbExists;

	public bool	DbExists(string DatabaseName)
    {
        // Watch out! this method has a side effect
        bool result = false;

		#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		result = File.Exists(dbPath);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

		if (!File.Exists(filepath))
		{
		result = false;
		Debug.Log("Database not in Persistent path");
		// if it doesn't ->
		// open StreamingAssets directory and load the db ->

		#if UNITY_ANDROID 
		var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
		while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
		// then save to Application.persistentDataPath
		File.WriteAllBytes(filepath, loadDb.bytes);
		#elif UNITY_IOS
		var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#elif UNITY_WP8
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

		#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#else
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);

		#endif

		Debug.Log("Database written");
		}

		var dbPath = filepath;
		#endif

		currentDbPath = dbPath;
		Debug.Log("Final PATH: " + dbPath);

		return result;
	}

	public void Connect()
    {
		_connection = new SQLiteConnection(currentDbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
	}
	public DataService()
    {
           
	}



// Set up utilities
	public void deleteDatabaseFile()
    {
		File.Delete(currentDbPath);
	}

// Scene Save

	private void CreateIfNotExists<T>( ) where T:new ()
    {
		// Since we are taking the perspective that Set puts the data into the
		// database, if the table does not exist then we create.
		_connection.CreateTable<T>();
	}

	private void IfNotExistsCreateSceneToScene( )
    {
	  // Since we are taking the perspective that Set puts the data into the
	  // database, if the table does not exist then we create.
	  _connection.CreateTable<SceneToSceneDTO>();
	}

	private void IfNotExistsCreateScene()
    {
		// Since we are taking the perspective that Set puts the data into the
		// database, if the table does not exist then we create.
		_connection.CreateTable<SceneDTO>();
	}

    // checking if scenetofrom exists
	private bool SceneToFromExists( int pFromID, int pToId)
	{
	   var y = _connection.Table<SceneToSceneDTO>().Where(x => x.FromSceneID == pFromID && x.ToSceneID == pToId).FirstOrDefault();
        return y != null;
	}


    // checking if Scene exists
	private bool SceneExists(int pSceneID)
    {
		var y = _connection.Table<SceneDTO>().Where(x => x.SceneID == pSceneID).FirstOrDefault();
        return y != null;
	}


    // sets the scene
	private void SetScene(SceneDTO aSceneDTO)
    {
		CreateIfNotExists<SceneDTO>();

		if(SceneExists(aSceneDTO.SceneID))
        {
			_connection.Update(aSceneDTO);
		}
		else
        {
			_connection.Insert(aSceneDTO);
		}
	}


    // sets the scene to from
	private void SetSceneToFrom(Scene pScene, Scene pDirection, string pLabel)
    {
        if (pDirection != null )
        {
            // IfNotExistsCreateSceneToScene();
            CreateIfNotExists<SceneToSceneDTO>();
            SceneToSceneDTO aDTO = new SceneToSceneDTO
            {
                FromSceneID = pScene.ID,
                ToSceneID = pDirection.ID,
                Label = pLabel
            };

            if (SceneToFromExists(aDTO.FromSceneID,aDTO.ToSceneID))
            {
                _connection.Update(aDTO);
            }
            else
            {
                _connection.Insert(aDTO);
            }
        }
	}// SetSceneToFrom


    // saves the scenes
	public void SaveScenes( )
    {
        foreach ( Scene aScene in Scene.AllScenes)
        {
            SceneDTO currentSceneDTO = new SceneDTO
            {
                SceneID = aScene.ID,
                GameID = 1, // need to add a Game Number here
                Name = "Any name",
                Story =  aScene.Description
            };

            SetSceneToFrom(aScene, aScene.North, "North");
            SetSceneToFrom(aScene, aScene.South,"South");
            SetSceneToFrom(aScene, aScene.East, "East");
            SetSceneToFrom(aScene, aScene.West, "West");
            SetScene(currentSceneDTO);
        }
    }



// Scene Load
	public void LoadScenes( )
    {
        // Clear the current Scenes
        if (Scene.AllScenes.Count > 0)
        {
            Scene.AllScenes.Clear();
        }

        // What to do about the current Scene ? GameModel.currentPlayer.CurrentScene

        // Get the Scenes
        var SceneDTOs = _connection.Table<SceneDTO>();

        // Rebuild the local data structure
        foreach (SceneDTO aDTO in SceneDTOs){
            // Check we have not created this already!!
            Scene firstCheckScene = Scene.AllScenes.Find(x => x.ID == aDTO.SceneID);
            Scene aScene;
            if ( firstCheckScene == null)
				aScene = new Scene()
                {
                    ID = aDTO.SceneID,
                    Description = aDTO.Story
                };
			else
            {
				aScene = firstCheckScene;
			}

            // Get North , South, East and West
            var directions = _connection.Table<SceneToSceneDTO>().Where(x => x.FromSceneID == aDTO.SceneID);

            foreach ( SceneToSceneDTO aDirScene in directions)
            {
                var aSceneDTO = (_connection.Table<SceneDTO>().Where(x => x.SceneID == aDirScene.ToSceneID)).FirstOrDefault();

				Scene aCheck = Scene.AllScenes.Find(x => x.ID == aSceneDTO.SceneID);
				Scene toScene;
				if( aCheck == null)
                {
                    toScene = new Scene()
                    {
                        ID = aSceneDTO.SceneID,
                        Description = aSceneDTO.Story
                    };
                }
                else
                {
					toScene = aCheck;
				}

                switch ( aDirScene.Label)
                {
                    case ("North"):
                        aScene.North = toScene;
                        break;

					case ("South"):
                        aScene.South = toScene;
                        break;

                    case ("West"):
                        aScene.West = toScene;
                        break;

                    case ("East"):
                        aScene.East = toScene;
                        break;
				}
            }//for each Direction


            // Make the current Scene - this adds it to the AllScenes

        }// for each SceneDTO
	}


    // sets the dialogue
    private void SetDialogue(SceneDiagloueDTO aSceneDialogueDTO)
    {
        CreateIfNotExists<SceneDiagloueDTO>();

        if (SceneDialogueExists(aSceneDialogueDTO.SceneDialogueID))
        {
            _connection.Update(aSceneDialogueDTO);
        }
        else
        {
            _connection.Insert(aSceneDialogueDTO);
        }
    }


    // checks if dialogue exists
    private bool SceneDialogueExists(int pSceneDialogueID)
    {
        var y = _connection.Table<SceneDiagloueDTO>().Where( x => x.SceneDialogueID == pSceneDialogueID).FirstOrDefault();
        return y != null;
    }

    // save dialogue
    public void SaveSceneDialogue()
    {
        foreach (SceneDialogue aSceneDialogue in SceneDialogue.AllDialogue)
        {
            SceneDiagloueDTO currentDialogueDTO = new SceneDiagloueDTO
            {
                SceneDialogueID = aSceneDialogue.Id,
                Name = aSceneDialogue.Name,
                Text = aSceneDialogue.Text
            };

            SetDialogue(currentDialogueDTO);
        }
    }


    // load dialogue
    public void LoadSceneDialogue()
    {
        if (SceneDialogue.AllDialogue.Count > 0)
        {
            SceneDialogue.AllDialogue.Clear();
        }
        // do I need to put somethign to do with the gamemodel here.
        // like this
        // GameModel.currentPlayer.CurrentDialogue

        var SceneDialogueDTOs = _connection.Table<SceneDiagloueDTO>();

        foreach(SceneDiagloueDTO aDTO in SceneDialogueDTOs)
        {
            SceneDialogue firstCheckDialogue = SceneDialogue.AllDialogue.Find(x => x.Id == aDTO.SceneDialogueID);
            SceneDialogue aSceneDialogue;
            if (firstCheckDialogue == null)
                aSceneDialogue = new SceneDialogue()
                {
                    Id = aDTO.SceneDialogueID,
                    Name = aDTO.Name,
                    Text = aDTO.Text
                };
            else
            {
                aSceneDialogue = firstCheckDialogue;
            }

            var npcs = _connection.Table<SceneDiagloueDTO>().Where(x => x.SceneDialogueID == aDTO.SceneDialogueID);

            foreach (SceneDiagloueDTO aDiaScene in npcs)
            {
                var aDialogueDTO = (_connection.Table<SceneDiagloueDTO>().Where( x=> x.SceneDialogueID == aDiaScene.SceneDialogueID)).FirstOrDefault();

                SceneDialogue aCheck = SceneDialogue.AllDialogue.Find(x => x.Id == aDialogueDTO.SceneDialogueID);
                SceneDialogue toDialogue;
                if (aCheck == null)
                {
                    toDialogue = new SceneDialogue()
                    {
                        Id = aSceneDialogue.Id,
                        Name = aSceneDialogue.Name,
                        Text = aSceneDialogue.Text
                    };
                }
                else
                {
                    toDialogue = aCheck;
                }

                switch (aDiaScene.Name)
                {
                    case ("Tutor"):
                        aSceneDialogue.Connected_dialogue = toDialogue;

                   break;
                }
            }
        }
    }


    // sets player stats
    private void SetStats(PlayerStatsDTO aPlayerStatsDTO)
    {
        CreateIfNotExists<PlayerStatsDTO>();
        if (StatsExists(aPlayerStatsDTO.PlayerId))
        {
            _connection.Update(aPlayerStatsDTO);
        }
        else
        {
            _connection.Insert(aPlayerStatsDTO);
        }
    }


    // checks if player stats exists
    private bool StatsExists(int pPlayerID)
    {
        var y = _connection.Table<PlayerStatsDTO>().Where(x => x.PlayerId == pPlayerID).FirstOrDefault();
        return y != null;
    }


    // saves the player stats
    public void SaveStats()
    {
        foreach(PlayerStats aStats in PlayerStats.AllStats)
        {
            PlayerStatsDTO currentStatsDTO = new PlayerStatsDTO
            {
                PlayerId = aStats.Id,
                StatusName = aStats.StatusName,
                Changed = aStats.Changed,
                Value = aStats.Value

            };

            SetStats(currentStatsDTO);
        }
    }


    // loads the player stats
    public void LoadStats()
    {
        if (PlayerStats.AllStats.Count > 0)
        {
            PlayerStats.AllStats.Clear();
        }

        // do i need to do the gamemodel line?

        var PlayerStatsDTOs = _connection.Table<PlayerStatsDTO>();

        foreach(PlayerStatsDTO aDTO in PlayerStatsDTOs)
        {
            PlayerStats firstCheckStats = PlayerStats.AllStats.Find(x => x.Id == aDTO.PlayerId);
            PlayerStats aPlayerStats;

            if (firstCheckStats == null)
                aPlayerStats = new PlayerStats()
                {
                    Id = aDTO.PlayerId,
                    Changed = aDTO.Changed,
                    StatusName = aDTO.StatusName,
                    Value = aDTO.Value
                };
            else
            {
                aPlayerStats = firstCheckStats;
            }

            var stats = _connection.Table<PlayerStatsDTO>().Where(x => x.PlayerId == aDTO.PlayerId);

            foreach (PlayerStatsDTO aPlaStats in stats)
            {
                var aPlayerStatsDTO = (_connection.Table<PlayerStatsDTO>().Where(x => x.PlayerId == aPlaStats.PlayerId)).FirstOrDefault();

                PlayerStats aCheck = PlayerStats.AllStats.Find(x => x.Id == aPlaStats.PlayerId);
                PlayerStats toPlayerStats;
                if (aCheck == null)
                {
                    toPlayerStats = new PlayerStats()
                    {
                        Id = aPlayerStatsDTO.PlayerId,
                        StatusName = aPlayerStatsDTO.StatusName,
                        Changed = aPlayerStatsDTO.Changed,
                        Value = aPlayerStatsDTO.Value
                    };
                }
                else
                {
                    toPlayerStats = aCheck;
                }
                switch (aPlaStats.StatusName)
                {
                    case ("Speed"):
                        aPlayerStats.Connected_stats = toPlayerStats;
                        break;
                }
            }
        }
    }


    // sets the person
    private void SetPerson(PersonDTO aPersonDTO)
    {
        CreateIfNotExists<PersonDTO>();
        if (PersonExists(aPersonDTO.Id))
        {
            _connection.Update(aPersonDTO);
        }
        else
        {
            _connection.Insert(aPersonDTO);
        }
    }


    // checks if the person exists
    private bool PersonExists(int pPersonID)
    {
        var y = _connection.Table<PersonDTO>().Where(x => x.Id == pPersonID).FirstOrDefault();
        return y != null;
    }


    // saves the person
    public void SavePerson()
    {
        foreach(Person aPerson in Person.AllPersons)
        {
            PersonDTO currentPersonDTO = new PersonDTO
            {
                Id = aPerson.Id,
                Name = aPerson.Name,
                Surname = aPerson.Surname,
                Age = aPerson.Age,
                Password = aPerson.Password,
                Score = aPerson.Score
            };

            SetPerson(currentPersonDTO);
        }
    }


    // loads the person
    public void LoadPerson()
    {
        if(Person.AllPersons.Count > 0)
        {
            Person.AllPersons.Clear();
        }

        var PersonDTOs = _connection.Table<PersonDTO>();

        foreach (PersonDTO aDTO in PersonDTOs)
        {
            Person firstCheckPerson = Person.AllPersons.Find(x => x.Id == aDTO.Id);
            Person aPerson;
            if (firstCheckPerson == null)
                aPerson = new Person()
                {
                    Id = aDTO.Id,
                    Name = aDTO.Name,
                    Age = aDTO.Age,
                    Surname = aDTO.Surname,
                    Password = aDTO.Password,
                    Score = aDTO.Score
                };
            else
            {
                aPerson = firstCheckPerson;
            }

            var persons = _connection.Table<PersonDTO>().Where(x => x.Id == aDTO.Id);

            foreach ( PersonDTO aPerPerson in persons)
            {
                var aPersonDTO = (_connection.Table<PersonDTO>().Where(x => x.Id == aPerPerson.Id)).FirstOrDefault();

                Person aCheck = Person.AllPersons.Find(x => x.Id == aPersonDTO.Id);
                Person toPerson;
                if (aCheck == null)
                {
                    toPerson = new Person()
                    {
                        Id = aPersonDTO.Id,
                        Name = aPersonDTO.Name,
                        Surname = aPersonDTO.Surname,
                        Age = aPersonDTO.Age,
                        Password = aPersonDTO.Password,
                        Score = aPersonDTO.Score
                    };
                }
                else
                {
                    toPerson = aCheck;
                }

                switch (aPerPerson.Name)
                {
                    case ("Johnny"):
                        aPerson.Connected_person = toPerson;
                        break;
                }
            }
        }
    }


    // sets the game
    private void SetGame(GameDTO aGameDTO)
    {
        CreateIfNotExists<GameDTO>();

        if (SceneExists(aGameDTO.GameId))
        {
            _connection.Update(aGameDTO);
        }
        else
        {
            _connection.Insert(aGameDTO);
        }
    }

    // checks if game exists
    private bool GameExists(int pGameID)
    {
        var y = _connection.Table<GameDTO>().Where(x => x.GameId == pGameID).FirstOrDefault();
        return y != null;
    }


    // saves the game
    public void SaveGames()
    {
        foreach(Game aGame in Game.AllGames)
        {
            GameDTO currentGameDTO = new GameDTO
            {
                GameId = aGame.Id,
                Name = aGame.Name
            };

            SetGame(currentGameDTO);
        }
    }


    // load the game
    public void LoadGame()
    {
        if(Game.AllGames.Count > 0)
        {
            Game.AllGames.Clear();
        }

        var GameDTOs = _connection.Table<GameDTO>();
        
        foreach(GameDTO aDTO in GameDTOs)
        {
            Game firstCheckGame = Game.AllGames.Find(x => x.Id == aDTO.GameId);
            Game aGame;

            if (firstCheckGame == null)
                aGame = new Game()
                {
                    Id = aDTO.GameId,
                    Name = aDTO.Name
                };
            else
            {
                aGame = firstCheckGame;
            }

            var games = _connection.Table<GameDTO>().Where(x => x.GameId == aDTO.GameId);
            
            foreach(GameDTO aGamGame in games)
            {
                var aGameDTO = (_connection.Table<GameDTO>().Where(x => x.GameId == aGamGame.GameId)).FirstOrDefault();

                Game aCheck = Game.AllGames.Find(x => x.Id == aGameDTO.GameId);
                Game toGame;

                if (aCheck == null)
                {
                    toGame = new Game()
                    {
                        Id = aGameDTO.GameId,
                        Name = aGameDTO.Name
                    };
                }
                else
                {
                    toGame = aCheck;
                }

                switch (aGamGame.Name)
                {
                    case ("One"):
                        aGame.Connected_game = toGame;
                        break;
                }
            }
        }
    }



    // sets the game person join
    private void SetGamePerson (GamePersonDTO aGamePersonDTO)
    {
        CreateIfNotExists<GamePersonDTO>();
        if (GamePersonExists(aGamePersonDTO.GameId))
        {
            _connection.Update(aGamePersonDTO);

        }
        else
        {
            _connection.Insert(aGamePersonDTO);
        }
    }


    // checks the game person join
    private bool GamePersonExists(int pGameID)
    {
        var y = _connection.Table<GamePersonDTO>().Where(x => x.GameId == pGameID).FirstOrDefault();
        return y != null;
    }


    // saves the game person join
    public void SaveGamePersons()
    {
        foreach(GamePerson aGamePerson in GamePerson.AllGamePersons)
        {
            GamePersonDTO currentGamePersonDTO = new GamePersonDTO
            {
                GameId = aGamePerson.GameID,
                PersonId = aGamePerson.PersonID,
                Description = aGamePerson.Description
            };

            SetGamePerson(currentGamePersonDTO);
        }
    }



    // load the game person join
    public void LoadGamePerson()
    {
        if(GamePerson.AllGamePersons.Count > 0)
        {
            GamePerson.AllGamePersons.Clear();
        }

        var GamePersonDTOs = _connection.Table<GamePersonDTO>();

        foreach(GamePersonDTO aDTO in GamePersonDTOs)
        {
            GamePerson firstCheckGamePerson = GamePerson.AllGamePersons.Find(x => x.GameID == aDTO.GameId);
            GamePerson aGamePerson;

            if (firstCheckGamePerson == null)
                aGamePerson = new GamePerson()
                {
                    GameID = aDTO.GameId,
                    PersonID = aDTO.PersonId,
                    Description = aDTO.Description
                    
                };
            else
            {
                aGamePerson = firstCheckGamePerson;
            }

            var gamepersons = _connection.Table<GamePersonDTO>().Where(x => x.GameId == aDTO.GameId);

            foreach(GamePersonDTO aGamePerPerson in gamepersons)
            {
                var aGamePersonDTO = (_connection.Table<GamePersonDTO>().Where(x => x.GameId == aGamePerPerson.GameId)).FirstOrDefault();
                GamePerson aCheck = GamePerson.AllGamePersons.Find(x => x.GameID == aGamePersonDTO.GameId);
                GamePerson toGamePerson;

                if (aCheck == null)
                {
                    toGamePerson = new GamePerson()
                    {
                        GameID = aGamePersonDTO.GameId,
                        PersonID = aGamePersonDTO.PersonId,
                        Description = aGamePersonDTO.Description
                    };
                }
                else
                {
                    toGamePerson = aCheck;
                }

                switch (aGamePerPerson.Description)
                {
                    case ("One"):
                        aGamePerson.Connected_gameperson = toGamePerson;
                        break;
                }
            }

        }
    }



    // sets the item
    private void SetItem(ItemDTO aItemDTO)
    {
        CreateIfNotExists<ItemDTO>();
        if (ItemExists(aItemDTO.ItemID))
        {
            _connection.Update(aItemDTO);
        }
        else
        {
            _connection.Insert(aItemDTO);
        }
    }

    

    // check's if the item exists
    private bool ItemExists(int pItemID)
    {
        var y = _connection.Table<ItemDTO>().Where(x => x.ItemID == pItemID).FirstOrDefault();
        return y != null;
    }


    // saves the item
    public void SaveItem()
    {
        foreach (Item aItem in Item.AllItems)
        {
            ItemDTO currentItemDTO = new ItemDTO
            {
                ItemID = aItem.ItemID,
                SceneFindID = aItem.SceneFindID,
                SceneUseID = aItem.SceneUseID,
                Name = aItem.Name,
                Use = aItem.Use,
                Description = aItem.Description
            };

            SetItem(currentItemDTO);
        }
    }

    // this can't be implemented currently as it will cause multiple errors.

    //public void LoadItem()
    //{
    //    if(Item.AllItems.Count > 0)
    //    {
    //        Item.AllItems.Clear();
    //    }

    //    var ItemDTOs = _connection.Table<ItemDTO>();

    //    foreach(ItemDTO aDTO in ItemDTOs)
    //    {
    //        Item firstCheckItem = Item.AllItems.Find(x => x.ItemID == aDTO.ItemID);
    //        Item aItem;
    //        if (firstCheckItem == null)
    //            aItem = new Item()
    //            {
    //                ItemID = aDTO.ItemID,
    //                SceneFindID = aDTO.SceneFindID,
    //                SceneUseID = aDTO.SceneUseID,
    //                Name = aDTO.Name,
    //                Description = aDTO.Description,
    //                Use = aDTO.Use
    //            };
    //        else
    //        {
    //            aItem = firstCheckItem;
    //        }

    //        var items = _connection.Table<ItemDTO>().Where(x => x.ItemID == aDTO.ItemID);

    //        foreach( ItemDTO aItItem in items)
    //        {
    //            var aItemDTO = (_connection.Table<ItemDTO>().Where(x => x.ItemID == aItItem.ItemID)).FirstOrDefault();

    //            Item aCheck = Item.AllItems.Find(x => x.ItemID == aItemDTO.ItemID);
    //            Item toItem;

    //            if (aCheck == null)
    //            {
    //                toItem = new Item()
    //                {
    //                    ItemID = aItemDTO.ItemID,
    //                    Name = aItemDTO.Name,
    //                    SceneFindID = aItemDTO.SceneFindID,
    //                    SceneUseID = aItemDTO.SceneUseID,
    //                    Description = aItemDTO.Description,
    //                    Use = aItemDTO.Use
    //                };
    //            }
    //            else
    //            {
    //                toItem = aCheck;
    //            }

    //            switch (aItItem.Name)
    //            {
    //                case ("Apple"):
    //                    aItem.Connected_item = toItem;
    //                    break;
    //            }
    //        }

    //    }
    //}

    // EXAMPLE CODE
    // connects to SQLite and creates tables from the DTOs
    public void CreateDB()
    {
        _connection.CreateTable<PersonDTO>();
        _connection.CreateTable<ItemDTO>();
        _connection.CreateTable<PlayerStatsDTO>();
        _connection.CreateTable<GamePersonDTO>();
        _connection.CreateTable<GameDTO>();
        _connection.CreateTable<SceneDiagloueDTO>();
    }
        
    // gets the person
	public IEnumerable<PersonDTO> GetPersons()
    {
		return _connection.Table<PersonDTO>();
	}

    // gets a person named roberto
	public IEnumerable<PersonDTO> GetPersonsNamedRoberto()
    {
		return _connection.Table<PersonDTO>().Where(x => x.Name == "Roberto");
	}

    // check for log in
    public bool CheckPassword(string pStrName, string pStrPassword)
    {
        int count =  _connection.Table<PersonDTO>().Where(x => x.Name == pStrName && x.Password == pStrPassword).Count();
        return count > 0;
    }


    // gets a person named johnny
	public PersonDTO GetJohnny()
    {
		return _connection.Table<PersonDTO>().Where(x => x.Name == "Johnny").FirstOrDefault();
	}

    // creation of test data
	public PersonDTO CreatePerson()
    {
		var p = new PersonDTO
        {
            Name = "Johnny",
            Surname = "Mnemonic",
            Age = 21,
            Password = "Hello"
		};

		_connection.Insert (p);
		return p;
	}

    public ItemDTO CreateItem()
    {
        var i1 = new ItemDTO
        {
            SceneFindID = 1,
            SceneUseID = 2,
            Name = "Apple",
            Use = "Give to the principle",
            Description = "It's an apple"
        };
        _connection.Insert(i1);
        return i1;
    }
}
