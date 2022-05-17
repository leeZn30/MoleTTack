using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMole : Mole
{

    protected override void setInitSpawnTime()
    {
        spawnTime = Random.Range(0.0f, 5.0f);
    }

    protected override void setSpawnTime()
    {
        spawnTime = Random.Range(3.0f, 6.0f);
    }
}
