#include <stdio.h>

void main() {

    FILE *fp1 = fopen("f2.txt", "r");

    if (fp1 == NULL) {
        printf("File not found!\n");
        return 0;
    }

    int ch;

    //Keywords list 
    char keywords[32][10] = {
        "auto", "break", "case", "char", "const", "continue",
        "default", "do", "double", "else", "enum", "extern",
        "float", "for", "goto", "if", "int", "long",
        "register", "return", "short", "signed", "sizeof",
        "static", "struct", "switch", "typedef", "union",
        "unsigned", "void", "volatile", "while"
    };

    while ((ch = fgetc(fp1)) != EOF) {

        //Ignore whitespaces
        if (ch == ' ' || ch == '\n' || ch == '\t')
            continue;

        // Identifiers or Keywords 
        if ((ch >= 'a' && ch <= 'z') ||
            (ch >= 'A' && ch <= 'Z') ||
            ch == '_') {

            char str[50];
            int i = 0, k, j, isKeyword = 0;

            while ((ch >= 'a' && ch <= 'z') ||
                   (ch >= 'A' && ch <= 'Z') ||
                   (ch >= '0' && ch <= '9') ||
                   ch == '_') {
                str[i++] = ch;
                ch = fgetc(fp1);
            }
            str[i] = '\0';
            ungetc(ch, fp1);

           
            for (k = 0; k < 10; k++) {
                j = 0;
                while (str[j] == keywords[k][j] &&
                       str[j] != '\0' &&
                       keywords[k][j] != '\0') {
                    j++;
                }
                if (str[j] == '\0' && keywords[k][j] == '\0') {
                    isKeyword = 1;
                    break;
                }
            }

            if (isKeyword)
                printf("Keyword: %s\n", str);
            else
                printf("Identifier: %s\n", str);

            continue;
        }

        //Numeric constant
        if (ch >= '0' && ch <= '9') {
            char num[30];
            int i = 0;

            while (ch >= '0' && ch <= '9') {
                num[i++] = ch;
                ch = fgetc(fp1);
            }
            num[i] = '\0';
            ungetc(ch, fp1);

            printf("Constant: %s\n", num);
            continue;
        }

        //String
        if (ch == '"') {
            char str[100];
            int i = 0;

            str[i++] = '"';
            while ((ch = fgetc(fp1)) != '"' && ch != EOF)
                str[i++] = ch;

            str[i++] = '"';
            str[i] = '\0';

            printf("String: %s\n", str);
            continue;
        }

        //Operators
        if (ch == '+' || ch == '-' || ch == '*' || ch == '/' ||
            ch == '=' || ch == '<' || ch == '>') {

            int next = fgetc(fp1);

            if ((ch == '=' && next == '=') ||
                (ch == '<' && next == '=') ||
                (ch == '>' && next == '=')) {
                printf("Operator: %c%c\n", ch, next);
            } else {
                printf("Operator: %c\n", ch);
                ungetc(next, fp1);
            }
            continue;
        }

        //Special characters
        if (ch == ';' || ch == ',' || ch == '(' || ch == ')' ||
            ch == '{' || ch == '}' || ch == '[' || ch == ']' || ch == '#') {
            printf("Special Character: %c\n", ch);
            continue;
        }

        //Unrecognized 
        printf("Unrecognized character: %c\n", ch);
    }

    fclose(fp1);

}
