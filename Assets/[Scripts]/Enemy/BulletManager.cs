using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Singleton */
[System.Serializable]
public class BulletManager
{
    private static BulletManager instance = null;

    private BulletManager()
    {
        Initialize();
    }

    public static BulletManager Instance()
    {
        if(instance == null)
        {
            instance = new BulletManager();
        }

        return instance;
    }

    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;

    public int enemyBulletNumber;
    public int playerBulletNumber;

    private BulletFactory factory;


    private void Initialize()
    {
        //Creates Empty Queue
        enemyBulletPool = new Queue<GameObject>(); 
        playerBulletPool = new Queue<GameObject>(); 

        factory = GameObject.FindObjectOfType<BulletFactory>();
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = factory.createBullet(type);

        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(temp_bullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                playerBulletNumber++;
                break;
        }
    }

    public GameObject GetBullet(Vector2 spawnPosition, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;

        switch (type)
        {
            case BulletType.ENEMY:
                if (enemyBulletPool.Count < 1)
                {
                    AddBullet(type);
                }

                temp_bullet = enemyBulletPool.Dequeue();
                break;
            case BulletType.PLAYER:
                if (playerBulletPool.Count < 1)
                {
                    AddBullet(type);
                }

                temp_bullet = playerBulletPool.Dequeue();
                break;
        }

        temp_bullet.transform.position = spawnPosition;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }


    public void ReturnBullet(GameObject returnedBullet, BulletType type = BulletType.ENEMY)
    {
        returnedBullet.SetActive(false);

        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(returnedBullet);
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(returnedBullet);
                break;
        }
    }




    
}
