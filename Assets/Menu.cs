using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;

    public Slider speedSlider;
    public static float speed = 8;
    public Slider amountSlider;
    public static float amount = 1f;
    public Slider sizeSlider;
    public static float size = 1f;
    public Dropdown dropdown;
    public static int backgroundOption = 0;

    public Text speedText;
    public Text amountText;
    public Text sizeText;
    
    // Start is called before the first frame update
    void Start()
    {
        loadSave();
    }

    // Update is called once per frame
    void Update()
    {
        textUpdate();
    }

    private void loadSave()
    {
        if (PlayerPrefs.HasKey("speed"))
        {
            Debug.Log("Contains speed" + PlayerPrefs.GetFloat("speed"));
            speed = PlayerPrefs.GetFloat("speed");
            speedSlider.value = speed;
        }
        
        if (PlayerPrefs.HasKey("amount"))
        {
            Debug.Log("Contains amount" + PlayerPrefs.GetFloat("amount"));
            amount = PlayerPrefs.GetFloat("amount");
            amountSlider.value = amount;
        }
        
        if (PlayerPrefs.HasKey("size"))
        {
            Debug.Log("Contains size" + PlayerPrefs.GetFloat("size"));
            size = PlayerPrefs.GetFloat("size");
            sizeSlider.value = size;
        }

        if (PlayerPrefs.HasKey("background"))
        {
            Debug.Log("background" + PlayerPrefs.GetInt("background"));
            backgroundOption = PlayerPrefs.GetInt("background");
            dropdown.value = backgroundOption;
        }
    }

    private void textUpdate()
    {
        speedText.text = speedSlider.value.ToString();
        amountText.text = amountSlider.value.ToString();
        sizeText.text = sizeSlider.value.ToString();
    }

    private void setAndSave()
    {
        speed = speedSlider.value;
        amount = amountSlider.value;
        size = sizeSlider.value;
        backgroundOption = dropdown.value;
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.SetFloat("amount", amount);
        PlayerPrefs.SetFloat("size", size);
        PlayerPrefs.SetInt("background", backgroundOption);
    }

    // Start Button Event 
    public void startGame()
    {
        SceneManager.LoadScene("PongScene");
    }

    // Options Button Event 
    public void Options()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }

    // Quit Button Event 
    public void quitGame()
    {
        Debug.Log("quit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        //Application.Quit();                                 // Quits the client build
        //UnityEditor.EditorApplication.isPlaying = false;    // Quits Unity Build
    }

    // Back To Menu Button Event
    public void backToMenu()
    {
        setAndSave();
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
}
