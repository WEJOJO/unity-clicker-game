using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour {


	// Singleton class start
	static GameObject _container;
	static GameObject Container {
		get {
			return _container;
		}
	}

	static DataController _instance; //이게 아마 생성자의 개념같은데?.. Private같은건가?//원래는 Monobehaviour의 경우 Object가 있어야 하
//는데, 이것을 대신해서 얘가 만들고 있기 때문에 직접 유니티에서 객체를 만들어서 스크립트 추가하지 않아도 정상동작하는 것임.
	public static DataController Instance { //이부분은 DataController 형태를 반환하는 함수 Instance임. 즉 사용법을 제시한 것. _instance는 private로 될 것.
		get {
			if( ! _instance ) {
				_container = new GameObject();
				_container.name = "DataController";
				_instance = _container.AddComponent( typeof(DataController) ) as DataController;
				DontDestroyOnLoad (_container);
			}

			return _instance;
		}
	}
	// Singleton class end

	public string gameDataProjectFilePath = "/game.json";

	GameData _gameData;
	public GameData gameData{
		get{
			if (_gameData == null) {
				LoadGameData ();
			}
			return _gameData;
		}
	}

	MetaData _metaData;
	public MetaData metaData{
		get{
			if (_metaData == null) {
				LoadMetaData ();
			}
			return _metaData;
		}
	}

	public void LoadMetaData(){
		TextAsset statJson = Resources.Load ("MetaData/Meta") as TextAsset;
		Debug.Log (statJson.text);
		_metaData = JsonUtility.FromJson<MetaData> (statJson.text);

		foreach (ShopItem shopItem in metaData.ShopItemList) {
			Debug.Log (shopItem.Name);
		}

	}


	public void LoadGameData()
	{
		string filePath = Application.persistentDataPath + gameDataProjectFilePath;
		Debug.Log (filePath);
		if (File.Exists (filePath)) {
			Debug.Log ("loaded!");
			string dataAsJson = File.ReadAllText (filePath);
			_gameData = JsonUtility.FromJson<GameData> (dataAsJson);
		} else 
		{
			Debug.Log ("Create new");

			_gameData = new GameData ();
			_gameData.CollectGoldLevel = 1;
			_gameData.GoldPerSec = 1;
			_gameData.Gold = 0;
			_gameData.Health = 100;
			_gameData.Damage = 10;
			_gameData.Level = 1;
			_gameData.Exp = 0;

		}
	}

	public void SaveGameData()
	{

		string dataAsJson = JsonUtility.ToJson (gameData);

		string filePath = Application.persistentDataPath + gameDataProjectFilePath;
		File.WriteAllText (filePath, dataAsJson); //이분의 Path를 서버와 통신하는 것으로 바꾸어 줘야함...
	

	}

//	public void Start() {
//		Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
//		Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
//	}
//
//	public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) {
//		UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
//	}
//
//	public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) {
//		UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
//	}
}
