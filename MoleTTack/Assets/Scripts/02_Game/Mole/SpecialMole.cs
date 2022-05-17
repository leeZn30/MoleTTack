using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMole : Mole
{

    protected override void setInitSpawnTime()
    {
        spawnTime = Random.Range(3.0f, 10.0f);
    }

    protected override void setSpawnTime()
    {
        spawnTime = Random.Range(15.0f, 30.0f);
    }
}
