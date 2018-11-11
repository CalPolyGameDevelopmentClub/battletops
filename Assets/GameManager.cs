using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject[] spawns;
    public string startButton;

    private bool[] summoned = { false, false, false, false };

    //private GameObject[] players;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 4; i++)
        {
            if (!summoned[i] && Input.GetButton((i + 1) + startButton))
            {
                summoned[i] = true;
                SpawnPlayer(i + 1);
            }
        }       
	}

    void SpawnPlayer(int playerNum)
    {
        GameObject player = GameObject.Instantiate(
                playerPrefab,
                spawns[playerNum].transform.position,
                Quaternion.identity
            );

        //players[playerNum - 1] = player;

        PlayerController pc = player.GetComponent<PlayerController>();
        pc.playerNum = "" + playerNum;
    }
}
