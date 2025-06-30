using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public float dist = .2f;
    public float magneticSpeed = 5f;

    private void Update() {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) > dist) {
            magneticSpeed++;
            transform.position = Vector3.MoveTowards(transform.position, Player.Instance.transform.position, magneticSpeed * Time.deltaTime);
        }
    }
}
