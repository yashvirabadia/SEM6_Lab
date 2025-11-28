//create,open file and count chars,spaces,tabs and new lines in a file.

#include<stdio.h>

void main(){

    FILE *fp;
    
    fp = fopen("HelloWorld.txt","r");

    char ch = getc(fp);
    // printf("%c", ch);
    int charCount=0, spaceCount=0, tabCount=0, newLineCount=0;

    if(fp == NULL){
        printf("File not found!\n");
        return;
    }

    while(ch != EOF){

        charCount++;

        if(ch == ' ')
            spaceCount++;
        else if(ch == '\t')
            tabCount++;
        else if(ch == '\n')
            newLineCount++;

        ch = getc(fp);
    }

    printf("Total Characters: %d\n", charCount);
    printf("Spaces: %d, Tabs: %d, New Lines: %d\n", spaceCount, tabCount, newLineCount);

}