#include <stdio.h>
#include <string.h>
#include <stdlib.h>

char input[100];
int i = 0;

void E();
void E_dash();
void T();
void T_dash();
void F();

void error() {
    printf("Invalid Expression\n");
    exit(0);
}

void match(char c) {
    if (input[i] == c)
        i++;
    else
        error();
}

// E → T E'
void E() {
    T();
    E_dash();
}

// E' → + T E' | ε
void E_dash() {
    if (input[i] == '+') {
        match('+');
        T();
        E_dash();
    }
}

// T → F T'
void T() {
    F();
    T_dash();
}

// T' → * F T' | ε
void T_dash() {
    if (input[i] == '*') {
        match('*');
        F();
        T_dash();
    }
}

// F → id
void F() {
    if (input[i] == 'i' && input[i + 1] == 'd') {
        i += 2;   // consume "id"
    } else {
        error();
    }
}

int main() {
    printf("Enter expression: ");
    scanf("%s", input);

    E();

    if (input[i] == '\0')
        printf("Valid Expression\n");
    else
        printf("Invalid Expression\n");

    return 0;
}
