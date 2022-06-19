using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    [Header("Times")]
    //[SerializeField] protected float initSpawnTime;
    [SerializeField] protected float spawnTime;
    [SerializeField] protected float stayTime;
    [SerializeField] protected float initTime = 0.0f;
    [SerializeField] protected float upDownTime = 0.5f;

    [Header("Score")]
    public int score;

    [Header("variables")]
    public bool isReady;
    public bool isRunning;
    public int holeIndex;
    protected bool isTouched;

    [Header("Positions")]
    public Vector3 startPos;

    private void Awake()
    {
        setInitSpawnTime();
    }

    private void Update()
    {
        if (GameManager.Instance.isGameStart)
        {
            detectTouch();
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public void callSpawnMole()
    {
        StartCoroutine(spawnMole());
    }

    protected IEnumerator spawnMole()
    {
        if (!isRunning)
        {
            isTouched = false;

            isRunning = true;
            // 일정 시간마다 스폰
            yield return new WaitForSecondsRealtime(spawnTime);
            // 여기서 hidden이 이상함

            isReady = true;
            StartCoroutine(moleUpMove());
        }
    }

    protected IEnumerator moleUpMove()
    {
        float startTime = Time.time;

        //Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        endPos.y = 0.7f;

        while (Time.time - startTime <= upDownTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (Time.time - startTime) / upDownTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(stayTime);

        StartCoroutine(moleDownMove());
    }

    protected IEnumerator moleDownMove()
    {
        float startTime = Time.time;

        Vector3 initPos = transform.position;
        Vector3 endPos = transform.position;
        endPos.y = -1.0f;

        while (Time.time - startTime <= upDownTime)
        {
            transform.position = Vector3.Lerp(initPos, endPos, (Time.time - startTime) / upDownTime);
            yield return null;
        }

        isReady = false;
        setSpawnTime();

        MoleManager.Instance.addMole(this);
        MoleManager.Instance.setHole(holeIndex);

        isRunning = false;

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
            if (Input.touchCount != 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    Debug.Log(touch);

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

    public void calltouched()
    {
        beeingTouched();
    }

    protected virtual void beeingTouched()
    {
        isReady = false;
        setSpawnTime();

        MoleManager.Instance.addMole(this);
        MoleManager.Instance.setHole(holeIndex);

        isRunning = false;

        StopAllCoroutines();
    }

    private void OnMouseDown()
    {
        if (isReady && !isTouched)
        {
            GameManager.Instance.addScore(score);
            beeingTouched();
        }
    }

}
