#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <numeric>
#include <algorithm>
#include <regex>
#include <chrono>

namespace AoC2015
{

	class Day05_2015
	{
	private:
		int vowelCount(const char* str)
		{
			int count = 0;
			while ((*str) != '\0') {
				if (*str == 'a' || *str == 'e' || *str == 'i'
					|| *str == 'o' || *str == 'u') {
					count++;
				}

				// Increment pointer 
				str++;
			}

			return count;
		}

		bool isNiceString(std::string str)
		{
			int vowels = vowelCount(str.c_str());

			// Case 1
			if (vowels < 3)
				return false;

			// Case 3
			if (str.find("ab") != std::string::npos || str.find("cd") != std::string::npos || str.find("pq") != std::string::npos || str.find("xy") != std::string::npos)
				return false;

			// Case 2
			for (int i = 0; i < str.size() - 1; i++)
			{
				if (str[i] == (char)(str[static_cast<std::basic_string<char, std::char_traits<char>, std::allocator<char>>::size_type>(i) + 1]))
				{
					return true;
				}
			}

			return false;
		}

		bool hasPair(std::string s)
		{
			for (int i = 0; i < s.size() - 1; i++)
			{
				std::string pair = s.substr(i, 2);
				if (s.find(pair, static_cast<std::basic_string<char, std::char_traits<char>, std::allocator<char>>::size_type>(i) + 2) != -1)
					return true;
			}

			return false;
		}

		bool hasRepeats(std::string s)
		{
			for (int i = 0; i < s.size() - 2; i++)
			{
				if (s[i] == s[static_cast<std::basic_string<char, std::char_traits<char>, std::allocator<char>>::size_type>(i) + 2])
					return true;
			}

			return false;
		}

		int part_one(const std::vector<std::string>& vec)
		{

			int words = 0;
			for (const auto str : vec)
			{
				if (isNiceString(str))
					words++;
			}
			return words;
		}

		int part_two(const std::vector<std::string>& vec)
		{
			int words = 0;
			for (const auto str : vec)
			{
				bool hPair = hasPair(str);
				bool hRep = hasRepeats(str);
				if (hPair && hRep)
					words++;
			}
			return words;
		}

	public:
		int main()
		{
			std::string line;
			std::vector<std::string> vec;
			for (std::string line; std::getline(std::cin, line);)
			{
				vec.push_back(line);
			}

			auto t0 = std::chrono::steady_clock::now();
			int p1 = part_one(vec);
			auto t1 = std::chrono::steady_clock::now();
			int p2 = part_two(vec);
			auto t2 = std::chrono::steady_clock::now();

			auto t_part1 = std::chrono::duration<double>((t1 - t0) * 1000).count();
			auto t_part2 = std::chrono::duration<double>((t2 - t1) * 1000).count();

			std::cout << "--- Day 5: Doesn't He Have Intern-Elves For This? ---" << std::endl;
			std::cout << "Part 1: " << p1 << " done in " << t_part1 << "ms" << std::endl;
			std::cout << "Part 2: " << p2 << " done in " << t_part2 << "ms" << std::endl;
			std::cout << t_part1 + t_part2 << "ms" << std::endl << std::endl;
			return 0;
		}
	};
}