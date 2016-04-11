using UnityEngine;
using System.Collections;

public class SpawnNewBlock : MonoBehaviour {

    public GameObject upperBlock; 
    public GameObject lowerBlock;

    public Transform upperBlockSpawn;
    public Transform lowerBlockSpawn;

	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "UpperBlock")
        {
            Instantiate(upperBlock, upperBlockSpawn.position, upperBlockSpawn.rotation);
        }
        if (coll.gameObject.tag == "LowerBlock")
        {
            Instantiate(lowerBlock, lowerBlockSpawn.position, lowerBlockSpawn.rotation);
        }
    }
}
