using System.Collections.Generic;
using System.Linq;

namespace Leetcode.Solutions
{
    public class Test1to50
    {
        //test1
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    if (nums[i] + nums[j] == target) return new int[] { i, j };
            return new int[] { };
        }
        //test2
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode first = null;
            ListNode p = null;
            int temp = 0;
            while (l1 != null || l2 != null || temp == 1)
            {
                var c = (l2 == null ? 0 : l2.val) + (l1 == null ? 0 : l1.val) + temp;
                temp = c >= 10 ? 1 : 0;
                if (p == null)
                {
                    p = new ListNode(c >= 10 ? c - 10 : c);
                    first = p;
                }
                else
                {
                    p.next = new ListNode(c >= 10 ? c - 10 : c);
                    p = p.next;
                }
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            return first;
        }
        //test3
        public static int LengthOfLongestSubstring(string s)
        {
            List<char> li = new List<char>();
            int maxcount = 0;

            foreach (var item in s.ToArray())
            {
                if (li.Contains(item))
                {
                    li = li.Skip(li.IndexOf(item) + 1).ToList();
                }
                li.Add(item);
                if (maxcount < li.Count)
                {
                    maxcount = li.Count;
                }

            }
            return maxcount;
        }
        //test4
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            List<int> li = nums1.ToList();
            for (int i = 0; i < nums2.Length; i++)
            {
                li.Add(nums2[i]);
            }
            int[] arr = li.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int k = arr[i]; arr[i] = arr[j]; arr[j] = k;
                    }
                }
            }
            if (arr.Length % 2 == 0)
            {
                return (arr[arr.Length / 2] + arr[arr.Length / 2 - 1]) / 2.0d;
            }
            else
            {
                return (arr[arr.Length / 2]);
            }
        }
        //test5
        public static string LongestPalindrome(string s)
        {
            var topstr = "";
            var li = s.ToCharArray();
            for (int i = 0; i < li.Length; i++)
            {
                for (int halflen = topstr.Length / 2; halflen <= i && i + halflen < li.Length; halflen++)
                {
                    int start = i - halflen;
                    bool k = true;
                    var len = 2 * halflen + 1;
                    for (int m = 0; m <= halflen; m++)
                    {
                        if (li[i - m] != li[i + m])
                        {
                            k = false;
                            break;
                        }
                    }
                    if (k && topstr.Length < len)
                    {
                        topstr = new string(li.Skip(start).Take(len).ToArray());
                    }
                    bool k2 = true;
                    var len2 = 2 * halflen + 2;
                    for (int m = 0; m <= halflen; m++)
                    {
                        if (i + m + 1 > li.Length - 1 || li[i - m] != li[i + m + 1])
                        {
                            k2 = false;
                            break;
                        }
                    }
                    if (k2 && topstr.Length < len2)
                    {
                        topstr = new string(li.Skip(start).Take(len2).ToArray());
                    }
                }
            }
            return topstr;
        }
        //test6
        public static string Convert(string s, int numRows)
        {
            var p = "";
            var li = s.ToArray();
            var stap = 2 * numRows - 2;
            if (numRows == 1) return s;
            for (int i = 0; li.Length - 1 >= i * stap; i++) p += li[i * stap];
            if (numRows > 2)
                for (int j = 1; j < numRows - 1; j++)
                    for (int i = 0; li.Length - 1 >= i * stap + j; i++)
                    {
                        p += li[i * stap + j];
                        var start = i * stap;
                        var ex = stap - j;
                        if (start + ex > li.Length - 1) break;
                        p += li[start + ex];
                    }
            if (numRows > 1)
                for (int i = 0; li.Length - 1 >= i * stap + numRows - 1; i++)
                    p += li[i * stap + numRows - 1];
            return p;
        }
        //test7
        public static int Reverse(int x)
        {
            if (x <= -2147483648) return 0;
            var k = x < 0;
            var str = System.Math.Abs(x).ToString().ToCharArray();
            System.Array.Reverse(str);
            if (!int.TryParse(new string(str), out x)) return 0;
            x = k ? -x : x;
            return x;
        }
        //test8
        public static int MyAtoi(string str)
        {
            if (str.Trim(' ') == "" || str.Trim(' ') == "-" || str.Trim(' ') == "+") return 0;
            var ch = str.Trim(' ').ToCharArray();
            if (ch[0] != '-' && ch[0] != '+' && (ch[0] < 48 || ch[0] > 57)) return 0;
            if ((ch[0] == '-' || ch[0] == '+') && (ch.Length < 2 || ch[1] == '-' || ch[1] == '+')) return 0;
            var str2 = "";
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[0] != '-' && ch[0] != '+' && (ch[0] < 48 || ch[0] > 57)) break;
                if (i > 0 && (ch[i] < 48 || ch[i] > 57)) break;
                str2 += ch[i].ToString();
            }
            if (str2.Trim(' ') == "" || str2.Trim(' ') == "-" || str2.Trim(' ') == "+") return 0;
            int x;
            if (!int.TryParse(str2.Trim(' '), out x)) return ch[0] == '-' ? -2147483648 : 2147483647;
            return x;
        }
        //test9
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            var chr = x.ToString().ToCharArray();
            System.Array.Reverse(chr);
            var str = new string(chr);
            int c;
            if (int.TryParse(str, out c) && x == c) return true;
            return false;
        }

        //test11
        public static int MaxArea(int[] height)
        {
            var p = 0;
            for (int i = 0; i < height.Length; i++) 
                for (int j = i + 1; j < height.Length; j++) 
                    p = p > (height[j] > height[i] ? height[i] : height[j]) * (j - i) ? p : (height[j] > height[i] ? height[i] : height[j]) * (j - i);      
            return p;
        }
        //test12
        public static string IntToRoman(int num)
        {
            string GS(int w, string str1, string str5, string str10)
            {
                var tempstr = "";
                if (w <= 3)
                    for (int i = 0; i < w; i++)
                        tempstr += str1;
                else if (w == 4)
                    tempstr += str1 + str5;
                else if (w >= 5 && w < 9)
                {
                    tempstr += str5;
                    for (int i = 0; i < w - 5; i++)
                        tempstr += str1;
                }
                else if (w == 9)
                    tempstr += str1 + str10;
                return tempstr;
            }
            return GS(num / 1000 % 10, "M", "", "") + GS(num / 100 % 10, "C", "D", "M") + GS(num / 10 % 10, "X", "L", "C") + GS(num % 10, "I", "V", "X");
        }

        //test35
        public int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] >= target) return i;
            return nums.Length;
        }
    }
}
