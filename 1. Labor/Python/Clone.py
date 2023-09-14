import csv
from typing import List

class Clone:
    def __init__(self) -> None:
        self.rank: str = ""
        self.Legion: str = ""
        self.Number: str = ""
        self.UnitType: str = ""
        self.Weapon: str = ""
        self.Squad: str = ""
        self.Group: str = ""
        self.Class: str = ""
        self.Missions: List[str] = []

    def ReadFile(self, fileName: str) -> List['Clone']:
        clones: List['Clone'] = []
        with open(fileName, mode='r', newline='') as file:
            reader = csv.reader(file, delimiter=';')
            for row in reader:
                clone = Clone()
                clone.Legion = row[0]
                clone.Number = row[1]
                clone.Class = row[2]
                clone.Weapon = row[3]
                clone.UnitType = row[4]
                clone.Squad = row[5]
                clone.Group = row[6]
                clone.Rank = self.ReadRankFiles("ranks.csv", row[7])
                missionString = row[8]
                clone.Missions = self.getMissionNumber(missionString)
                clones.append(clone)
        return clones

    def ReadRankFiles(self, fileName: str, rankNumber: str) -> str:
        equalRank: str = ""
        with open(fileName, mode='r', newline='') as file:
            reader = csv.reader(file, delimiter=';')
            for row in reader:
                if rankNumber == row[0]:
                    equalRank = row[1]
                    break
        return equalRank

    def getMissionNumber(self, value: str) -> List[str]:
        missions: List[str] = [x for x in value.split('-')]
        return missions
