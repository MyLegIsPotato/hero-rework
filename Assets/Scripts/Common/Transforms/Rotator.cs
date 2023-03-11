using System;
using System.Collections;
using UnityEngine;

namespace Project.Common.Transforms
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float spinAngle = 90;
        
        [SerializeField]
        private float spinSpeed = 500;

        [SerializeField]
        private GameObject weaponObject;
        
        private float totalspinDelta;
        private Vector3 initialRotation;
        
        private event Action OnSpinComplete;

        private void Awake()
        {
            OnSpinComplete += OnSpinCompleted;
            weaponObject.SetActive(false);
            initialRotation = transform.localEulerAngles + Vector3.up * 90 - (Vector3.up * spinAngle/2);
        }
        
        public void StartSpin()
        {
            StartCoroutine(SpinCoroutine());
        }

        private IEnumerator SpinCoroutine()
        {
            weaponObject.SetActive(true);
            totalspinDelta = 0;

            while (totalspinDelta < spinAngle)
            {
                float spinDelta = spinSpeed * UnityEngine.Time.deltaTime;
                totalspinDelta += spinDelta;
                transform.Rotate(Vector3.up, spinDelta);
                yield return null;
            }

            OnSpinComplete?.Invoke();
            yield return null;
        }

        private void OnSpinCompleted()
        {
            weaponObject.SetActive(false);
            transform.localEulerAngles = initialRotation;
        }
    }
}
