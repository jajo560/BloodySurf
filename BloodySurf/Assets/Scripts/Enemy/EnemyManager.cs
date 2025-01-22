using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float spawn_max_seconds = 5;
    [SerializeField] float spawn_min_seconds = 3;
    [SerializeField] List<GameObject> enemies;

    BoxCollider box;

    bool spawn_enemy = false;
    bool timer_started = false;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_enemy)
        {
            #region SPAWN_ENEMY
            //Get random enemy
            int spawned_enemy_num = Random.Range(0, enemies.Count);
            //Get start position
            float bottomX = transform.position.x - box.size.x / 2;
            float bottomY = transform.position.y - box.size.y / 2;
            //Get random position
            Vector3 instantiatePos = new Vector3(
                Random.Range(0, box.size.x) + bottomX,
                Random.Range(0, box.size.y) + bottomY,
                transform.position.z);
            //If wave, y = bottomY
            Enemy enemy;
            if(enemy = enemies[spawned_enemy_num].GetComponent<Enemy>())
            {
                if (enemy.GetWave())
                {
                    instantiatePos.y = bottomY + enemies[spawned_enemy_num].transform.localScale.y / 2;
                }
            }
            
            Instantiate(enemies[spawned_enemy_num], instantiatePos, Quaternion.identity);
            
            spawn_enemy = false;
            #endregion
        }
        else if (!timer_started)
        {
            float spawn_seconds = Random.Range(spawn_min_seconds, spawn_max_seconds);
            StartCoroutine(StartTimer(spawn_seconds));
            timer_started = true;
        }
    }

    IEnumerator StartTimer(float spawn_seconds)
    {
        yield return new WaitForSeconds(spawn_seconds);
        spawn_enemy = true;
        timer_started = false;
    }
}
