using UnityEngine;
//------------------------------------------------------------------------
public class Destroyer : MonoBehaviour
{
    //------------------------------------------------------------------------
    void OnCollisionEnter(Collision col)
    {
        BaseBlock BaseBlock = col.gameObject.GetComponent<BaseBlock>() as BaseBlock;
        if (BaseBlock != null) BaseBlock.Die();
        Destroy(col.gameObject);
    }
    //------------------------------------------------------------------------
}
//------------------------------------------------------------------------