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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathCount.text = "T O T A L  D E A T H S : " + deathScore.ToString();
    }

    // Update is called once per frame
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
