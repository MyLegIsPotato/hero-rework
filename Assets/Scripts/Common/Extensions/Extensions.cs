using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Common.Extensions
{
    public static class Extensions
    {
        public static void SubscribeToAction(this InputActionMap map, InputActionReference actionReference, InputActionPhase actionPhase, Action<InputAction.CallbackContext> actionCallback)
        {
            switch (actionPhase)   
            {
                case InputActionPhase.Started:
                    map[actionReference.name.Replace(map.name + "/", "")].started += actionCallback;
                    break;
                case InputActionPhase.Performed:
                    map[actionReference.name.Replace(map.name + "/", "")].performed += actionCallback;
                    break;
                case InputActionPhase.Canceled:
                    map[actionReference.name.Replace(map.name + "/", "")].canceled += actionCallback;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionPhase), actionPhase, null);  
            }
        }
        
        public static void UnsubscribeFromAction(this InputActionMap map, InputActionReference actionReference, InputActionPhase actionPhase, Action<InputAction.CallbackContext> actionCallback)
        {
            switch (actionPhase)
            {
                case InputActionPhase.Started:
                    map[actionReference.name.Replace(map.name + "/", "")].started -= actionCallback;
                    break;
                case InputActionPhase.Performed:
                    map[actionReference.name.Replace(map.name + "/", "")].performed -= actionCallback;
                    break;
                case InputActionPhase.Canceled:
                    map[actionReference.name.Replace(map.name + "/", "")].canceled -= actionCallback;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(actionPhase), actionPhase, null);
            }
        }
    }
}