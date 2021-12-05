using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : MonoBehaviour
{
    public GameObject tree;
    public int treeHealth = 5;
    public bool hasFallen = false;
    
    [SerializeField] public bool reward;


    // Start is called before the first frame update
    void Start()
    {
       tree = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (treeHealth <= 0 && hasFallen ==false)
        {
            StartCoroutine(destroyTree());
            hasFallen = true;
            if (hasFallen)
            {
                reward = true;
                Score.treesScore += 1;
            }
        }
    }
    
    public void SetReward(bool tree)
    {
        reward = tree;
    }

    IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(1);
        Destroy(tree);
    }
}
