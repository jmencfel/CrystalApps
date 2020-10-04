using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }
    #endregion

    [SerializeField] private Text TimeText;
    [SerializeField] private Text DeathsText;

    [SerializeField] private Text VictoryText;
    private int deathCount = 0;

    public void Update()
    {
        TimeText.text = "Time: " + Time.time;
    }
    public void IncreaseDeathCount()
    {
        DeathsText.text = "Deaths: " + ++deathCount;
    }
    public void DisplayVictoryText()
    {
        VictoryText.gameObject.SetActive(true);
    }
   
}
