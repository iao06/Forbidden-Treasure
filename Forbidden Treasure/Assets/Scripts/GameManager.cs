using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private Vector2 playerStart;

    // Start is called before the first frame update
    void Start()
    {
        playerStart = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator GameReset()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        StartCoroutine("GameReset");
    }

    public void Reset()
    {
        player.transform.position = playerStart;
    }
}
