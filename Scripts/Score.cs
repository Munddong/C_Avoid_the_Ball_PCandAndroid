using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float timeScore = 0f;

    public Text timerText;
    public Text yourScoreText;
    public Text highScoreText;
    //public Text middleScoreText;
    //public Text lowScoreText;

    public GameObject yourScoreBox;
    public GameObject highScoreBox;
    //public GameObject middleScoreBox;
    //public GameObject lowScoreBox;

    public static bool isDead = false;

    private float savedHighScore = 0;
    //private float savedMiddleScore = 0;
    //private float savedLowScore = 0;

    private string KeyString = "High Score";

    void Awake()
    {
        savedHighScore = PlayerPrefs.GetFloat(KeyString, 0);
        //savedMiddleScore = PlayerPrefs.GetFloat(KeyString, 0);
        //savedLowScore = PlayerPrefs.GetFloat(KeyString, 0);
    }

    void Start()
    {
        timeScore = 0;
        isDead = false;
    }

    void Update()
    {
        timerText.text = string.Format("{0:N2}", timeScore);

        if (isDead == false)
        {
            timeScore += Time.deltaTime;
        }

        if (timeScore > savedHighScore)
        {
            PlayerPrefs.SetFloat(KeyString, timeScore);
        }

        //else if (timeScore > savedMiddleScore)
        //{
        //    if (savedHighScore > savedMiddleScore)
        //    {
        //        PlayerPrefs.SetFloat(KeyString, timeScore);
        //    }
        //}

        //else if (timeScore > savedHighScore)
        //{
        //    if (savedMiddleScore > savedLowScore)
        //    {
        //        PlayerPrefs.SetFloat(KeyString, timeScore);
        //    }
        //}
    }

    public void ScoreEnd()
    {
        yourScoreBox.SetActive(true);
        highScoreBox.SetActive(true);

        yourScoreText.text = "Your Score: " + string.Format("{0:N2}", timeScore);
        highScoreText.text = "Best Score: " + string.Format("{0:N2}", savedHighScore);
        //middleScoreText.text = "Middle Score: " + string.Format("{0:N2}", savedMiddleScore);
        //lowScoreText.text = "Low Score: " + string.Format("{0:N2}", savedLowScore);
    }

    //IEnumerator backGround()
    //{
    //    yield return new WaitForSeconds(20);
    //    BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
    //    width = backgroundCollider.size.x;

    //    if (transform.position.x <= -width)
    //    {
    //        Reposition();
    //    }
    //}

    //private void Reposition()
    //{
    //    Vector2 offset = new Vector2(width * 50f, 0);
    //    transform.position = (Vector2)transform.position + offset;
    //}
}
