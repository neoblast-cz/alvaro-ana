using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerConfetti : MonoBehaviour
{
    private ParticleSystem confettiParticle;
    private bool cheeringUsed;
    private bool keepSpawning;

    private float spawnTimer;
    private const float SPAWN_TIMER_MAX = 1f;
    float colliderWidth;

    void Start() {
        keepSpawning = false;
        colliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update() {
        if (keepSpawning) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f) {
                spawnTimer += SPAWN_TIMER_MAX;
                int spawnAmount = Random.Range(1, 4);
                for (int i = 0; i < spawnAmount; i++) {
                    SpawnConfetti();
                }
            }
        }
    }

    void SpawnConfetti() {
        GameObject confettiGO = Instantiate(GameAssets.instance.confettiBurstPF, transform);
        
        float randomX = transform.position.x + Random.Range(-colliderWidth, colliderWidth);
        confettiGO.transform.position = new Vector3(randomX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        keepSpawning = true;
        if (!cheeringUsed) {
            cheeringUsed = true;
            AudioManager.instance.PlaySound(AudioManager.Sound.Wedding_Cheering);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        keepSpawning = false;
    }
}
