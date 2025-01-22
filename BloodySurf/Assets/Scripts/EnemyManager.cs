using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float spawn_max_seconds = 5;
    public float spawn_min_seconds = 3;
    public List<GameObject> enemies;

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
            int spawned_enemy_num = Random.Range(0, enemies.Count);
            float startX = transform.position.x - box.size.x / 2;
            float startY = transform.position.y - box.size.y / 2;
            Vector3 randomPos = new Vector3(
                Random.Range(0, box.size.x) + startX,
                Random.Range(0, box.size.y) + startY,
                transform.position.z);
            GameObject enemy = Instantiate(enemies[spawned_enemy_num], randomPos, Quaternion.identity);
            
            spawn_enemy = false;
        }
        else if (!timer_started)
        {
            float spawn_seconds = Random.Range(spawn_min_seconds, spawn_max_seconds);
            Debug.Log(spawn_seconds);
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
