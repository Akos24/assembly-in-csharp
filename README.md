# Assembly Commands in C# - Homework Project

## Overview

This C# console application performs basic Assembly commands on virtual registers. It reads register values and Assembly commands from a TXT file, processes the commands, and outputs the updated register values.

## Features

* Reads 4 registers from "input.txt" at the start.
* Executes Assembly commands on these registers.
* Supports commands: MOV, ADD, SUB, JNE.

## Instructions

* Create "input.txt" in "PMPHF005_KVZUBT/bin/Debug/net6.0."
* Write 4 comma-separated register values, followed by a line break.
* Example: 1,2,3,4
* Write Assembly commands below the registers.

## Assembly Commands

* MOV:
 * Syntax: MOV DEST SRC|CNST
 * Example: MOV A 2 (Moves 2 to register A)
* ADD:
 * Syntax: ADD DEST SRC|CNST SRC|CNST
 * Example: ADD A 1 2 (Adds 1 and 2 and moves it to register A)
* SUB:
 * Syntax: SUB DEST SRC|CNST SRC|CNST
 * Example: SUB A B C (Subtracts the value of C from the value of B and moves the final value to register A)
* JNE:
 * Syntax: JNE CNST SRC SRC|CNST
 * Example: JNE 3 A D (Jumps to command number 3 if A is not equal to D)

Run the program. If syntax is correct, results will be written to "output.txt."

## Installation and Usage

* Download the repository as a ZIP file.
* Unzip and navigate to the folder.
* Run the Solution app (".sln").
* Run the Console App after updating "input.txt" as instructed.

## Purpose

This project offers a virtual environment for working with registers using Assembly-like commands in C#.

## Bugs and Improvements

Feel free to contribute by reporting bugs or suggesting improvements via pull requests.

## Acknowledgements

Gratitude to Óbuda University for educational support in developing this C# project.

## Contact

For inquiries, message me on LinkedIn: [Ákos Iró](https://www.linkedin.com/in/%C3%A1kos-ir%C3%B3-016b4a293/).


