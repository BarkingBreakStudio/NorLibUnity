using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class NorLibExtensions
{
    public static bool CompareTags(this Component component, IEnumerable<string> tags)
    {
        return tags.Contains(component.tag);
    }

    public static bool CompareTags(this GameObject gameObject, IEnumerable<string> tags)
    {
        return tags.Contains(gameObject.tag);
    }


    //string
    public static string TrimEnd(this string original, string trimString)
    {
        if (original.EndsWith(trimString))
        {
            return original.Substring(0, original.Length - trimString.Length);
        }
        else
        {
            return original;
        }
    }

    public static string TrimStart(this string original, string trimString)
    {
        if (original.StartsWith(trimString))
        {
            return original.Substring(trimString.Length);
        }
        else
        {
            return original;
        }
    }

}
