using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _projectile;
    [SerializeField] private Camera _cam;
    private bool _isSelected = false;

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0) && !_isSelected)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.GetComponent<Birds>() != null) 
            {
                _projectile = hit.transform;
                _isSelected = true;
            }
        }
        FollowMousePosition();

        if (Input.GetKeyDown(KeyCode.A)) 
        {
            DropProjectile();
        }
    }

    private void FollowMousePosition()
    {
        if (!_isSelected)
            return;
        Vector3 mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition); 
        mouseWorldPosition.z = 0f;
        _projectile.position = mouseWorldPosition;
    }

    private void DropProjectile() 
    {
        if (_isSelected) 
        {
            _projectile = null;
            _isSelected = false;
        }
    }



}
