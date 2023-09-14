import csv

def main():
    navyDB: int = 0

    # Region 1. Solution
    clone: Clone = Clone()
    clones: list['Clone'] = clone.ReadFile("database.csv")

    for i in range(len(clones) - 1):
        if clones[i].UnitType == "navy":
            navyDB += 1

    # Region 1. Task
    minIdx: int = 0

    for i in range(len(clones) - 1):
        if len(clones[minIdx].Missions) > len(clones[i].Missions):
            minIdx = i

    print(f"Legkevesebb bevetesen reszt vevo katona: {clones[minIdx].Number} >> bevetesek: {len(clones[minIdx].Missions)}\n")

    # Region 2. Task
    print("=" * 20)

    # Region 3. Task
    navy: list['Clone'] = [clone for clone in clones if clone.UnitType == "navy"]

    for i in range(len(navy) - 1):
        print(f"Klon: {navy[i].Number}")

    print()

    # Region 4. Task
    db: int = 0

    for i in range(len(clones) - 1):
        if clones[i].Weapon == "DC-15x Sniper Rifle":
            db += 1

    print(f"DC-15x Sniper Rifle-el {db} harcoltak.\n")

    # Region 5. Task
    for i in range(len(clones) - 1):
        if clones[i].Group == "-":
            print(f"{clones[i].Number} - {clones[i].Group}")

    print()

    # Region 6. Task
    with open("final_databas.txt", mode='w') as sw:
        for i in range(len(clones) - 1):
            sw.write(f"{clones[i].Number} =\t{clones[i].Legion}\n{clones[i].Rank}\n")
            sw.write("+" * 20)

    print("Sikeresen mentettuk a formazott adatot...")

if __name__ == "__main__":
    main()
