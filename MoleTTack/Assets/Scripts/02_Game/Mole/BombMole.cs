using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMole : Mole
{

    protected override void setInitSpawnTime()
    {
        spawnTime = Random.Range(10.0f, 13.0f); //10~13
    }

    protected override void setSpawnTime()
    {
        spawnTime = Random.Range(10.0f, 15.0f); // 10~15
    }


    private void detectOtherMoles()
    {
        Collider[] hitColliders = Physics.OverlapBox(
            transform.position,
            new Vector3(3, 3, 3),
            Quaternion.identity
            );

        foreach (Collider collider in hitColliders)
        {
            if (collider.tag == "Mole" && collider.transform.gameObject != this.gameObject)
            {
                if (collider.transform.gameObject.GetComponent<Mole>().isReady)
                {
                    GameManager.Instance.addScore(collider.transform.gameObject.GetComponent<Mole>().score * (-1));
                    collider.transform.gameObject.GetComponent<Mole>().calltouched();
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (isReady && !isTouched)
        {
            GameManager.Instance.addScore(score);
            detectOtherMoles();
            beeingTouched();
        }
    }
}
