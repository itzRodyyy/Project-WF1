using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("== HUD ==")]
    [SerializeField] GameObject HUD;
    [SerializeField] Image healthBar;
    bool hudActive;

    [Header("== Menus ==")]
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject diedMenu;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject playerInventory;
    [SerializeField] GameObject chestInventory;

    public static UIManager instance;
    public GameObject activeMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        hudActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            closeMenu();
        }
    }

    public void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)gameManager.instance.playerCombat.health / 
            gameManager.instance.playerCombat.maxHealth;
    }

    public void closeMenu()
    {
        if (activeMenu != null)
        {
            activeMenu.SetActive(false);
            activeMenu = null;
            ToggleHUD();
            gameManager.instance.stateUnpause();
        }
    }

    public void openWinMenu()
    {
        closeMenu();
        ToggleHUD();
        activeMenu = winMenu;
        activeMenu.SetActive(true);
    }

    public void openDiedMenu()
    {
        closeMenu();
        ToggleHUD();
        activeMenu = diedMenu;
        activeMenu.SetActive(true);
    }

    public void ToggleHUD()
    {
        hudActive = !hudActive;
        HUD.SetActive(hudActive);
    }

    public void openPlayerInventory()
    {
        gameManager.instance.statePause();
        closeMenu();
        ToggleHUD();
        activeMenu = inventory;
        activeMenu.SetActive(true);
        chestInventory.SetActive(false);
    }

    public void OpenContainerInventory()
    {
        gameManager.instance.statePause();
        closeMenu();
        ToggleHUD();
        activeMenu = inventory;
        activeMenu.SetActive(true);
        chestInventory.SetActive(true);
    }
}
