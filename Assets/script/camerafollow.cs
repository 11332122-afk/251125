using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float height = 12f;
    public float distance = 8f;

    void LateUpdate()
    {
        if (player == null) return;
        transform.position = player.position
            + new Vector3(0f, height, -distance);
        transform.LookAt(player.position + Vector3.up);
    }
}
