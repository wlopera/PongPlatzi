using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeadZone : MonoBehaviour
{
    // private void OnCollisionEnter2D(Collision2D collision) {
    //  	Debug.Log("Collision");
    // }

    public Text scorePlayerText;
    public Text scoreEnemyText;
    int scorePlayerQuantity;
    int scoreEnemyQuantity;
    public SceneChanger sceneChanger;
	public AudioSource deadZoneAudio;
	public Transform followBall;

    private void OnTriggerEnter2D(Collider2D ballCollision)
    {
        if (gameObject.tag == "Left")
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        }
        else if (gameObject.CompareTag("Right"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }

		ballCollision.GetComponent<BallBehavior>().gameStarted = false;

		followBall.GetComponent<FollowBall>().speed += 0.03f;
		
		deadZoneAudio.Play();

		CheckScore();
    }

    void CheckScore()
    {
        if (scorePlayerQuantity > 4)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if (scoreEnemyQuantity > 4)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }

    }
    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }

}
