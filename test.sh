#!/bin/bash
test() {
    input="$1"
	expected="$2"

    dotnet run "$input"
    gcc -o test test.s
    ./test
    result="$?"

	if [ "$result" = "$expected" ]; then
		echo "$input => $expected OK"
	else
		echo "$input => $expected expected, but got $result"
	fi
}

test "1+2" 3
test "1+23+45" 69