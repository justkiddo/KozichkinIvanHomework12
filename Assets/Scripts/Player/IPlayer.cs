using UnityEngine;

public interface IPlayer
{
    Vector3 GetCurrentPosition();
    void MoveTo(Vector3 pos);
    void Shoot();
}