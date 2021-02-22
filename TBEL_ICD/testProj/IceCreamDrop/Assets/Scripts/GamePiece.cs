using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{

    public GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObj.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("You've collided with the player!");
            GameObject.Find("GameEngine").GetComponent<GameEngine>().curScore += 1;
        }
        else if(collision.gameObject.tag == "Floor")
        {
            Debug.Log("You've hit the floor :c");
            GameObject.Find("GameEngine").GetComponent<GameEngine>().noCatch += 1;
        }
        Destroy(gameObj);
    }
}
