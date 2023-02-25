using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    [SerializeField] private Transform lookAt ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directon = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        lookAt.localPosition = new Vector3(directon.x, 2, directon.y);
    }
}
