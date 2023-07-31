using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGate : MonoBehaviour
{
    public GameObject messageText;
    public GameObject cutAwayCamera;
    public bool GameOver = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (GameOver)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                //Restart Game
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        messageText.SetActive(true);
        messageText.GetComponent<TMP_Text>().text = "You Win! \n Press Enter to play again";
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<CharacterController>().enabled = false;
            StartCoroutine(ChangeCamera());
        }
    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(1.0f);
        GameOver = true;
        GameObject.Find("MainCamera").SetActive(false);
        cutAwayCamera.SetActive(true);
    }
}
