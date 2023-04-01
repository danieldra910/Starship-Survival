using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static int Score;
    private TextMeshProUGUI ScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"Score: {Score}";
    }
}
