using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Common.SimpleComponents
{
    public class UnparentFollow : MonoBehaviour
    {
        private Transform parent;

        private void Awake()
        {
            parent = transform.parent;
            transform.SetParent(null);
        }

        void Update() => transform.position = parent.position;
    }
}