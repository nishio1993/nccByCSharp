using System.Text;

var arg = args[0];

var output = new List<String>();
var num = new StringBuilder();
var isFirstNum = true;
var lastOperand = "";
output.Add(".intel_syntax noprefix");
output.Add(".global main");
output.Add("");
output.Add("main:");
foreach(char character in arg) {
    if (char.IsNumber(character)) {
        num.Append(character);
    } else {
        lastOperand = character.ToString();
        if (isFirstNum) {
            output.Add($"    mov rax, {num.ToString()}");
            isFirstNum = false;
        } else {
            if (character == '+') {
                output.Add($"    add rax, {num.ToString()}");
            } else if (character == '-') {
                output.Add($"    sub rax, {num.ToString()}");
            }
        }
        num = new StringBuilder();
    }
}

if (lastOperand == "+") {
    output.Add($"    add rax, {num.ToString()}");
} else if (lastOperand == "-") {
    output.Add($"    sub rax, {num.ToString()}");
}

output.Add("    ret");
output.Add("");
File.WriteAllText("./test.s", string.Join("\n", output));