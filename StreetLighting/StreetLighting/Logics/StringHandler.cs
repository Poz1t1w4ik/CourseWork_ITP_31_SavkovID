namespace StreetLighting.Logics
{
    public static class StringHandler
    {
        public static bool CompareStr(string first, string second)
        {
            return first.Trim().ToLower().Contains(second.Trim().ToLower());
        }
    }
}
