#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <numeric>
#include <algorithm>
#include <regex>
#include <chrono>
#include <set>

namespace AoC2015
{

	class Day03_2015
	{
	private:
		int part_one(const std::string& s)
		{
			std::set<std::pair<int, int>> houses;
			std::pair<int, int> location = std::make_pair(0,0);
			houses.insert(location);
			for (auto c : s)
			{
				location.first += c == '>' ? 1 : (c == '<' ? -1 : 0);
				location.second += c == 'v' ? 1 : (c == '^' ? -1 : 0);
				houses.insert(location);
			}
			return (int)houses.size();
		}

		int part_two(const std::string& s)
		{
			std::set<std::pair<int, int>> houses;
			std::pair<int, int> locationSanta = std::make_pair(0, 0);
			std::pair<int, int> locationRobot = std::make_pair(0, 0);
			houses.insert(locationSanta);
			int i = 0;
			for (auto c : s)
			{
				if (i == 0)
				{
					locationSanta.first += c == '>' ? 1 : (c == '<' ? -1 : 0);
					locationSanta.second += c == 'v' ? 1 : (c == '^' ? -1 : 0);
					houses.insert(locationSanta);
				}
				else
				{
					locationRobot.first += c == '>' ? 1 : (c == '<' ? -1 : 0);
					locationRobot.second += c == 'v' ? 1 : (c == '^' ? -1 : 0);
					houses.insert(locationRobot);
				}
				i = 1 - i;

			}
			return (int)houses.size();
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

			std::cout << "--- Day 3: Perfectly Spherical Houses in a Vacuum ---" << std::endl;
			std::cout << "Part 1: " << p1 << " done in " << t_part1 << "ms" << std::endl;
			std::cout << "Part 2: " << p2 << " done in " << t_part2 << "ms" << std::endl;
			std::cout << t_part1 + t_part2 << "ms" << std::endl << std::endl;
			return 0;
		}
	};
}