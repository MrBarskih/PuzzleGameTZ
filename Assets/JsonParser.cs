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
        TextAsset file = Resources.Load($"{level}") as TextAsset;
        jObject = JObject.Parse(file.ToString());
    }

    public List<bool[,]> GetParts()
    {
        List<bool[,]> result = new List<bool[,]>();

        foreach (JToken value in jObject.GetValue("parts"))
        {
            result.Add(value.ToObject<bool[,]>());
        }

        return result;
    }

    public bool[,] GetTemplate()
    {
        bool[,] result = jObject.GetValue("template").ToObject<bool[,]>();

        return result;
    }
}
