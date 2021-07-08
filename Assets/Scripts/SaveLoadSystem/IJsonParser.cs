using System.Collections.Generic;

public interface IJsonParser
{
    public bool[,] GetTemplate();
    public List<bool[,]> GetParts(); 
}
