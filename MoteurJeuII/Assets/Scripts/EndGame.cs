using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject player;


    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.active == true)
        {
            player.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("player apertou ESC");
                SceneManager.LoadScene("StartMenu");
            }
        }

    }
}
