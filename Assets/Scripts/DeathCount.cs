using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public Text deathCount;
    int deathScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathCount.text = "T O T A L  D E A T H S : " + deathScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
