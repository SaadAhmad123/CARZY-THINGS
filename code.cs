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

    
/////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    
    public struct point{
            public int r,c;
    }
    
    static int tableC = 0;
    static int tableR = 0; 
    static int dlrs = 0;
    static int drls = 0;
    //static double dslope = Math.Tan(1);
    
    static bool isHorizontal(point q, point o){
        return q.r == o.r;
    }
    
    static bool isVertical(point q, point o){
        return q.c == o.c;
    }
    
    
    
    static bool isLeftToRightDiagonal(point q, point o){
         return((double)(o.c-q.c)/(o.r-q.r)) == (double)1.0;
    }
    
    static bool isRightToLeftDiagonal(point q, point o){
        return ((double)(o.c-q.c)/(o.r-q.r)) == -(double)1.0;
    }
    
    static bool inRange(int x, int min, int max){
        return (x >= min && x <= max);
    }
        
    static int getPermissibleSquare_inHorizontal(point queen, List<point> phlq, List<point> phrq){
        if(phrq.Count == 0 && phlq.Count == 0){return tableC - 1;}
        if(phrq.Count == 0){
            return (tableC - phlq.Max(x => x.c) - 1);
        }else if (phlq.Count == 0){
            return phrq.Min(x => x.c) - 2;
        }
        int maxC =  phrq.Min(x => x.c);
        int minC =  phlq.Max(x => x.c);
        
        if(inRange(queen.c,minC,maxC)){
            return maxC - minC  - 2;
        }
        return 0;
    }
        
    
           
    static int getPermissibleSquare_inVertical(point queen, List<point> pvaq, List<point> pvbq){
        if(pvaq.Count == 0 && pvbq.Count == 0){return tableR - 1;}
        if(pvbq.Count == 0){
            return pvaq.Min(x => x.r) - 2; 
        }else if(pvaq.Count == 0){
            return tableR - pvbq.Max(x => x.r) - 1;
        }
        int maxR =  pvaq.Min(x => x.r);
        int minR =  pvbq.Max(x => x.r);
       
        if(inRange(queen.c,minR,maxR)){
            return maxR - minR  - 2;
        }
        return 0;
    }
    
    static int getSquare_inLeftToRightDiagonal(point queen){
        int dc = tableC - queen.c;
        int dr = tableR - queen.r;
        return (Math.Min(queen.c, queen.r) + Math.Min(dc,dr) - 1);
    }
    
    static int getSquare_inRightToLeftDiagonal(point queen){
        int dc = tableC - queen.c;
        int dr = tableR - queen.r;
        return (Math.Min(queen.r, dc) + Math.Min(dr, queen.c));
    }
    
    static int getPermissibleSquare_inLeftToRightDiagonal(point queen, List<point> pdlraq, List<point> pdlrbq){
        if(pdlrbq.Count == 0 && pdlraq.Count == 0){return dlrs;}
        if(pdlrbq.Count == 0){
            pdlraq.OrderBy(x => x.r);
            return Math.Min(pdlraq[0].r, pdlraq[0].c) - 2;
        }else if(pdlraq.Count == 0){
            pdlrbq.OrderBy(x => x.r);
            return dlrs - Math.Min(pdlrbq[pdlrbq.Count-1].r, pdlrbq[pdlrbq.Count-1].c) - 1;
        }
        pdlrbq.OrderBy(x => x.r);
        pdlraq.OrderBy(x => x.r);
        return Math.Min(pdlraq[0].r, pdlraq[0].c) - Math.Min(pdlrbq[pdlrbq.Count-1].c, pdlrbq[pdlrbq.Count-1].r) - 2;
    }
           
    static int getPermissibleSquare_inRightToLeftDiagonal(point queen, List<point> pdrlaq, List<point> pdrlbq){
        if(pdrlaq.Count == 0 && pdrlbq.Count == 0){return drls;}
        if(pdrlbq.Count == 0){
            pdrlaq.OrderBy(x => x.r);
            return Math.Min(pdrlaq[0].r, tableC - pdrlaq[0].c) - 2;
        }else if(pdrlaq.Count == 0){
            pdrlbq.OrderBy(x => x.r);
            return drls - Math.Min(pdrlbq[pdrlbq.Count-1].r, tableC - pdrlbq[pdrlbq.Count-1]c) - 1;
        }
        return  Math.Min(pdrlaq.Min(x=>x.r), tableC - pdrlaq.Min(x=>x.c)) - 
            Math.Min(pdrlbq.Max(x=>x.c), tableR - pdrlbq.Min(x=>x.r)) -  2;
    }
    
    
    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        tableC = n;
        tableR = n;
       
        int k = Convert.ToInt32(tokens_n[1]);
        string[] tokens_rQueen = Console.ReadLine().Split(' ');
        
        point queen;
        queen.r = Convert.ToInt32(tokens_rQueen[0]);
        queen.c = Convert.ToInt32(tokens_rQueen[1]);
        dlrs = getSquare_inLeftToRightDiagonal(queen);
        drls = getSquare_inRightToLeftDiagonal(queen);
        
        point[] p = new point[k];
        List<point> phlq = new List<point>();
        List<point> phrq = new List<point>();
        
        List<point> pvaq = new List<point>();
        List<point> pvbq = new List<point>();
        
        List<point> pdlraq = new List<point>();
        List<point> pdlrbq = new List<point>();
        
        List<point> pdrlaq = new List<point>();
        List<point> pdrlbq = new List<point>();

        
        for(int a0 = 0; a0 < k; a0++){
            string[] tokens_rObstacle = Console.ReadLine().Split(' ');
            point obstacle;
            obstacle.r = Convert.ToInt32(tokens_rObstacle[0]);
            obstacle.c = Convert.ToInt32(tokens_rObstacle[1]);
            if(isHorizontal(queen, obstacle)){
                if(queen.c > obstacle.c)
                    phlq.Add(obstacle);
                else
                    phrq.Add(obstacle);
            }
            else if(isVertical(queen, obstacle)){
                if(queen.r > obstacle.r)
                    pvbq.Add(obstacle);
                else
                    pvaq.Add(obstacle);
            }
            else if(isLeftToRightDiagonal(queen, obstacle)){
                if(queen.r > obstacle.r)
                    pdlrbq.Add(obstacle);
                else
                    pdlraq.Add(obstacle);
            }
            else if(isRightToLeftDiagonal(queen, obstacle)){
                if(queen.r > obstacle.r)
                    pdrlbq.Add(obstacle);
                else
                    pdrlaq.Add(obstacle);
            }
        }
        foreach(point xp in pdrlaq){
            Console.WriteLine("pdrlaq = " + xp.r + " " + xp.c);
        }
        foreach(point px in pdrlbq){
            Console.WriteLine("pdrlbq = " + px.r + " " + px.c);
        }
        foreach(point xp in pdlraq){
            Console.WriteLine("pdlraq = " + xp.r + " " + xp.c);
        }
        foreach(point px in pdlrbq){
            Console.WriteLine("pdlrbq = " + px.r + " " + px.c);
        }
        Console.WriteLine("111 = " + getPermissibleSquare_inLeftToRightDiagonal(queen, pdlraq, pdlrbq));
        Console.WriteLine("111 = " + getPermissibleSquare_inRightToLeftDiagonal(queen,pdrlaq,pdrlbq));
        int sum = 0;
        sum = getPermissibleSquare_inHorizontal(queen, phlq, phrq) + getPermissibleSquare_inVertical(queen, pvaq, pvbq)
             +getPermissibleSquare_inLeftToRightDiagonal(queen, pdlraq, pdlrbq)
            +getPermissibleSquare_inRightToLeftDiagonal(queen,pdrlaq,pdrlbq);
        Console.WriteLine(sum);
        
    }
}
