using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigitbody2d;

    public GameObject gameWonPanel;
    public GameObject gameLostPanel;

    public float speed;

    private bool isGameOver;

    private Shake shake;

    public AudioSource rock;

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true) {
            return;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rigitbody2d.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigitbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            rigitbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigitbody2d.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 )
        {
            rigitbody2d.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Hurray, You completed a level!!!");
            gameWonPanel.SetActive(true);
            isGameOver = true;
        }
        else if (other.tag == "Enemy")
        {
            shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
            shake.CamShake();
            //rock.Play();
            Debug.Log("Oops, You did a mistake!!!");
            rigitbody2d.velocity = new Vector2(0f, 0f);
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart Button Clicked");
    }
}
