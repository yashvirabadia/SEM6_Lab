#include<stdio.h>

void main(){
    FILE *fp1, *fp2;

    fp1 = fopen("HelloWorld.txt","r");
    fp2 = fopen("f2.txt","w");

    char ch = fgetc(fp1);

    if(fp1 == NULL){
        printf("File not found!\n");
        return;
    }

    //Phase 1: Remove all the comments from the file.
    while(ch != EOF){
        
        if(ch == '/'){

            char next = fgetc(fp1);
            if(next == '/'){
                do{
                    ch = fgetc(fp1);
                }
                while(ch != '\n');
                printf("Single line comment is ignored\n");

            }
            else if(next == '*'){
                do{
                    ch = fgetc(fp1);
                }
                while( ch != '/');
                printf("Multiple line comment is ignored\n");
            }
            else{
                ungetc(ch,fp1);
                fputc('/',fp2);
            }
            
        }
        else{
            fputc(ch,fp2);
        }
        ch = fgetc(fp1);
    }
    
}