using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Factory
{
    public static IJsonParser CreateJsonParser(string level)
    {
        return new JsonParser(level);
    }
}
