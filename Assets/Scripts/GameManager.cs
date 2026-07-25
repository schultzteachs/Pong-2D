using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI winMessageText;
    public GameObject restartbutton; 

    GameObject theBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        restartbutton.SetActive(false);
        theBall = GameObject.FindGameObjectWithTag("Ball");
        winMessageText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText1.text = PlayerScore1.ToString();
        scoreText2.text = PlayerScore2.ToString();

        if (PlayerScore1 == 10)
        {
            winMessageText.text = "PLAYER ONE WINS";
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            restartbutton.SetActive(true);
        }
        else if (PlayerScore2 == 10)
        {
            winMessageText.text = "PLAYER TWO WINS";
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            restartbutton.SetActive(true);
        }

        
    }

    public static void Score (string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }
    public void RestartGameButtonPressed()
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        winMessageText.text = "";
        theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }
}

