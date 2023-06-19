using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour, IPlayer
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float speed = 5f;
    
    
    public Vector3 GetCurrentPosition() => transform.position;
    public void MoveTo(Vector3 pos)
    {
        navMeshAgent.SetDestination(pos);
    }

    public void Shoot(Vector3 pos)
    {
        var direction = pos - transform.position;
        var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(direction.x,direction.y, direction.z) * speed;
        StartCoroutine(DestroyBullet(bullet));
    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }
    
}