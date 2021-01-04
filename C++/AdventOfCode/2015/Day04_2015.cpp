#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <numeric>
#include <algorithm>
#include <regex>
#include <chrono>

#include "../Utils/md5.h"

namespace AoC2015
{

	class Day04_2015
	{
	private:
		int part_one(const std::string& line)
		{
			int i = 1;
			std::string target = "00000";
			while (md5(line + std::to_string(++i)).compare(0, 5, target) != 0);
			return i;
		}

		int part_two(const std::string& line)
		{
			int i = 1;
			std::string target = "000000";
			while (md5(line + std::to_string(++i)).compare(0, 6, target) != 0);
			return i;

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

			std::cout << "--- Day 4: The Ideal Stocking Stuffer ---" << std::endl;
			std::cout << "Part 1: " << p1 << " done in " << t_part1 << "ms" << std::endl;
			std::cout << "Part 2: " << p2 << " done in " << t_part2 << "ms" << std::endl;
			std::cout << t_part1 + t_part2 << "ms" << std::endl << std::endl;
			return 0;
		}
	};
}