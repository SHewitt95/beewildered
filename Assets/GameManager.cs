using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private GameStates currentState;
	public static GameObject canvas;

	public static GameObject introPanel;
	public static GameObject buildPanel;
	public static GameObject collectPanel;
	public static GameObject distributePanel;

	public enum GameStates {CAMERA, BUILD, COLLECT, DISTRIBUTE, DEFEND, INTRO};

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

	}

	// Use this for initialization
	void Start () {
		//canvas = GameObject.FindGameObjectWithTag ("Canvas");
		buildPanel = GameObject.FindGameObjectWithTag ("Build Panel");
		introPanel = GameObject.FindGameObjectWithTag ("Intro Panel");
		collectPanel = GameObject.FindGameObjectWithTag ("Collect Panel");
		distributePanel = GameObject.FindGameObjectWithTag ("Distribute Panel");


		//canvas.gameObject.SetActive (false);
		buildPanel.gameObject.SetActive (false);
		introPanel.gameObject.SetActive (false);
		collectPanel.gameObject.SetActive (false);
		distributePanel.gameObject.SetActive (false);

		currentState = GameStates.INTRO;
	}
	
	// Update is called once per frame
	void Update () {

		// TODO: Make it so random user input is ignored. They must follow the game sequence.
		// Ex: While intro is going, the BUILD input should not function.
		checkUserInput (Input.inputString);

		switch (GetCurrentState()) {
			case GameStates.INTRO:
				Intro.InitiateIntroState ();
				break;

			case GameStates.CAMERA:
				break;

			case GameStates.BUILD:
				Build.InitiateBuildState ();
				break;

			case GameStates.COLLECT:
				break;

			case GameStates.DISTRIBUTE:
				break;

			case GameStates.DEFEND:
				break;

			default:
				break;
		}

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

		currentState = GameStates.CAMERA;
	}

	void checkUserInput(string input) {
		//Debug.Log (input);
		switch(input) {
			case "b":
			currentState = GameStates.BUILD;
				break;
			case "B":
			currentState = GameStates.BUILD;
				break;
			case "v":
			currentState = GameStates.COLLECT;
				break;
			case "V":
			currentState = GameStates.COLLECT;
				break;
			case "n":
			currentState = GameStates.DISTRIBUTE;
				break;
			case "N":
			currentState = GameStates.DISTRIBUTE;
				break;
			case "m":
			currentState = GameStates.DEFEND;
				break;
			case "M":
			currentState = GameStates.DEFEND;
				break;
		default:
			if (Input.GetKeyDown(KeyCode.Escape)) {
				resetState ();
			}
			break;
		}
	}
}
