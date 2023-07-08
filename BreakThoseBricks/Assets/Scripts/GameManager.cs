using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//List of all the possible gamestates
public enum GameState
{
    NotStarted,
    Playing,
    Completed,
    Failed
}

//Require an audio source for the object
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    //Sounds to be played when entering one of the gamestates
    public AudioClip StartSound;
    public AudioClip FailedSound;
    private GameState currentState = GameState.NotStarted;
    //All the blocks found in this level, to keep track of how many are left
    private Brick[] allBricks;
    private Ball[] allBalls;
    private Paddle paddle;
    public float Timer = 0.0f;
    private int minutes;
    private int seconds;
    public string formattedTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //Find all the blocks in this scene
        allBricks = FindObjectsOfType(typeof(Brick)) as Brick[];

        //Find all the balls in this scene
        allBalls = FindObjectsOfType(typeof(Ball)) as Ball[];
        paddle = GameObject.FindObjectOfType<Paddle>();

        print("Bricks:" + allBricks.Length);
        print("Balls:" + allBalls.Length);
        print("Paddle" + paddle);

        //Prepare the start of the level
        SwitchState(GameState.NotStarted);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.NotStarted:
                //Check if the player taps/clicks.
                if (Input.GetMouseButtonDown(0)) //Note: on mobile this will translate to the first touch / finger so perfectly multiplatform!
                {
                    SwitchState(GameState.Playing);
                }
                break;
            case GameState.Playing:
                {
                    Timer += Time.deltaTime;
                    minutes = Mathf.FloorToInt(Timer / 60F);
                    seconds = Mathf.FloorToInt(Timer - minutes * 60);
                    formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
                    //Display Time
                    //print(formattedTime);
                    bool allBlocksDestroyed = false;
                    //Are there no balls left?
                    if (FindObjectOfType(typeof(Ball)) == null)
                        SwitchState(GameState.Failed);
                    if (allBlocksDestroyed)
                        SwitchState(GameState.Completed);
                }
                break;
            //Both cases do the same: restart the game
            case GameState.Failed:
                print("Gamestate Failed!");
                break;
            case GameState.Completed:
                bool allBlocksDestroyedFinal = false;
                //Destroy all the balls
                Ball[] others = FindObjectsOfType(typeof(Ball)) as Ball[];
                foreach (Ball other in others)
                {
                    Destroy(other.gameObject);
                }
                break;
        }
    }

    public void SwitchState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            default:
            case GameState.NotStarted:
                break;
            case GameState.Playing:
                GetComponent<AudioSource>().PlayOneShot(StartSound);
                break;
            case GameState.Completed:
                GetComponent<AudioSource>().PlayOneShot(StartSound);
                break;
            case GameState.Failed:
                GetComponent<AudioSource>().PlayOneShot(FailedSound);
                break;
        }
    }
}