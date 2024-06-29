using System.Collections;
using BlobIO.Game;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
    public float growthRate = 0.01f; // Büyüme oraný
    public float growthDuration = 5f; // Büyüme süresi
    private NavMeshAgent agent;
    private Vector3 originalScale;
    private Dusman_Oluþturma manager; // Manager scripti
    [SerializeField]private  ParticleSystem particle; // Particle system referansý


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originalScale = transform.localScale;

        if (agent.isOnNavMesh)
        {
            StartCoroutine(MoveToRandomPosition());
            StartCoroutine(GrowthRoutine());
        }
    }

    public void SetManager(Dusman_Oluþturma manager)
    {
        this.manager = manager;
    }

    private IEnumerator MoveToRandomPosition()
    {
        while (true)
        {
            Vector3 randomPosition = GetRandomPosition();
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(randomPosition);
            }
            yield return new WaitForSeconds(Random.Range(2, 5)); // Rastgele sürelerle yeni pozisyonlara git
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-25f, 25f);
        float z = Random.Range(-25f, 25f);
        return new Vector3(x, 0, z);
    }

    private IEnumerator GrowthRoutine()
    {
        Vector3 targetScale = originalScale * (1 + growthRate);
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / growthDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Engel") || collision.gameObject.CompareTag("Player"))
        {
            if (manager != null)
            {
                manager.EnemyDestroyed(gameObject);
                Destroy(this.gameObject);

                // Player'a çarpýldýðýnda particle systemi çalýþtýr
                if (collision.gameObject.CompareTag("Player") && particle != null)
                {
                    particle.Play();
                 
                }
            }
        }
    }


}
