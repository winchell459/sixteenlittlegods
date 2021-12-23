using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Parameter<T>
{
    public string name;
    public bool valid;
    public T parameter;
    public int id;

    //public bool compare(Parameter)

    public abstract bool Equals(System.Object obj);
}
