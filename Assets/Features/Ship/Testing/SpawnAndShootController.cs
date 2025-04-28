using UnityEngine;

public class SpawnAndShootController : MonoBehaviour
{
    public GameObject squarePrefab;
    public GameObject laserPrefab;
    public float laserSpeed = 10f;

    private GameObject _currentSquare;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            if (_currentSquare)
            {
                FireLaser();
            }
        }
        else if (Input.GetMouseButtonDown(0)) // Left Click
        {
            if (_currentSquare != null)
            {
                MoveSquare();
            }
            else
            {
                SpawnSquare();
            }
        }
    }

    void SpawnSquare()
    {
        Vector3 spawnPosition = GetMouseWorldPosition();
        _currentSquare = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);
    }

    void MoveSquare()
    {
        Vector3 targetPosition = GetMouseWorldPosition();
        _currentSquare.transform.position = targetPosition;
    }

    void FireLaser()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Vector3 direction = (mouseWorldPosition - _currentSquare.transform.position).normalized;

        GameObject laser = Instantiate(laserPrefab, _currentSquare.transform.position, Quaternion.identity);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.velocity = direction * laserSpeed;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        return mouseWorld;
    }
}