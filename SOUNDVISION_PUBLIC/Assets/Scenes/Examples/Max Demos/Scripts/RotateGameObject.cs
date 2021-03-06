﻿using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]

public class UnityRotationEvent : UnityEvent<float>
{ }

public class RotateGameObject : MonoBehaviour
{
    [SerializeField] float smooth = 5.0f;
    [SerializeField] private float factor = 1;
    [SerializeField] bool tiltAngleHorizontal;
    [SerializeField] bool tiltAngleVertical;

    [SerializeField] private UnityRotationEvent onRotationProcessed;

    private float input_;

    public void OnValueChanged(float value)
    {
        input_ = Mathf.Repeat(input_, 1080) + value * (UnityEngine.Random.Range(0, 1) * 2 -1) * factor;        
    }

    private void Update()
    {
        float tiltAroundY;
        float tiltAroundX;

        // Smoothly tilts a transform towards a target rotation.
        if (tiltAngleHorizontal)
        {
            tiltAroundY = input_;
        }
        else tiltAroundY = 0;


        if (tiltAngleVertical)
        {
            tiltAroundX = input_;
        }
        else tiltAroundX = 0;


        Quaternion target = Quaternion.Euler(tiltAroundX , tiltAroundY, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}


