using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public static ItemController instance;
    private void Awake() {
        instance = this;
    }

    public GameObject magnet;

    public void DropItem(GameObject item, Vector3 position)
    {
        float rx = Random.Range(-0.9f,0.9f);
        float ry = Random.Range(-0.9f,0.9f);
        Instantiate(item, new Vector3(position.x + rx, position.y + ry, 0), Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
