    static int GCD(int[] numbers){
        return numbers.Aggregate(GCD);    
    }

    static int GCD(int a, int b){
            return b == 0 ? a : GCD(b, a % b);
    }
    
    static int LCM(int[] numbers){
        return numbers.Aggregate(LCM);
    }
    
    static int LCM(int a, int b){
        return a * b / GCD(a,b);
    }
    
    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static string Add(string a, string b){
        a = leftPadding(a,"0",Math.Max(a.Length,b.Length));
        b = leftPadding(b,"0",Math.Max(a.Length,b.Length));
        string sum = "";
        int carry = 0;
        for(int i = a.Length - 1; i >= 0; i--){
            int s = int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + carry;
            sum = (s%10).ToString() + sum;
            carry = s/10;
        }
        return sum;
    }
    
    static string Multiply(string a, string b){
        //a = leftPadding(a,"0",Math.Max(a.Length,b.Length));
        //b = leftPadding(b,"0",Math.Max(a.Length,b.Length));
       
    }
    
    static string leftPadding(string s, string elementForPadding, int endLength){
        int l = s.Length;
        for(int c = 0; c < endLength-l; c++){
            s = elementForPadding + s;
        }
        s = elementForPadding + s;
        return s;
    }
    
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Multiply("10", "99"));
    }
}

    
