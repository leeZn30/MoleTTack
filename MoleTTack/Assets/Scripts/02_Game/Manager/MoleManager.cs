using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : Singleton<MoleManager>
{
    [Header("등장 순서")]
    [SerializeField] MoleQueue moleQueue = new MoleQueue();

    [Header("두더지")]
    [SerializeField] List<GameObject> moles;
    [SerializeField] GameObject mole;

    [Header("Holes")]
    [SerializeField] List<GameObject> holes;
    [SerializeField] bool[] holePossible = new bool[9] { true, true, true, true, true, true, true, true, true};

    private void Awake()
    {
        foreach (GameObject mole in moles)
        {
            Mole m = mole.GetComponent<Mole>();

            moleQueue.Enqueue(m);
        }

        //moleQueue.Enqueue(mole.GetComponent<Mole>());
    }

    void Start()
    {
    }

    void Update()
    {
        if (GameManager.Instance.isGameStart)
        {
            if (moleQueue.Count != 0)
            {
                locateMole(moleQueue.Dequeue().gameObject);
            }
        }

    }

    public void addMole(Mole mole)
    {
        moleQueue.Enqueue(mole);
    }

    public void setHole(int index)
    {
        holePossible[index] = true;
    }

    private void locateMole(GameObject mole)
    {
        int index = findPossibleHole();
        mole.GetComponent<Mole>().holeIndex = index;

        Vector3 location = holes[index].transform.position;
        location.y = -1f;

        mole.transform.position = location;
        mole.GetComponent<Mole>().startPos = location;

        spawnMoleProcess();
    }

    private void spawnMoleProcess()
    {
        mole.GetComponent<Mole>().callSpawnMole();
    }

    private List<int> initHolePossible()
    {
        List<int> holeList = new List<int>();

        // 현재 false인 곳 빼기
        for (int i=0; i < holePossible.Length; i++)
        {
            if (holePossible[i])
            {
                holeList.Add(i);
            }
        }

        return holeList;
    }

    private int findPossibleHole()
    {
        /**
        List<int> holeList = initHolePossible();

        int index = Random.Range(0, holeList.Count);

        Debug.Log("find hole: " + holeList[index]);

        return holeList[index];
        **/

        while (true)
        {
            int index = Random.Range(0, 9); // index 또 안 빈 곳 뽑으면 안되게 > 너무 에반데


            if (holePossible[index])
            {
                holePossible[index] = false;

                return index;
            }
        }
    }
}
