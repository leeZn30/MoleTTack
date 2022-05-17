using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("GameTime")]
    [SerializeField] private float gameTime;

    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();

        gameTime = GameManager.Instance.gameTime;

        slider.maxValue = gameTime;
        slider.value = gameTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        //timeRunning();
    }

    private void Update()
    {
        timeRunning();
    }


    private void timeRunning()
    {
        if (GameManager.Instance.isGameStart)
        {

            if (slider.value > 0)
            {
                slider.value -= Time.deltaTime;
            }
            else
                GameManager.Instance.isGameStart = false;
        }

    }
}
