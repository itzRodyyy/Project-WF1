using UnityEngine;

public class gameManager : MonoBehaviour
{
    static public gameManager instance;
    public GameObject player;
    public combat playerCombat;
    public movement playerMovement;
    public int gameGoalCount;

    float timeScaleOriginal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        instance = this;
        player = GameObject.FindWithTag("Player");
        playerCombat = player.GetComponent<combat>();
        playerMovement = player.GetComponent<movement>();
        timeScaleOriginal = Time.timeScale;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void statePause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void stateUnpause()
    {
        Time.timeScale = timeScaleOriginal;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void updateGameGoal(int amount)
    {
        gameGoalCount += amount;
        if (gameGoalCount <= 0)
        {
            statePause();
            UIManager.instance.openWinMenu();
        }
    }
}
