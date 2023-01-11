using System.Text;

class Generator
{
    private static List<string> output = new List<string>();
    public static void generate(string source)
    {
        var number = new StringBuilder();
        var isFirstNum = true;
        var lastOperand = "";

        output.Add(".intel_syntax noprefix");
        output.Add(".global main");
        output.Add("");
        output.Add("main:");
        foreach(char character in source) {
            if (char.IsNumber(character)) {
                number.Append(character);
            } else {
                lastOperand = character.ToString();
                if (isFirstNum) {
                    add(Command.Key.MOV, Register.Key.RAX, number.ToString());
                    isFirstNum = false;
                } else {
                    add(Operator.Dic[character.ToString()], Register.Key.RAX, number.ToString());
                }
                number = new StringBuilder();
            }
        }

        add(Operator.Dic[lastOperand.ToString()], Register.Key.RAX, number.ToString());
        output.Add("    ret");
        output.Add("");

        File.WriteAllText("./test.s", string.Join("\n", output));
    }

    private static void add(Command.Key commandKey, Register.Key registerKey, string value)
    {
        output.Add($"    {Command.Dic[commandKey]} {Register.Dic[registerKey]}, {value}");
    }
}