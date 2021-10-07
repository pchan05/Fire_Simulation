using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treecontroller : MonoBehaviour
{
    float stddis;
    private Vector3 firespot;
    private GameObject treegenerator;
    private bool isFire, isonFire;
    private float fireontime;
    private float firelife = 1;
    private int treenum, thistreenum;

    private Vector3[] Trees;
    private int[] TreeonFire;
    
    // Start is called before the first frame update
    void Start()
    {
        treegenerator = GameObject.Find("TreeGenerator");

    }

    // Update is called once per frame
    void Update()
    {
        stddis = Random.Range(0.5f, 3);
        firespot = treegenerator.GetComponent<treegenerator>().Firespot;
        isFire = treegenerator.GetComponent<treegenerator>().isfire;
        Trees = treegenerator.GetComponent<treegenerator>().Trees;
        TreeonFire = treegenerator.GetComponent<treegenerator>().TreeonFire;
        treenum = treegenerator.GetComponent<treegenerator>().treenum;

        for (int i = 0; i<treenum; i++)
        {
            if (Vector3.Distance(Trees[i], this.transform.position) < 0.1f && TreeonFire[i]==1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                TreeonFire[thistreenum] = 1;
            }
        }

        for (int i = 0; i < treenum; i++)
        {
            if (this.transform.position == Trees[i]) { thistreenum = i; }
        }


        if (isFire && Vector3.Distance(firespot, this.transform.position) < stddis)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            TreeonFire[thistreenum] = 1;
        }
        if (TreeonFire[thistreenum]==1) { fireontime += Time.deltaTime; }
        if (fireontime > firelife)
        {
            TreeonFire[thistreenum] = 2;
            Destroy(gameObject);
        }
    }
}
