using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI winMessageText;
    public GameObject restartbutton;
    public GameObject exitbutt;
    public int winScore;

    GameObject theBall;

    [SerializeField] private string Menu = "Menu";
    

    public void Exit2Menu()
    {
        SceneManager.LoadScene(Menu);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        restartbutton.SetActive(false);
        exitbutt.SetActive(false);
        theBall = GameObject.FindGameObjectWithTag("Ball");
        winMessageText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText1.text = PlayerScore1.ToString();
        scoreText2.text = PlayerScore2.ToString();

        if (PlayerScore1 == winScore)
        {
            winMessageText.text = "PLAYER ONE WINS";
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            restartbutton.SetActive(true);
            exitbutt.SetActive(true);


           
        }
        else if (PlayerScore2 == winScore)
        {
            winMessageText.text = "PLAYER TWO WINS";
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            restartbutton.SetActive(true);
            exitbutt.SetActive(true);

           

            
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
        Start();
    }


    

    


}

