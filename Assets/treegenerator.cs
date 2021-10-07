using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treegenerator : MonoBehaviour
{
    public GameObject treeprefab;
    Color red = new Color(1, 0, 0, 1);
    float treespan = 0.01f;
    float firespan = 30;
    float treetime = 0;
    float firetime = 0;
    public Vector3 Firespot;
    public bool isfire;
    public int treenum = 0;
    public Vector3[] Trees;
    public int[] TreeonFire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        treetime += Time.deltaTime;
        firetime += Time.deltaTime;
        isfire = false;
        firespan = Random.Range(1,4);
        if (treetime >= treespan)
        {
            treetime = 0;
            GameObject tree = Instantiate(treeprefab) as GameObject;
            tree.transform.position = new Vector3(Random.Range(-8.4f, 8.4f), Random.Range(-4.4f, 4.4f), 0);
            Trees[treenum] = tree.transform.position;
            TreeonFire[treenum] = 0;
            treenum++;
            Debug.Log("나무 생성: " + tree.transform.position.ToString("F2"));
        }
        if (firetime >= firespan)
        {
            firetime = 0;
            isfire = true;
            Firespot = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 0);
            Debug.Log("번개: " + Firespot.ToString("F2"));
        }
    }
}
