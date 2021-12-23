using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RailCar
{
    public enum DIRECTION
    {
        LEFT,
        RIGHT
    };

    private GameObject goods;

    public DIRECTION dir;

    public List<Vector2> rail;

    private float vec;

    private float nextPoint;

    private int count = 0;

    private bool isStop = false;

    private UnityAction action;

    public RailCar(GameObject goods, DIRECTION dir, List<Vector2> rail, float vec)
    {
        this.goods = goods;
        if (dir == DIRECTION.LEFT)
        {
            this.goods.transform.position = rail[rail.Count - 1];
        }
        else
        {
            this.goods.transform.position = rail[0];
        }
        this.goods.GetComponent<FeverNumber>().action = stop;
        this.dir = dir;
        this.rail = rail;
        this.vec = vec / (rail[1].x - rail[0].x);
    }

    public void go()
    {
        if (this.dir == DIRECTION.LEFT)
        {
            nextPoint = rail[rail.Count - 1].x;
            count = rail.Count - 1;
            goLeft();
        }
        else
        {
            nextPoint = rail[1].x;
            count = 1;
            goRight();
        }
    }

    private async void goRight()
    {
        while (!isStop && count <= rail.Count - 1 && rail[rail.Count - 1].x - goods.transform.position.x > 2f)
        {
            if (goods == null)
                break;
            Vector2 nextPos = Vector2.Lerp(goods.transform.position, rail[count], vec);
            goods.transform.position = nextPos;
            if (nextPoint - nextPos.x < 1f)
            {
                goods.transform.position = rail[count];
                count++;
                if (count <= rail.Count - 1)
                    nextPoint = rail[count].x;
            }
            await Task.Yield();
        }
        if (goods != null)
            ObjectPool.Instance.PushObject(goods);
        action.Invoke();
    }

    private async void goLeft()
    {
        while (!isStop && count >= 0 && goods.transform.position.x - rail[0].x > 2f)
        {
            if (goods == null)
                break;
            Vector2 nextPos = Vector2.Lerp(goods.transform.position, rail[count], vec);
            goods.transform.position = nextPos;
            if (nextPos.x - nextPoint < 1f)
            {
                goods.transform.position = rail[count];
                count--;
                if (count >= 0)
                    nextPoint = rail[count].x;
            }
            await Task.Yield();
        }
        if (goods != null)
            ObjectPool.Instance.PushObject(goods);
        action.Invoke();
    }

    public void setStopAction(UnityAction action)
    {
        this.action = action;
    }

    public void stop()
    {
        isStop = true;
    }
}
