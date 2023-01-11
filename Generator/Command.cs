class Command
{
    public enum Key
    {
        MOV,
        ADD,
        SUB
    }

    public static Dictionary<Key, string> Dic = new Dictionary<Key, string>()
    {
        {Key.MOV, "mov"},
        {Key.ADD, "add"},
        {Key.SUB, "sub"}
    };
}