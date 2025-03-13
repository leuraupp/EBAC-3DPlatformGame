using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Projetile Atributes")]
    public float timeToDestroy = 1f;
    public int damage = 1;
    public float speed =50f;

    private void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision) {
    }
}
