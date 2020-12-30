#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <chrono>

namespace AoC2015
{

	class Day01_2015
	{
	private:
		int part_one(const std::string& s)
		{
			return (int)(std::count(s.begin(), s.end(), '(') - count(s.begin(), s.end(), ')'));
		}

		int part_two(const std::string& s)
		{
			int c = 0;
			for (size_t i = 0; i < s.size(); i++)
			{
				if ('(' == s[i]) c++;
				if (')' == s[i]) c--;
				if (-1 == c)
					return int(i) + 1;
			}

			return -1;
		}

	public:
		int main()
		{
			std::string line;
			std::getline(std::cin, line);

			auto t0 = std::chrono::steady_clock::now();
			int p1 = part_one(line);
			auto t1 = std::chrono::steady_clock::now();
			int p2 = part_two(line);
			auto t2 = std::chrono::steady_clock::now();

			auto t_part1 = std::chrono::duration<double>((t1 - t0) * 1000).count();
			auto t_part2 = std::chrono::duration<double>((t2 - t1) * 1000).count();

			std::cout << "--- Day 1: Not Quite Lisp ---" << std::endl;
			std::cout << "Part 1: " << p1 << " done in " << t_part1 << "ms" << std::endl;
			std::cout << "Part 2: " << p2 << " done in " << t_part2 << "ms" << std::endl;
			std::cout << t_part1 + t_part2 << "ms" << std::endl << std::endl;
			return 0;
		}
	};
}