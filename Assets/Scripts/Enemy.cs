using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    Scoreboard scoreboard;
    private void Awake()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();

    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            //we can set rotation to one of isntantiated object
            Instantiate(destroyedVFX, this.transform.position, Quaternion.identity);
            scoreboard.IncreaseScore(scoreValue);
            //Debug.Log("collision on enemy");
            Destroy(gameObject);
        }
    }
}
