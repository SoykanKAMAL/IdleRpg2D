using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mergeable : ScriptableObject
{
    public Mergeable mergeResult;
    
    public Mergeable Merge(Mergeable other)
    {
        if(this == other)
        {
            Debug.Log("Mergeable.Merge: Merging " + this.name + " and " + other.name);
            Debug.Log("Mergeable.Merge: Result is " + mergeResult.name);
            return mergeResult;
        }
        else
        {
            Debug.Log("Mergeable.Merge: Cannot merge " + this.name + " and " + other.name);
            return null;
        }
    }
}
