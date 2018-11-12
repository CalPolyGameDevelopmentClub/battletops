using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour {

    public static Color player1 = new Color(1.0f, 0.0f, 1.0f);
    public static Color player2 = new Color(0.0f, 1.0f, 1.0f);
    public static Color player3 = new Color(1.0f, 1.0f, 0.0f);
    public static Color player4 = new Color(0.0f, 1.0f, 0.0f);

	// Use this for initialization
	void Start () {
        PlayerController pc = transform.parent.gameObject.GetComponent<PlayerController>();
           
        switch (pc.playerNum)
        {
            case 1:
                SetColor(player1); break;
            case 2:
                SetColor(player2); break;
            case 3:
                SetColor(player3); break;
            case 4:
                SetColor(player4); break;
            default:
                SetColor(new Color(1.0f, 1.0f, 1.0f)); break;
        }
	}

    void SetColor(Color color)
    {
        Light l = GetComponent<Light>();
        l.color = color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
