using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMole : Mole
{

    protected override void setInitSpawnTime()
    {
        spawnTime = Random.Range(10.0f, 13.0f);
    }

    protected override void setSpawnTime()
    {
        spawnTime = Random.Range(10.0f, 15.0f);
    }
}
