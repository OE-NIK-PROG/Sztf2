import {Clone} from './Clone';

const clone = new Clone();
const clones: Clone[] = clone.ReadFile('database.csv');

let navyDB: number = 0;

// Task 1: Count navy units
for (let i = 0; i < clones.length - 1; i++) {
  if (clones[i].UnitType === 'navy') {
    navyDB++;
  }
}

console.log('Task 1: Navy units count:', navyDB);

// Task 2: Find clone with the fewest missions
let minIdx: number = 0;

for (let i = 0; i < clones.length - 1; i++) {
  if (clones[minIdx].Missions.length > clones[i].Missions.length) {
    minIdx = i;
  }
}

console.log(`Task 2: Legkevesebb bevetesen reszt vevo katona: ${clones[minIdx].Number} >> bevetesek: ${clones[minIdx].Missions.length}\n`);

// Task 3: Collect clones trained on navy ships
const navy: Clone[] = [];
let idx: number = 0;

for (let i = 0; i < clones.length - 1; i++) {
  if (clones[i].UnitType === 'navy') {
    navy[idx++] = clones[i];
  }
}

console.log('Task 3: Clones trained on navy ships:');
for (let i = 0; i < navy.length - 1; i++) {
  console.log(`Klon: ${navy[i].Number}`);
}
console.log();

// Task 4: Count clones using DC-15x Sniper Rifle
let db: number = 0;

for (let i = 0; i < clones.length - 1; i++) {
  if (clones[i].Weapon === 'DC-15x Sniper Rifle') {
    db++;
  }
}

console.log(`Task 4: DC-15x Sniper Rifle-el ${db} harcoltak.\n`);


// Task 5: Print clones without a group
console.log('Task 5: Clones without a group:');
for (let i = 0; i < clones.length - 1; i++) {
  if (clones[i].Group === '-') {
    console.log(`${clones[i].Number} - ${clones[i].Group}`);
  }
}
console.log();

// Task 6: Write clones grouped by team names, excluding navy
const fs = require('fs');
const sw = fs.createWriteStream('final_database.txt');

for (let i = 0; i < clones.length - 1; i++) {
  if (clones[i].UnitType !== 'navy') {
    sw.write(`${clones[i].Number} =\t${clones[i].Legion}\n${clones[i].Rank}\n`);
    sw.write(new Array(21).join('+') + '\n');
  }
}

sw.end();
console.log('Task 6: Sikeresen mentettuk a formazott adatot...');
