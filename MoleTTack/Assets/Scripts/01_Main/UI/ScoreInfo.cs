using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreInfo : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        setScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setScore()
    {
        text.text = "MY BEST SCORE\n" + PlayerPrefs.GetInt("PlayerScore");
    }
}
