using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DrawTrigger : MonoBehaviour
{
    //The color of the trigger gizmo
    public Color boxColor = new Color(1, 0, 0, 0.25f);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        Gizmos.color = boxColor;
        Gizmos.DrawCube(transform.position + bc.center, bc.size);
    }


}
