using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] int points = 10;

    private void OnDestroy()
    {
        GameManager.Instance.AddPoints(points);
    }
}