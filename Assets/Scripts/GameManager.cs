using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public AudioSource theSong;

    public bool startPlaying;

    public NotePlacer theNP;
    public NoteRecorder theNR;

    public int currentScore;
    public int scorePerNote = 100;

    //Score text
    public Text scoreText;
    public Text multiText;

    //Multiplier
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierLimit;
    
    //There can only be one instance for this value
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        startPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if (Input.GetKeyDown(KeyCode.P)) //Play game
            {
                startPlaying = true;
                theNP.hasStarted = true;
                theSong.PlayDelayed(3.0f);
            }

            if(Input.GetKeyDown(KeyCode.R)) //Record key times
            {
                startPlaying = true;
                theNR.hasStarted = true;
                theSong.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        //Check multiplier threshold
        if (currentMultiplier -1 < multiplierLimit.Length)
        {
            multiplierTracker++;
            if (multiplierLimit[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

    }
}
