using System.Collections;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        StartCoroutine(DestroyBullet(bullet));
    }

    private IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }
    
}