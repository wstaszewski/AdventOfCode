#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <chrono>

namespace AoC2020
{

	class Day01
	{
	private:
		int part_one(const std::vector<int>& vec)
		{
			for (const auto a : vec)
				for (const auto b : vec)
					if (a + b == 2020)
						return  a * b;
			return -1;
		}

		int part_two(const std::vector<int>& vec)
		{
			for (const auto a : vec)
				for (const auto b : vec)
					for (const auto c : vec)
						if (a + b + c == 2020)
							return  a * b * c;

			return -1;
		}

	public:
		int main()
		{
			std::string line;
			std::vector<int> vec;
			for (std::string line; std::getline(std::cin, line);)
				vec.push_back(stoi(line));


			auto t0 = std::chrono::steady_clock::now();
			int p1 = part_one(vec);
			auto t1 = std::chrono::steady_clock::now();
			int p2 = part_two(vec);
			auto t2 = std::chrono::steady_clock::now();

			auto t_part1 = std::chrono::duration<double>((t1 - t0) * 1000).count();
			auto t_part2 = std::chrono::duration<double>((t2 - t1) * 1000).count();

			std::cout << "--- Day 1: Report Repair ---" << std::endl;
			std::cout << "Part 1: " << p1 << " done in " << t_part1 << "ms" << std::endl;
			std::cout << "Part 2: " << p2 << " done in " << t_part2 << "ms" << std::endl;
			std::cout << t_part1 + t_part2 << "ms" << std::endl << std::endl;
			return 0;
		}
	};
}