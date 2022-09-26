using UnityEngine;

public class CylinderTurnScript : MonoBehaviour
{
    public Transform Level;
    public float Sensivity;

    private Vector3 _previousMousPosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousPosition;
            Level.Rotate(0, -delta.x*Sensivity, 0);
        }

        _previousMousPosition = Input.mousePosition;
    }
}
