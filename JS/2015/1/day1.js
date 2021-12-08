const { performance } = require('perf_hooks');

const _input = require('./input');

const _up = '(';

var startTimeOne = performance.now()

// Part 1

let final_floor = _input
  .split('')
  .map(v => (v === _up ? 1 : -1))
  .reduce((a, b) => a + b, 0);
  
var endTimeOne = performance.now()

if(final_floor == 232)
  console.log(`Part One: ${final_floor}; done in ${(endTimeOne - startTimeOne).toFixed(2)} ms`);

var startTimeTwo = performance.now()

// Part 2

let instr = _input.split('').map(v => (v === _up ? 1 : -1));

let counter = 0;
let i;
for (i = 0; i < instr.length; i++) {
    let instruction = instr[i];
    counter += instruction;

    if (counter < 0) {
        break;
    }
}

var endTimeTwo = performance.now()
if(i+1 == 1783)
  console.log(`Part Two: ${i+1}; done in ${(endTimeTwo - startTimeTwo).toFixed(2)} ms`);
console.log(`Both done in ${((endTimeOne - startTimeOne) + (endTimeTwo - startTimeTwo)).toFixed(2)} ms`);


//print(f"Part Two:", part2, "done in", "%.4f" % time_elapsed_ms,  "ms")