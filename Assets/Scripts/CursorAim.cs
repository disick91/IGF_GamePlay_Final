using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class CursorAim : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Prevents the player of collecting more than 3 trees
        if (Score.treesScore == 3)
        {
            this.enabled = false;
        }
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit, 5))
        {
            if (hit.collider.tag =="Tree" && Input.GetMouseButtonDown(0))
            {
                CutTree cutTree = hit.collider.gameObject.GetComponent<CutTree>();
                cutTree.treeHealth--;
            }
        }
    }
}
