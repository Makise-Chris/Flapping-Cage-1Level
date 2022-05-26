using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    public static PlayController instance;

    [SerializeField]
    private Button playBtn;

    [SerializeField]
    private GameObject gameOverImg;

    [SerializeField]
    private GameObject nextLevelBtn;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }

    void _MakeInstance()
    {
        if(instance == null) instance = this;
    }

    public void _tapToPlay()
    {
        Time.timeScale = 1;
        playBtn.gameObject.SetActive(false);
    }

    public void _Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void _BirdDied()
    {
        gameOverImg.SetActive(true);
    }

    public void _NextLevel()
    {
        nextLevelBtn.SetActive(true);
    }
}
