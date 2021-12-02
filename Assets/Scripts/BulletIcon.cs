using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIcon : MonoBehaviour
{
    public GameObject[] BulletImagelist;
    public int Bullet;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < BulletImagelist.Length; i++)
            BulletImagelist[i].SetActive(false);
    }

    public void UpdateBulletImage()
    {
        for (int i = 0; i < BulletImagelist.Length; i++)
            BulletImagelist[i].SetActive(false);


        switch (Bullet)
        {
            case 1: BulletImagelist[0].SetActive(true); break;
            case 2: BulletImagelist[1].SetActive(true); break;
            case 3: BulletImagelist[2].SetActive(true); break;
            case 4: BulletImagelist[3].SetActive(true); break;
        }
    }

    public void Update()
    {
        UpdateBulletImage();

    }
}
