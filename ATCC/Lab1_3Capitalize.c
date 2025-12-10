//Capitalize the first letter of each word in a file.

#include<stdio.h>

void main(){

    FILE *fp;

    fp = fopen("HelloWorld.txt","r+");

    char ch = getc(fp);

    if(fp == NULL){
        printf("File not found!\n");
        return;
    }

    int newWord = 1; 

    while(ch != EOF){

        if(ch == ' ' || ch == '\n' || ch == '\t'){
            newWord = 1;
        }
        else if(newWord == 1){
            
        }

        ch = getc(fp);
    }

}