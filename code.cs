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
    
