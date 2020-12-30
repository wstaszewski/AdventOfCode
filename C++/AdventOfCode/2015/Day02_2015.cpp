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

	class Day02_2015
	{
	private:
		int part_one(std::vector<std::vector<int>>& vec)
		{
			int paper = 0;
			for (const auto ints : vec)
			{
				std::vector<int> v;
				v.push_back(ints[0] * ints[1]);
				v.push_back(ints[0] * ints[2]);
				v.push_back(ints[1] * ints[2]);
				std::sort(v.begin(), v.end());
				paper += std::accumulate(v.begin(), v.end(), 0) * 2 + v[0];
			}
			return paper;
		}

		int part_two(std::vector<std::vector<int>>& vec)
		{
			int ribbon = 0;
			for (const auto ints : vec)
			{
				std::vector<int> v;
				v.push_back(ints[0]);
				v.push_back(ints[1]);
				v.push_back(ints[2]);
				std::sort(v.begin(), v.end());
				ribbon += (v[0] * 2 + v[1] * 2 + (v[0]*v[1]*v[2]));
			}
			return ribbon;
		}

	public:
		int main()
		{
			std::string line;
			std::vector<std::vector<int>> vec;
			for (std::string line; std::getline(std::cin, line);)
			{
				std::vector<int> tokens;

				// stringstream class check1 
				std::stringstream check1(line);
				std::string intermediate;

				// Tokenizing w.r.t. space ' ' 
				while (getline(check1, intermediate, 'x'))
				{
					tokens.push_back(stoi(intermediate));
				}
				vec.push_back(tokens);
			}

			auto t0 = std::chrono::steady_clock::now();
			int p1 = part_one(vec);
			auto t1 = std::chrono::steady_clock::now();
			int p2 = part_two(vec);
			auto t2 = std::chrono::steady_clock::now();

			auto t_part1 = std::chrono::duration<double>((t1 - t0) * 1000).count();
			auto t_part2 = std::chrono::duration<double>((t2 - t1) * 1000).count();

			std::cout << "--- Day 2: I Was Told There Would Be No Math ---" << std::endl;
			std::cout << "Part 1: " << p1 << " done in " << t_part1 << "ms" << std::endl;
			std::cout << "Part 2: " << p2 << " done in " << t_part2 << "ms" << std::endl;
			std::cout << t_part1 + t_part2 << "ms" << std::endl << std::endl;
			return 0;
		}
	};
}