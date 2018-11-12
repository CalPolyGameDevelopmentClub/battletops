using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject RPMprefab;
    public GameObject[] UISpawns;
    public GameObject[] spawns;
    public string startButton;
    public float spawnDelay;
    public float launchForce;

    private float[] respawnTime = new float[4];
    private GameObject[] players = {null, null, null, null};
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
        if (players[playerNum] == null) {
            GameObject player = GameObject.Instantiate(
                playerPrefab,
                spawns[playerNum].transform.position,
                Quaternion.identity
            );

            summoned[playerNum] = true;
            players[playerNum] = player;

            PlayerController pc = player.GetComponent<PlayerController>();
            pc.playerNum = playerNum + 1;

            RPMprefab.GetComponent<UIHealthRPMManager>().player = player;
            GameObject playerRPM = Instantiate(RPMprefab, UISpawns[playerNum].transform.position, Quaternion.identity);
            playerRPM.transform.SetParent(UISpawns[playerNum].transform);

            LaunchPlayer(players[playerNum], spawns[playerNum]);
        }
        else {
            players[playerNum].transform.position = spawns[playerNum].transform.position;
            players[playerNum].GetComponent<Health>().resetHP();
            players[playerNum].GetComponent<PlayerController>().reset();
            players[playerNum].SetActive(true);
            summoned[playerNum] = true;
        }
        
    }

    void LaunchPlayer(GameObject player, GameObject spawn)
    {
        player.GetComponent<Rigidbody>().AddRelativeForce(spawn.transform.forward * launchForce, ForceMode.Impulse);
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
