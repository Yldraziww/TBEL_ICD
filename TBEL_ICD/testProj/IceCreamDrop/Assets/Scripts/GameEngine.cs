using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public float timeLeft = 3.0f;
    public int curScore = 0;
    public float curTime;
    public int noCatch;

    public Text startText; // used for showing countdown from 4, 3, 2, 1.
    public Text scoreText; // used to display players current score.
    public Text nocatchText;
    public Text endText;

    public GameObject pos; // Original location used to generate piece structures
    public GameObject cubeFab; // Prefabricated material #1
    public GameObject sphereFab; // Prefabricated material #2
    public GameObject capFab; // Prefabricated material #3

    // Start is called before the first frame update
    void Start()
    {
        endText.enabled = false;
        curTime = 120.0f;
        noCatch = 0;
    }


    void Update()
    {
        curTime -= Time.deltaTime;
        timeLeft -= Time.deltaTime;
        startText.text = (curTime).ToString("0");
        scoreText.text = (curScore).ToString("0");
        nocatchText.text = (noCatch).ToString("0");
        if (timeLeft < 0 && noCatch != 3)
        {
            PieceRandomizer();
        }
        else if (noCatch == 3)
        {
            GameOver();
        }
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * -1.0f);
    }


    public void PieceRandomizer()
    {
        int newRand = Random.Range(1, 4);
        Debug.Log(newRand);


        int pieceRand1 = Random.Range(-10, 6);
        int pieceRand2 = Random.Range(-10, 14);
        Vector3 position = new Vector3(pieceRand1, 30, pieceRand2);

        switch (newRand)
        {
            case 1:
                Instantiate(cubeFab, position, Quaternion.identity);
                timeLeft = 3.0f;
                break;
            case 2:
                Instantiate(sphereFab, position, Quaternion.identity);
                timeLeft = 3.0f;
                break;
            case 3:
                Instantiate(capFab, position, Quaternion.identity);
                timeLeft = 3.0f;
                break;
            default:
                Debug.Log("Cannot create structure...");
                break;
        }
    }


    public void GameOver()
    {
        if (noCatch == 3)
        {
            Time.timeScale = 0;
            Debug.Log("Game over!");
            endText.enabled = true;
            enabled = false;
        }
    }
}