class Solution {
public:
    vector<vector<int>> threeSum(vector<int>& nums) {
        vector<vector<int>> sols;

        if (nums.size() < 3)
            return {};

        std::sort(nums.begin(), nums.end());

        for (int i = 0; i <= nums.size() - 3; i++) {
            if (i == 0 || nums[i] > nums[i - 1]) {
                int left = i + 1;
                int right = nums.size() - 1;

                while (left < right) {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0) {
                        vector<int> sol = {nums[i], nums[left], nums[right]};
                        sols.push_back(sol);
                    }

                    if (nums[left] + nums[right] < -1 * nums[i]) {
                        int left_ = left;
                        while(nums[left_] == nums[left] && left < right)
                            left++;
                    }
                    else {
                        int right_ = right;
                        while(nums[right_] == nums[right] && right > left)
                            right--;
                    }
                }
            }
        }

        return sols;

    }
};
