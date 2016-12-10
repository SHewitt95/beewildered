using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private GameStates currentState;
	public static GameObject canvas;

	public static GameObject introPanel;
	public static GameObject buildPanel;
	public static GameObject collectPanel;
	public static GameObject distributePanel;
	public static GameObject neutralPanel;
	public static GameObject hivePanel;


	int frames;
	int rate;
	int minute;

	public static int numOfPlants = 0;

	public enum GameStates {CAMERA, BUILD, COLLECT, DISTRIBUTE, HIVE, INTRO, START};

	public bool hiveSpawned = false;

	// Keeps track of what type of object exists in each grid position.
	/*
	 * 0 = Empty grid position.
	 * 1 = Tree
	 * 2 = Flower
	 * 3 = Boulder
	 * */
	public static int[] grid;

	// Keeps track of the value associated with each grid position.
	public static int[] gridValues;

	public static List<GameObject> allGameObjects;



	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		initGrid ();

	}

	// Use this for initialization
	void Start () {
		//grid = new int[64];

		//canvas = GameObject.FindGameObjectWithTag ("Canvas");
		buildPanel = GameObject.FindGameObjectWithTag ("Build Panel");
		introPanel = GameObject.FindGameObjectWithTag ("Intro Panel");
		collectPanel = GameObject.FindGameObjectWithTag ("Collect Panel");
		distributePanel = GameObject.FindGameObjectWithTag ("Distribute Panel");
		neutralPanel = GameObject.FindGameObjectWithTag ("Neutral Panel");
		hivePanel = GameObject.FindGameObjectWithTag ("Hive Panel");


		//canvas.gameObject.SetActive (false);
		buildPanel.gameObject.SetActive (false);
		introPanel.gameObject.SetActive (false);
		collectPanel.gameObject.SetActive (false);
		distributePanel.gameObject.SetActive (false);
		neutralPanel.gameObject.SetActive (false);
		hivePanel.gameObject.SetActive (false);

		currentState = GameStates.START;

	}
	
	// Update is called once per frame
	void Update () {

		// TODO: Make it so random user input is ignored. They must follow the game sequence.
		// Ex: While intro is going, the BUILD input should not function.
		if (currentState == GameStates.CAMERA) {
			//checkUserInput (Input.inputString);
		}
			
		switch (GetCurrentState()) {
			case GameStates.INTRO:
				GameManager.neutralPanel.gameObject.SetActive (false);
				//Intro.InitiateIntroState ();
				break;

			case GameStates.CAMERA:
				break;

			case GameStates.BUILD:
				GameManager.neutralPanel.gameObject.SetActive (false);
				Build.InitiateBuildState ();
				break;

			case GameStates.COLLECT:
				GameManager.neutralPanel.gameObject.SetActive (false);
				Collect.InitiateCollectState ();
				break;

			case GameStates.DISTRIBUTE:
				GameManager.neutralPanel.gameObject.SetActive (false);
				break;

			case GameStates.HIVE:
				GameManager.neutralPanel.gameObject.SetActive (false);
				break;

			default:
				break;
		}


	}

	void initGrid() {
		grid = new int[400]; //20 rows * 20 columns = 400 total tiles.
		gridValues = new int[400]; //20 rows * 20 columns = 400 total tiles.
		allGameObjects = new List<GameObject>();

		for (int i = 0; i < grid.Length; i++) {
			grid [i] = 0;
			gridValues [i] = 0;
			allGameObjects.Add (null);
		}

		print (allGameObjects.Count);
	}

	public GameStates GetCurrentState() {
		return currentState;
	}

	public void resetState() {
		//canvas.gameObject.SetActive (false);
		buildPanel.gameObject.SetActive (false);
		introPanel.gameObject.SetActive (false);
		collectPanel.gameObject.SetActive (false);
		distributePanel.gameObject.SetActive (false);
		neutralPanel.gameObject.SetActive (false);
		hivePanel.gameObject.SetActive (false);

		currentState = GameStates.CAMERA;
	}

	public void checkUserInput(string input) {
		//Debug.Log (input);
		switch(input) {
			case "build":
			currentState = GameStates.BUILD;
				break;
			case "collect":
			currentState = GameStates.COLLECT;
				break;
			case "n":
			//currentState = GameStates.DISTRIBUTE;
				break;
			case "hive":
			currentState = GameStates.HIVE;
				break;
			case "camera":
			currentState = GameStates.CAMERA;
			break;
		case "intro":
			currentState = GameStates.INTRO;
			break;
		default:
			if (Input.GetKeyDown(KeyCode.Escape)) {
				resetState ();
			}
			break;
		}
	}
}
