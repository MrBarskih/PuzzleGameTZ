using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


//read json file and return template array and paryts array
public class JsonParser : IJsonParser
{
    private JObject jObject;

    public JsonParser(string level)
    {
        jObject = JObject.Parse(File.ReadAllText($"Assets/Levels/{level}.json"));
    }

    public int[] GetParts()
    {
        int[] a = new int[1];
        return a;
    }

    public bool[,] GetTemplate()
    {
        bool[,] result = jObject.GetValue("template").ToObject<bool[,]>();

        return result;
    }
}
