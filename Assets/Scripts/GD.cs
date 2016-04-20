using UnityEngine;
using System.Collections;

public class GD : MonoBehaviour {

    public static GameController gameController;

    public static BallController ballController;



    void Awake()
    {
        gameController = GetComponent<GameController>();
        ballController = GameObject.Find("Ball").GetComponent<BallController>();

    }
}
