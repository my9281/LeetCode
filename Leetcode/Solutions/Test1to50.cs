﻿using System.Collections.Generic;
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
        //test13
        public static int RomanToInt(string s)
        {
            int sum = 0;
            var ch = s.ToCharArray();
            List<int> li = new List<int>();
            for (int i = 0; i < ch.Length; i++)
            {
                int temp = 0;
                switch (ch[i])
                {
                    case 'I': temp = 1; break;
                    case 'V': temp = 5; break;
                    case 'X': temp = 10; break;
                    case 'L': temp = 50; break;
                    case 'C': temp = 100; break;
                    case 'D': temp = 500; break;
                    case 'M': temp = 1000; break;
                    default:
                        break;
                }
                li.Add(temp);
            }
            for (int i = 0; i < li.Count; i++)
            {
                if (i + 1 >= li.Count || li[i + 1] <= li[i])
                {
                    sum += li[i];
                }
                else
                {
                    sum -= li[i];
                }
            }
            return sum;
        }
        //test14
        public static string LongestCommonPrefix(string[] strs)
        {
            var commonstr = "";
            if (strs.Length <= 0) return commonstr;
            for (int i = 0; i < strs.First().Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                    if (strs[j].ToCharArray().Length <= i || !strs[j].ToCharArray()[i].Equals(strs.First().ToCharArray()[i])) return commonstr;
                commonstr += strs.First().ToCharArray()[i].ToString();
            }
            return commonstr;
        }
        //test15
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var re = new List<IList<int>>();
            var li = nums.ToList();
            li.Sort();
            for (int i = 0; i < li.Count; i++)
            {
                if (i >= li.Count - 2) break;
                var jump = 0;
                if (li[i] == li[i + 1]) jump += 1;
                if (li[i] == li[i + 2])
                {
                    if (li[i] + li[i + 1] + li[i + 1] == 0 && (re.FirstOrDefault(ex => ex[0] == li[i] && ex[1] == li[i + 1]) == null)) re.Add(new List<int>() { li[i], li[i + 1], li[i + 2] });
                    continue;
                }
                for (int j = i + 1; j < li.Count; j++)
                {
                    if (j >= li.Count - 1) break;
                    if (li[j] == li[j + 1])
                    {
                        if (li[i] + li[j] + li[j + 1] == 0 && (re.FirstOrDefault(ex => ex[0] == li[i] && ex[1] == li[j]) == null)) re.Add(new List<int>() { li[i], li[j], li[j + 1] });
                        continue;
                    }
                    var right = li.Count - 1;
                    var left = j + 1;
                    var isok = false;
                    while (true)
                    {
                        var k = (left + right) / 2;
                        if (li[i] + li[j] + li[k] == 0)
                        {
                            re.Add(new List<int>() { li[i], li[j], li[k] });
                            isok = true;
                            break;
                        }
                        else if (left == k || right == k) break;
                        else if (li[i] + li[j] + li[k] > 0) right = k;
                        else if (li[i] + li[j] + li[k] < 0) left = k;
                    }
                    if (isok) continue;
                    if (li[i] + li[j] + li[left] == 0) re.Add(new List<int>() { li[i], li[j], li[left] });
                    else if (li[i] + li[j] + li[right] == 0) re.Add(new List<int>() { li[i], li[j], li[right] });
                }
                i += jump;
            }
            return re;
        }
        //test16
        public static int ThreeSumClosest(int[] nums, int target)
        {
            var li = nums.ToList();
            li.Sort();
            nums = li.ToArray();
            int re = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j + 1 == nums.Length) break;
                    var left = j + 1;
                    var right = nums.Length - 1;
                    var leftsum = nums[i] + nums[j] + nums[left];
                    var rightsum = nums[i] + nums[j] + nums[right];
                    var miniminu = 0;
                    if (leftsum > target)
                    {
                        miniminu = leftsum;
                    }
                    else if (rightsum < target)
                    {
                        miniminu = rightsum;
                    }
                    else
                    {
                        while (true)
                        {
                            var k = (left + right) / 2;
                            if (nums[i] + nums[j] + nums[k] == target) return target;
                            else if (left == k || right == k) break;
                            if (nums[i] + nums[j] + nums[k] > target) right = k;
                            if (nums[i] + nums[j] + nums[k] < target) left = k;
                        }
                        leftsum = nums[i] + nums[j] + nums[left];
                        rightsum = nums[i] + nums[j] + nums[right];
                        miniminu = System.Math.Abs(leftsum - target) > System.Math.Abs(rightsum - target) ? rightsum : leftsum;
                    }
                    re = System.Math.Abs(re - target) > System.Math.Abs(miniminu - target) ? miniminu : re;
                }
            }
            return re;
        }
        //test17
        public static IList<string> LetterCombinations(string digits)
        {
            var li = new List<string>();
            Dictionary<char, string> d = new Dictionary<char, string>();
            d.Add('2', "abc");
            d.Add('3', "def");
            d.Add('4', "ghi");
            d.Add('5', "jkl");
            d.Add('6', "mno");
            d.Add('7', "pqrs");
            d.Add('8', "tuv");
            d.Add('9', "wxyz");
            GetdigitSigle(d, digits, li, "");
            return li;
        }
        //test17 sup
        static void GetdigitSigle(Dictionary<char, string> env, string digits, List<string> outer, string now)
        {
            if (string.IsNullOrEmpty(digits)) { outer.Add(now); return; }
            env[digits.ToCharArray().First()].ToCharArray().ToList().ForEach(ex => GetdigitSigle(env, new string(digits.ToCharArray().Skip(1).ToArray()), outer, now + ex.ToString()));
        }
        //test19
        public static ListNode RemoveNthFromEnd(ListNode head, int n, bool isstart = true)
        {
            if (head.next == null && n == 1) return null;
            if (isstart)
            {
                var i = 1;
                var now = head;
                while (true)
                {
                    if (now.next == null)
                    {
                        break;
                    }
                    now = now.next;
                    i += 1;
                }
                n = i - n;
            }
            if (n <= 0)
            {
                return head?.next;
            }
            if (n == 1)
            {
                head.next = head?.next?.next;
            }
            else
            {
                RemoveNthFromEnd(head.next, n - 1, false);
            }
            return head;
        }
        //test20
        public static bool IsValid(string s)
        {
            if (s == "") return true;
            List<string> staticSTA = new List<string>();
            foreach (var item in s.ToCharArray())
            {
                switch (item.ToString())
                {
                    case "(":
                    case "[":
                    case "{":
                        staticSTA.Add(item.ToString());
                        break;
                    case ")":
                        {
                            if (staticSTA.Count <= 0)
                            {
                                return false;
                            }
                            if (staticSTA.Last() == "(")
                            {
                                staticSTA.RemoveAt(staticSTA.Count - 1);
                                break;
                            }
                        }
                        return false;
                    case "]":
                        {
                            if (staticSTA.Count <= 0)
                            {
                                return false;
                            }
                            if (staticSTA.Last() == "[")
                            {
                                staticSTA.RemoveAt(staticSTA.Count - 1);
                                break;
                            }
                        }
                        return false;
                    case "}":
                        {
                            if (staticSTA.Count <= 0)
                            {
                                return false;
                            }
                            if (staticSTA.Last() == "{")
                            {
                                staticSTA.RemoveAt(staticSTA.Count - 1);
                                break;
                            }
                        }
                        return false;
                    default:
                        return false;
                }
            }
            if (staticSTA.Count != 0) return false;
            return true;
        }
        //test21
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            ListNode first = null;
            ListNode now = null;
            if (l1?.val <= l2?.val)
            {
                now = l1;
                l1 = l1?.next;
                now.next = null;
            }
            else
            {
                now = l2;
                l2 = l2?.next;
                now.next = null;
            }
            first = now;
            while (true)
            {
                if (l1 == null)
                {
                    now.next = l2;
                    break;
                }
                if (l2 == null)
                {
                    now.next = l1;
                    break;
                }
                if (l1.val <= l2.val)
                {
                    now.next = l1;
                    l1 = l1.next;
                    now = now.next;
                }
                else
                {
                    now.next = l2;
                    l2 = l2.next;
                    now = now.next;
                }
            }
            return first;
        }
        //test22
        public static IList<string> GenerateParenthesis(int n)
        {
            if (n <= 0) return new List<string>();
            if (n == 1) return new List<string>() { "()" };
            var li = new List<string>();
            GenerateParenthesisSup(li, n, n);
            return li;
        }
        //test22 sup
        private static void GenerateParenthesisSup(List<string> li, int n, int kyr, int kpl = 0, string str = "")
        {
            if (str.Length == n * 2 - 1)
            {
                if (kpl == 1 && kyr == 1) li.Add(str + ")");
                return;
            }
            if (kpl > kyr || kpl < 0) return;
            GenerateParenthesisSup(li, n, kyr, kpl + 1, str + "(");
            GenerateParenthesisSup(li, n, kyr - 1, kpl - 1, str + ")");
        }
        //test23
        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode first = null;
            ListNode last = null;
            while (true)
            {
                int site = -1;
                int? min = null;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null)   continue; 
                    if (min == null || min >= lists[i].val)
                    {
                        min = lists[i].val;
                        site = i;
                    }
                }
                if (site == -1) break; 
                if (last == null)
                {
                    first = lists[site];
                    last = lists[site];
                }
                else
                {
                    last.next = lists[site];
                    last = last.next;
                }
                lists[site] = lists[site].next;
            }
            return first;
        }

        //test26
        public static int RemoveDuplicates(int[] nums)
        {
            var count = nums.Length;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        count -= 1;
                        for (int k = j; k < count; k++)
                        {
                            nums[k] = nums[k + 1];
                        }
                        j--;
                    }
                }
            }
            return count;
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