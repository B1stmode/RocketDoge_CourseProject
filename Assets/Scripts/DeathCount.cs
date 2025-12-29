using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DeathCount : MonoBehaviour
{
    public static DeathCount instance;

    public TMP_Text deathCount;
    public static int deathScore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        deathCount.text = "T O T A L  D E A T H S : " + deathScore.ToString();
    }

    void Update()
    {
        
    }

    public void AddPoint()
    {
        deathScore++;
        deathCount.text = "T O T A L  D E A T H S : " + deathScore.ToString();
    }

    public void ResetCounter()
    {
        deathScore = 0;
    }
}
