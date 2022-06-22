# Trivia Golden Master Kata

## Description:
This is a legacy code kata that simulates the Trivia game.

The code is small but it has a lot of code smells and sometimes it's difficult to understand.

We will assume it works as expected.

We would like to modify the existing the code but is difficult to guarantee that we will not break anything. 
Prior to modifying the code, we will apply the Golden Master technique to create a safety net that will provide us some security when changing the code.


Although a test class is provided there other simpler solutions to apply the Golden Master technique.

## Goals:
- Apply the Golden Master technique to ensure the the Trivia game continues working as before when we introduce changes.
- Optionally you can refactor the code helped with the Golden Master created previously.

## Steps
1. Find a way to save the output from the Trivia Game after one execution.
2. Apply the Golden Master technique to compare two game executions.
3. If the execution of the same test is always different:
    1. Think how to ensure the repeatability of the test.
    2. Change the code to make the test repeatable.
4. When the Golden Master technique is working: make changes in the Trivia code, generate another result and check that the comparison fails.
5. If you finish: refactor the code to reduce the bad smells and execute the test.

## Original source code from:
https://github.com/jbrains/trivia

J. B. Rainsberger @jbrains


