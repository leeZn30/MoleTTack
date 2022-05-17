using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("게임 진행 관련")]
    public bool isGameStart;
    public float gameTime;

    [Header("Score")]
    [SerializeField] private int score;

    private void Awake()
    {
        isGameStart = true;
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
