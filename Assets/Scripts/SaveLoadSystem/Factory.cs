public static class Factory
{
    public static IJsonParser CreateJsonParser(string level)
    {
        return new JsonParser(level);
    }
}
