namespace CSharp
{ 
    static class SwapClass
    {
        public static void Swap<Type>(ref Type first, ref Type second)
        { 
            Type buf = first;
            first = second;
            second = buf;
        }
    }
}
