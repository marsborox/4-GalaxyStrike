using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyedVFX;
    private void OnParticleCollision(GameObject other)
    {
        //we can set rotation to one of isntantiated object
        Instantiate(destroyedVFX,this.transform.position,Quaternion.identity);
        //Debug.Log("collision on enemy");
        Destroy(gameObject);
    }
}
