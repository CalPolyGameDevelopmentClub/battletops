using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject[] spawns;
    public string startButton;
    public float spawnDelay;

    private float[] respawnTime = new float[4];
    private bool[] summoned = { false, false, false, false };
    private bool[] active = { false, false, false, false };

    //private GameObject[] players;

    public void PlayerDeath(int playerNum)
    {
        summoned[playerNum - 1] = false;
        respawnTime[playerNum - 1] = 0.0f;
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            respawnTime[i] = spawnDelay;
        }
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 4; i++)
        {
            if (!active[i] && Input.GetButton((i + 1) + startButton))
            {
                active[i] = true;
                summoned[i] = true;
                SpawnPlayer(i);
            }
        }

        SpawnTimer();
	}

    void SpawnPlayer(int playerNum)
    {
        GameObject player = GameObject.Instantiate(
                playerPrefab,
                spawns[playerNum].transform.position,
                Quaternion.identity
            );

        summoned[playerNum] = true;

        PlayerController pc = player.GetComponent<PlayerController>();
        pc.playerNum = playerNum + 1;
    }

    void SpawnTimer()
    {
        for (int i = 0; i < 4; i++)
        {
            respawnTime[i] = respawnTime[i] <= spawnDelay ? respawnTime[i] + Time.deltaTime : spawnDelay;           
            if (active[i] && !summoned[i] && respawnTime[i] == spawnDelay)
            {
                SpawnPlayer(i);
            }
        }
    }
}
