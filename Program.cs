//https://leetcode.com/problems/two-sum/
//Two Sum

Solution s = new Solution();
int[] nums = { 2, 7, 11, 15 };
int target = 9;
foreach(int i in s.TwoSum(nums, target))
{
    Console.Write(i);
    Console.Write(",");
}

public class Solution
{

    public int[] TwoSum(int[] nums, int target)
    {

        Dictionary<int, int> map = new Dictionary<int, int>();


        for (int i = 0; i <= nums.Length; i++)
        {
            // 
            int x = target - nums[i];
            if (map.ContainsKey(x))
            {
                return new int[] { map[x], i };
            }

            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = i;
            }
        }
        return new int[0];
    }


}