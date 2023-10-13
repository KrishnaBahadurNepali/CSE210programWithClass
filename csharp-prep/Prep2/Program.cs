using System;
using System.Formats.Asn1;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Xml;//this isfo total subject

//I would like to make more advance for this programme using similar logic of python
//I want to put all subjects marks and add them and convert them into percentage
class Program
{
    static void main (string[] args)
    {
        var markslist = new List<float>();//this list I created for the total subject list
        Console.Write("What is the full marks for all total subjects?");
        int full_marks=int.Parse(Console.ReadLine());
        bool continueEntering=true;
        while(continueEntering)
            {
            Console.Write("Enter the marks for all subjects or Enter '0' to stop ? ");
            string answer = Console.ReadLine();
            float marks = float.Parse(answer);
            if (marks==0)
            {   
            continueEntering=false;
            }
            else
            {
                markslist.Add(marks);
            }
            }
        float sum=0;
        //float mark =0;// this space is just for declaration blank space for letter variable
        foreach(float mark in markslist)
            {
            sum+=mark;
            }
        //int total_subject=markslist.Count;//I use system.collections .Generic for the use of total count of Subject.
        float percent=((float)sum)/full_marks*100;
        string letter="";
        if ((float)percent%10>=7 && percent>=90)// to get A+ you have to have grade >=90 or ramainder should 7
            {                                   // I use 95 here because stress challange is asked us to finf A-,A and A+
                letter="A";
            }
        else if((float)percent%10<=7 && percent>=90)//this is because we dot have A+
            {
                 letter="A-";
            }
        else if((float)percent%10>=7 && percent>=80)
            {
                 letter="B+";
            }
        else if((float)percent%10<7 && (float)percent%10>=3 && percent>=80)
            {
                 letter="B";
            }
        else if((float)percent%10<3 && percent>=80)
            {
                letter="B-";
            }
        else if((float)percent%10>=7 && percent>=70)
            {
                letter="C+";    
            }
        else if((float)percent%10>3 && (float)percent%10<7 && percent>=70)   
            {
                letter="C";
            }
        else if((float)percent%10<3 && percent>=70)
            {
                letter="C-";
            }
        else if((float)percent%10>=7 && percent>=60)
            {
                letter="D+";
            }
        else if((float)percent%10>3 && (float)percent%10<7 && percent>=60)
            {
                letter="D";
            }
        else if((float)percent%10<3 && percent>=60)
            {
                letter="D-";
            }
        else 
            {
                 letter="F";
            }
        if((float)percent>=70)
        {
        Console.WriteLine($"Congratulations! you are passed! You have got {letter} grade with {percent}% and the sum total {sum}. Please try again latter.");
        }
        else
        {
        Console.WriteLine($"You have got {letter} grade with {percent}% and sum total is {sum}. Please try again latter.");
        }

    }
}