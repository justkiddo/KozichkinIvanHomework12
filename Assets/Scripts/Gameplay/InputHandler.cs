using System;
using UnityEngine;
using Zenject;

public class InputHandler: ITickable
{
    private readonly Camera _camera;
    public Action<Vector3> OnClickedMove;
    public Action OnClickedShoot;
    
    private const string LayerName = "Ground";


    public InputHandler([Inject(Id = BaseIds.GameCameraId)] Camera camera)
    {
        _camera = camera;
    }

    public void Tick()
    {
        PlayerMoving();
        PlayerShooting();
    }

    private void PlayerShooting()
    {
        if (Input.GetMouseButtonDown(1))
        {
                OnClickedShoot?.Invoke();
        }
    }

    private void PlayerMoving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var layer = LayerMask.GetMask(LayerName);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000, layer))
            {
                OnClickedMove?.Invoke(hitInfo.point);
            }
        }
    }
}