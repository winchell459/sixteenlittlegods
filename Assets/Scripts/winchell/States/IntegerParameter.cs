using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntegerParameter : Parameter<int>
{
    public override bool Equals(System.Object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            IntegerParameter p = (IntegerParameter)obj;
            return parameter == p.parameter;
        }
    }
}
