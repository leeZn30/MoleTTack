using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    [Header("���� ����")]
    [SerializeField] MoleQueue moleQueue = new MoleQueue();

    [Header("�δ���")]
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
