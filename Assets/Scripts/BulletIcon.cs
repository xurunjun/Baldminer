using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIcon : MonoBehaviour
{
    public GameObject[] BulletImagelist;
    public int Bullet;

    private void Start() {
        UpdateBulletImage(GameManager.Instance._NEXT);
    }
    public void UpdateBulletImage(int bullet)
    {
        BulletImagelist[Bullet].SetActive(false);

        Bullet=bullet;


        switch (Bullet)
        {
            case 0: BulletImagelist[0].SetActive(true); break;
            case 1: BulletImagelist[1].SetActive(true); break;
            case 2: BulletImagelist[2].SetActive(true); break;
            case 3: BulletImagelist[3].SetActive(true); break;
        }
    }
}
