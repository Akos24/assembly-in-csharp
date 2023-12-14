# Assembly commands in C# - Homework Project

## This is a homework project for my University Coding class, which can read registers in a TXT file, and perform basic Assembly commands (which are also stored in the same TXT file) on the registers.

This project is capable of reading 4 registers at the start of a TXT file, and perform Assembly commands on those 4 registers, that are written below the registers.

* The program can move values to a register
* The program can add values to a register
* The program can subtract values from a register
* The program can check if two registers have the same value

## How it works

Step 1:
Create a TXT file in the PMPHF005_KVZUBT/bin/Debug/net6.0 called "input.txt". All the other steps will be within this file.

Step 2:
Write 4 register values separated with a comma. The values should be whole integer numbers. you can only write exactly 4 registers.

Examples:

Good examples:
2,3,4,5
1,5,67,-3
-1,-4,12,0

Bad examples:
1,2,3
2;3;5;7
1,4,6,8,2
3.4,3,2,7

These will be the registers that you will be working with. The first register is register A. The second is register B etc.

Example:
1,2,3,4 --> (A = 1, B = 2, C = 3, D = 4)

After you wrote all 4 registers down separated with a comma, you shall hit a line break

Step 3:
The next n amount of lines will be the Assembly commands that you write.

There are four Assembly commands I included:
* MOV
* ADD
* SUB
* JNE

MOV:
* Moves a value into a register.
* The parameters are: MOV DEST SRC|CNST
* DEST = The destination register, where you want to store the new value (A,B,C,D)
* SRC|CNST = The new value of the destination register.
  * The value can be a source register (A,B,C,D) - This will give the destination register another registers value. It can       also be itself (which will do nothing since it is already it's original value).
  * The value can be a constant (any integer) - This will give the destination register the value of the integer.
* Correct syntax examples:
  * MOV A 2 (A = 2)
  * MOV A B (A = B)
  * MOV B B (B = B)
* Incorrect syntax examples:
  * MOV 2 A
  * MOV A 3.5
  * MOV D B A
 
ADD:
* Moves the sum of 2 values into a register.
* The parameters are: ADD DEST SRC|CNST SRC|CNST
* DEST = The destination register, where you want to store the new value (A,B,C,D)
* SRC|CNST = 2 parameters are like this one. The sum of these 2 parameters go into the destination register.
  * This can be any register (A,B,C,D) or any whole number
* Correct syntax examples:
  * ADD A 1 2 (A = 1 + 2)
  * ADD A B C (A = B + C)
  * ADD B 4 A (B = 4 + A)
  * ADD C C 2 (C = C + 2)
* Incorrect syntax examples:
  * ADD 4 5 6
  * ADD B C
  * ADD A B C D
 
SUB:
* Moves the difference of two numbers into a destination register
* It has the same logic as ADD, so I won't go into much detail
* Correct syntax examples:
  * SUB A B C (A = B - C)
  * SUB B 3 2 (B = 3 - 2)
  * SUB D B 3 (D = B - 3)
* Incorrect syntax examples:
  * SUB 3 A B
  * SUB A 4
  * SUB C A D B
 
JNE:
* Moves to the nth instruction if the last two parameters are not equal. If these two parameters are equal the program goes    to the next instruction.
* The parameters are CNST SRC SRC|CNST
* CNST = The index of the instruction that the program will go to if the instruction returns false.
* SRC|CNST = 2 parameters are like this one. The program will check whether these two parameters are equal.
* Correct syntax examples:
  * JNE 3 A D (if A != D goto third command)
  * JNE 0 A 3 (if A != 3 goto zeroth command)
  * JNE 1 3 4 (if 3 != 4 goto first command - This of course will make an infinite loop)
  * JNE 3 A A (if A != A goto third command - Since A will always equal A, so this command will be ignored)
* Incorrect syntax examples:
  * JNE A B 3
  * JNE A B
  * JNE A B D C

One code example:

1,3,5,8
SUB B B 1
MOV C B
ADD C C 1
JNE 2 C 4

(A = 1, B = 3, C = 5, D = 8)
SUB B B 1 --> (B = 3 - 1 --> B = 2)
MOV C B --> (C = 2)
ADD C C 1 --> (C = 3)
JNE 2 C 4 --> (false)
ADD C C 1 --> (C = 4)
JNE 2 C 4 --> (true)

Output: 1,2,4,8

Step 3:
Run the command. It the syntaxes are correct, the program will write the updated register values into a TXT file called "output.txt". The output should look like the output above.

Step 4:
Check the output.txt file for the updated register.

## How to install and use the project
Step 1:
Download the reprository as a ZIP file, and unzip it
Step 2:
Step into the folder
Step 3:
Run the Solution app with the ".sln" extension
Step 4:
Run the Console App after writing the command(s) into the input.txt file (exact steps above)

## How to make use of this project
If you want to work with registers virtually, and use Assembly in the form of a C# App, you can try that out with this program.

## Find a bug?
This is a beginner project of mine, and it may contain some bugs. If it does feel free to make pull requests to my code, and write down what I could improve in my code. I'm keen on improving my coding skills.

## Acknowledgements
I would like to express my gratitude to Óbuda University for providing the educational foundation and resources that contributed to the development of this C# project.

## Contact
If you would like to contact me, write me a message via LinkedIn: https://www.linkedin.com/in/%C3%A1kos-ir%C3%B3-016b4a293/
