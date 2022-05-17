using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    [Header("등장 순서")]
    [SerializeField] MoleQueue moleQueue = new MoleQueue();

    [Header("두더지")]
    [SerializeField] List<GameObject> moles;

    [Header("Holes")]
    [SerializeField] List<GameObject> holes;

    private void Awake()
    {
        foreach (GameObject mole in moles)
        {
            Mole m = mole.GetComponent<Mole>();

            moleQueue.Enqueue(m);
        }
    }

    void Start()
    {
    }

    void Update()
    {
        
    }
}
