using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antAttackScript : MonoBehaviour
{
    public KrawScript father;
    public void DoAttack()
    {
        
        
        
            father.DoDamage();
        
    }
    public void DoSpit()
    {
        father.ShootAcid();
    }
}
