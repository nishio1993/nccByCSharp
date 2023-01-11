class Register
{
    public enum Key
    {
        RAX,
    }

    public static Dictionary<Key, string> Dic = new Dictionary<Key, string>
    {
        {Key.RAX, "rax"}
    };
}