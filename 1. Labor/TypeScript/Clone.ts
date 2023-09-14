class Clone {
  private rank: string = '';

  // Properties
  public Legion: string = '';
  public Number: string = '';
  public UnitType: string = '';
  public Weapon: string = '';
  public Squad: string = '';
  public Group: string = '';
  public Class: string = '';

  public get Rank(): string {
    return this.rank;
  }

  public set Rank(value: string) {
    this.rank = this.ReadRankFiles('ranks.csv', value);
  }

  public Missions: string[] = [];

  // Constructor
  constructor() {}

  // Methods

  /**
   * Megszamolom, hogy hany db sort tartalmaz a fajlom
   * @param filename Az adatokat tartalmazo fajl neve
   * @returns Egy db szammal, amit kesobb atadok a tombnek, mint hossz.
   */
  private LinesDB(filename: string): number {
    let db: number = 0;
    const f: NodeJS.ReadableStream = require('fs').createReadStream(filename);

    f.on('data', (chunk: Buffer) => {
      db += (chunk.toString().match(/\n/g) || []).length;
    });

    return db;
  }

  /**
   * Beolvasom a Rank nevu fajl tartalmat.
   * @param fileName Beolvasando fajl neve
   * @param rankNumber Az aktualis objektum ranghoz tartozo szama
   * @returns Ha megeggyezik a rankNumber erteke a fajl valamelyik soraban levo ertekkel,
   * akkor a hozza tartozo rang nevet adja vissza.
   */
  private ReadRankFiles(fileName: string, rankNumber: string): string {
    let equal: boolean = false;
    let equalRank: string = '';

    const readline = require('readline');
    const fs = require('fs');
    const fileStream = fs.createReadStream(fileName);

    const rl = readline.createInterface({
      input: fileStream,
      crlfDelay: Infinity,
    });

    rl.on('line', (line: string) => {
      const tempArray: string[] = line.split(';');
      const tempRank = new Rank();

      tempRank.Rank_Number = parseInt(tempArray[0]);
      tempRank.Rank_Name = tempArray[1];

      if (rankNumber === tempRank.Rank_Number.toString()) {
        equalRank = tempRank.Rank_Name;
        equal = true;
      }
    });

    return equalRank;
  }

  /**
   * Fajl adatainak beolvasasa
   * @param fileName Fajlnak a neve
   * @returns Clone tömb
   */
  public ReadFile(fileName: string): Clone[] {
    const clones: Clone[] = [];
    const fs = require('fs');
    const fileStream = fs.createReadStream(fileName);
    let idx: number = 0;

    fileStream.on('data', (chunk: string) => {
      const lines: string[] = chunk.split('\n');

      for (const line of lines) {
        if (line.trim().length === 0) {
          continue; // Skip empty lines
        }

        const clone: Clone = new Clone();
        const tempArray: string[] = line.split(';');

        clone.Legion = tempArray[0];
        clone.Number = tempArray[1];
        clone.Class = tempArray[2];
        clone.Weapon = tempArray[3];
        clone.UnitType = tempArray[4];
        clone.Squad = tempArray[5];
        clone.Group = tempArray[6];
        clone.Rank = tempArray[7];
        const missionString: string = tempArray[8];
        clone.Missions = this.getMissionNumber(missionString);

        clones.push(clone);
      }
    });

    return clones;
  }

  /**
   * Az utolso feladathoz szukseges szetvalasztas
   * @param value A string karakterlanc ami tartalmazza az informaciokat (1-2-3-4-5)
   * @returns String tömb
   */
  public getMissionNumber(value: string): string[] {
    const missions: string[] = [];

    for (let i = 0; i < value.length; i++) {
      if (value[i] !== '-') {
        missions.push(value[i]);
      }
    }

    return missions;
  }
}

const clone = new Clone();
const clones: Clone[] = clone.ReadFile('database.csv');

for (const clone of clones) {
  console.log(clone.Number);
}
