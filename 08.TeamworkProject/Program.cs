﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.TeamworkProject
{
    public class Program
    { 
    static void Main()
    {
        var list = new List<Team>();

        int n = int.Parse(Console.ReadLine());

        RegisteringTeams(list, n);
        AddingTeamMembers(list);
        PrintingResults(list);
    }

    private static void RegisteringTeams(List<Team> list, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Team newTeam = new Team();

            var str = Console.ReadLine().Split('-');
            var creatorName = str[0];
            var team = str[1];

            newTeam.TeamName = team;
            newTeam.CreatorName = creatorName;
            newTeam.Members = new List<string>();

            if (list.Any(t => t.TeamName == team))
            {
                Console.WriteLine($"Team {team} was already created!");
                continue;
            }

            if (list.Any(c => c.CreatorName == creatorName))
            {
                Console.WriteLine($"{creatorName} cannot create another team!");
                continue;
            }



            Console.WriteLine($"Team {team} has been created by {creatorName}!");
            list.Add(newTeam);
        }
    }

    private static void AddingTeamMembers(List<Team> list)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "end of assignment") break;
            var split = input.Split(new char[] { '-', '>' });
            var user = split[0];
            var teamJoin = split[2];

            if (!list.Any(t => t.TeamName == teamJoin))
            {
                Console.WriteLine($"Team {teamJoin} does not exist!");
                continue;
            }

            if (list.Any(nz => nz.CreatorName == user) || list.Any(x => x.Members.Contains(user)))
            {
                Console.WriteLine($"Member {user} cannot join team {teamJoin}!");
                continue;
            }

            if (list.Any(t => t.TeamName == teamJoin))
            {
                var existingTeam = list.First(t => t.TeamName == teamJoin);

                existingTeam.Members.Add(user);
                continue;
            }

        }
    }

        private static void PrintingResults(List<Team> list)
        {
            var teamsDisband = list.Where(t => t.Members.Count == 0).Select(x => x.TeamName).ToList();

            foreach (var team in list.OrderByDescending(m => m.Members.Count).ThenBy(z => z.TeamName))
            {
                if (team.Members.Count == 0) continue;

                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.CreatorName}");

                foreach (var pl in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {pl}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var item in teamsDisband.OrderBy(x => x))
            {

                Console.WriteLine(item);
            }
        }
    }
}

class Team
{
    public string TeamName { get; set; }
    public List<string> Members { get; set; }
    public string CreatorName { get; set; }
}
