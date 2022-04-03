using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Name Generator", menuName = "Name Generator")]
public class RandomNameGenerator : ScriptableObject
{
    public List<string> prefixes = new List<string>();
    public List<string> suffixes = new List<string>();
    
    public string GeneratePrefix()
    {
        return prefixes[Random.Range(0, prefixes.Count)];
    }
    
    public string GenerateSuffix()
    {
        return suffixes[Random.Range(0, suffixes.Count)];
    }
}
