using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Projetile Atributes")]
    public float timeToDestroy = 1f;
    public int damage = 1;
    public float speed =50f;

    public List<string> tagsToHit;

    private void Awake() {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision) {
        foreach (var t in tagsToHit) {
            if (collision.transform.tag == t) {
                Debug.Log("OnCollisionEnter", this);
                var damageable = collision.gameObject.GetComponent<IDamageable>();
                Debug.Log("Damageable: " + damageable, this);
                if (damageable != null) {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = dir.normalized;
                    dir.y = 0;

                    damageable.Damage(damage, dir);
                }
            }
        }

        Destroy(gameObject);
    }

}
