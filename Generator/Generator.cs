using System.Text;

class Generator
{
    private static bool isFirstNum = true;
    private static string lastOperand = "";
    public static void generate(string source)
    {
        var output = new List<string>();
        var number = new StringBuilder();

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
                    output.Add($"    mov rax, {number.ToString()}");
                    isFirstNum = false;
                } else {
                    if (character == '+') {
                        output.Add($"    add rax, {number.ToString()}");
                    } else if (character == '-') {
                        output.Add($"    sub rax, {number.ToString()}");
                    }
                }
                number = new StringBuilder();
            }
        }

        if (lastOperand == "+") {
            output.Add($"    add rax, {number.ToString()}");
        } else if (lastOperand == "-") {
            output.Add($"    sub rax, {number.ToString()}");
        }

        output.Add("    ret");
        output.Add("");

        File.WriteAllText("./test.s", string.Join("\n", output));
    }
}