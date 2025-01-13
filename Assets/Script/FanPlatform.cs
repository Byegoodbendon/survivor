using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : MonoBehaviour
{
    Animator fanplatform_animator;
    void Start()
    {
        fanplatform_animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            fanplatform_animator.Play("FanPlatform");
        }

    }
}
