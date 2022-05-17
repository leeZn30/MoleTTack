using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [Header("Times")]
    //[SerializeField] protected float initSpawnTime;
    [SerializeField] protected float spawnTime;
    [SerializeField] protected float stayTime;

    [Header("Score")]
    [SerializeField] protected int score;

    [Header("variables")]
    public bool isReady;

    private void Awake()
    {
        setInitSpawnTime();
    }


    protected virtual void setInitSpawnTime()
    {
        
    }

    protected virtual void setSpawnTime()
    {

    }

    public float getSpawnTime()
    {
        return spawnTime;
    }

    protected void detectTouch()
    {
        if (isReady)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            float maxDistance = 100;


            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (hit.collider.tag == "Mole")
                {
                    Debug.Log("Mole hitted!");
                }
            }
        }
    }
}
