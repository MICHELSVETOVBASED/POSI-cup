using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class Solution {
    
    public int LengthOfLongestSubstring(string s){
        string[] news = s.Split();
        int mainCount = 0;
        string objectiveSubs = "";
        for (int i = 0; i < news.Length; i++){
            int count = 0;
            if (i + 1 != news.Length){
                if (news[i] != news[i + 1]){
                    count++;
                    StringBuilder newstring = new StringBuilder();
                    newstring.Append(news[i]);
                    if (count >= mainCount)
                        mainCount = count;
                }
            }
        }
    }

    static void Main(){
        StateMachine.InvokeTransition("string",parameters)
    }
    
    
}

static class StateMachine{
    static void InvokeTransition(string x)
    {
    }
}