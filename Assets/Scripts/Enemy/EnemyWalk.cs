using UnityEngine;


namespace Enemy {
    public class EnemyWalk : EnemyBase {

        [Header("Enemy Walk Settings")]
        public GameObject[] wayPoints;
        public float minDistance = 1f;
        public float speed = 5f;

        private int index = 0;

        public override void Update() {
            base.Update();
            if (wayPoints != null && wayPoints.Length > 0) {
                if (Vector3.Distance(transform.position, wayPoints[index].transform.position) < minDistance) {
                    index++;
                    if (index >= wayPoints.Length) {
                        index = 0;
                    }
                }

                transform.position = Vector3.MoveTowards(transform.position, wayPoints[index].transform.position, speed * Time.deltaTime);
                transform.LookAt(wayPoints[index].transform.position);
            }
        }
    }
}

