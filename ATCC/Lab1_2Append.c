//append one file at the end of another file.
#include<stdio.h>

void main(){

    FILE *fp1, *fp2;

    fp1 = fopen("HelloWorld.txt","a");
    fp2 = fopen("Introduction.txt","r");

    char ch = getc(fp2);

    if(fp1 == NULL || fp2 == NULL){
        printf("File not found!\n");
        return;
    }
    
    while(ch != EOF){
        putc(ch, fp1);
        ch = getc(fp2);
    }

    printf("File appended successfully!\n");

}