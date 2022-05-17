using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoleQueue
{
    private List<Mole> queue;

    // ������
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
            if (queue.Last<Mole>().getSpawnTime() < mole.getSpawnTime()) // �� �ڿ� ���� ũ�ٸ�
            {
                queue.Add(mole);
                return;
            }

            foreach (Mole m in queue) // �� ó���̳� �߰��� �ִ� ��
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
