using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] turretPrefabs;

    private void OnMouseDown()
    {
        Instantiate(turretPrefabs[SetTile.turretIndex], transform.position, Quaternion.identity);
    }
}
