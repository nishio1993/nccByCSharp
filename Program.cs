var output = new List<String>();
output.Add(".intel_syntax noprefix");
output.Add(".global main");
output.Add("");
output.Add("main:");
output.Add("    mov rax, 42");
output.Add("    ret");
output.Add("");
File.WriteAllText("./Program.s", string.Join("\n", output));