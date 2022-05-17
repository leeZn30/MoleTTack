using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoleQueue
{
    private List<Mole> queue;

    // 생성자
    public MoleQueue()
    {
        queue = new List<Mole>();

    }

    public List<Mole> getQueue()
    {
        return queue;
    }

    public void Enqueue(Mole mole)
    {
        /**
        if (queue.Count == 0)
        {
            queue.Add(mole);
        }
        else
        {
            if (queue.Last<Mole>().getSpawnTime() < mole.getSpawnTime()) // 맨 뒤에 보다 크다면
            {
                queue.Add(mole);
                return;
            }

            foreach (Mole m in queue) // 맨 처음이나 중간에 있는 값
            {
                if (mole.getSpawnTime() < m.getSpawnTime())
                {
                    int index = queue.IndexOf(m);
                    queue.Insert(index, mole);
                    break;
                }
                else if (mole.getSpawnTime() == m.getSpawnTime())
                {
                    int index = queue.IndexOf(m);
                    queue.Insert(index + 1, mole);
                    break;
                }
            }
        }
        **/

        queue.Add(mole);
        queue.Sort((x, y) => { return x.getSpawnTime().CompareTo(y.getSpawnTime()); });
    }

    public object Dequeue()
    {
        Mole mole = queue.First<Mole>();
        queue.RemoveAt(0);

        return mole;
    }

    public bool isEmpty()
    {
        if (queue.Count == 0)
            return true;
        else
            return false;
    }

    public void Clear()
    {
        queue.Clear();
    }


}
