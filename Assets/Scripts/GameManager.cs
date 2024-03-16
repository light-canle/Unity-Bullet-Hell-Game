using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject projectileDestoryer;
    public float GameTime { get; private set; } = 0.0f;
    private bool gameEnd = false;
    private static GameManager instance = null;
    public int GameMode { get; private set; }

    public float SlowTime { get; private set; } = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(instance);
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            player = FindObjectOfType<PlayerHP>().gameObject;
            projectileDestoryer = FindObjectOfType<ProjectileDestoryer>(true).gameObject;
            AudioManager.Instance.PlayBGM(true);
        }
    }
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Game")
            return;
        if (gameEnd) 
            return;
        if (SlowTime > 0.0f)
        {
            Time.timeScale = 0.5f;
            SlowTime -= Time.deltaTime / Time.timeScale;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        GameTime += Time.deltaTime / Time.timeScale;
        if (player.GetComponent<PlayerHP>().Hp <= 0)
        {
            gameEnd = true;
            AudioManager.Instance.PlayBGM(false);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ActiveSlowTime()
    {
        SlowTime = 10.0f;
    }

    public void ActiveDestoryer()
    {
        projectileDestoryer.SetActive(true);
    }

    public void SetGameMode(int mode)
    {
        GameMode = mode;
        SceneManager.LoadScene("Game");
    }
}
