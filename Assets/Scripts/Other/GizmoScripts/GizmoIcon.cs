using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoIcon : MonoBehaviour
{
    void OnDrawGizmos() {
        Gizmos.DrawIcon(transform.position, "enemy.png", true);
    }
}
